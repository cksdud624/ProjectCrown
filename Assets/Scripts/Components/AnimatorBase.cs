using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AnimatorBase : MonoBehaviour, IObjectComponent<CharacterBase, CharacterData, CharacterChannel>
{
    protected Animator mAnimator;

    protected CharacterBase mMediator;
    protected CharacterData mCharacterData;
    protected CharacterChannel mCharacterChannel;

    protected Transform mModel;
    protected AnimatorBridge mBridge;

    protected List<ComboNode> mCombo;
    protected ComboNode mCurrentNode = null;

    protected float mCrossFadeTime = 0.2f;

    protected void Update()
    {
        RotateModel();
    }

    protected void RotateModel()
    {
        if (mCharacterChannel == null)
            return;

        Vector2 localDirection = mCharacterChannel.LocalDirection;

        if (localDirection == Vector2.zero)
            return;

        if (mCharacterChannel.ObjectState != eObjectState.Normal)
            return;

        Vector3 forward = mCharacterChannel.GlobalTransform.forward;
        forward.y = 0;

        Vector3 right = Vector3.Cross(Vector3.up, forward);

        Vector3 direction = forward * localDirection.y + right * localDirection.x;

        Quaternion rotation = Quaternion.LookRotation(direction);
        mModel.rotation = Quaternion.Lerp(mModel.rotation, rotation, 0.1f);
    }

    #region Bind
    public void Bind(CharacterBase mediator, CharacterData data, CharacterChannel channel)
    {
        mMediator = mediator;
        mCharacterData = data;
        mCharacterChannel = channel;
        mCharacterChannel.OnLocalDirectionChanged += LocalDirectionChanged;
        mCharacterChannel.OnInput += InputChanged;

        mAnimator = transform.GetComponentInChildren<Animator>();
        mModel = mAnimator.transform;
        mCombo = data.ComboNodeGraph.GetComboNodes();

        mBridge = mAnimator.GetComponent<AnimatorBridge>();
        mBridge.EnterState += EntryState;
        mBridge.EndAuto += EndAutoState;
    }

    public void Unbind()
    {
        mBridge.EnterState -= EntryState;
        mBridge.EndAuto -= EndAutoState;
        mBridge = null;

        mAnimator = null;
        mModel = null;
        mCombo = null;

        mCharacterChannel.OnLocalDirectionChanged -= LocalDirectionChanged;
        mCharacterChannel.OnInput -= InputChanged;

        mMediator = null;
        mCharacterData = null;
        mCharacterChannel = null;
    }
    #endregion

    #region Receive
    protected void LocalDirectionChanged(Vector2 direction)
    {
        if (mCharacterChannel.ObjectState != eObjectState.Normal)
            return;

        string stateName;
        if (direction.magnitude >= 0.5f)
            stateName = eAnimationType.Run.ToString();
        else
            stateName = eAnimationType.Idle.ToString();
        PlayAnimation(stateName);
    }

    public void InputChanged(eInputCommand inputCommand)
    {
        string stateName = "";
        if (mCurrentNode == null)
        {
            ComboNode checkNode = mCombo.FirstOrDefault(node => node.InputCommand == inputCommand
            && node.PreviousNodes.Count == 0);
            if (checkNode == null)
                return;

            mCurrentNode = checkNode;

            if (mCurrentNode.IndexType == eAnimationIndexType.Single)
            {
                stateName = mCurrentNode.AnimationType.ToString();
                PlayAnimation(stateName);
            }
            else if (mCurrentNode.IndexType == eAnimationIndexType.Several)
            {
                stateName = mCurrentNode.AnimationType.ToString() + mCurrentNode.AnimationIndex.ToString();
                PlayAnimation(stateName);
            }
        }
        else
        {
            if (mCurrentNode.NextNodes.Count == 0)
                return;
            else
            {
                float time = mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                bool canCancel = false;
                for(int n = 0; n < mCurrentNode.CancelMins.Count; n++)
                {
                    float min = mCurrentNode.CancelMins[n];
                    float max = mCurrentNode.CancelMaxs[n];
                    if (min < time && max > time)
                        canCancel = true;
                }
                if(canCancel)
                {
                    ComboNode checkNode =  mCurrentNode.NextNodes.FirstOrDefault(node => node.InputCommand == inputCommand);

                    if (checkNode == null)
                        return;
                    mCurrentNode = checkNode;

                    if (mCurrentNode.IndexType == eAnimationIndexType.Single)
                    {
                        stateName = mCurrentNode.AnimationType.ToString();
                        PlayAnimation(stateName);
                    }
                    else if (mCurrentNode.IndexType == eAnimationIndexType.Several)
                    {
                        stateName = mCurrentNode.AnimationType.ToString() + mCurrentNode.AnimationIndex.ToString();
                        PlayAnimation(stateName);
                    }
                }
            }
        }
    }
    #endregion

    #region AnimationPlay
    private void PlayAnimation(string stateName)
    {
        mAnimator.CrossFade(stateName, mCrossFadeTime);
    }
    #endregion

    #region AnimatorBridge
    protected void EntryState(AnimatorStateBase animatorState, eObjectState state)
    {
        eObjectState objectState = mCharacterChannel.ObjectState;
        if (objectState != state)
            mCharacterChannel.ObjectState = state;
    }

    protected void EndAutoState(AnimatorStateBase animationState, eObjectState state)
    {
        if (mAnimator.IsInTransition(0))
            return;

        if (state == eObjectState.Action)
        {
            mCharacterChannel.ObjectState = eObjectState.Normal;
            if(mCharacterChannel.LocalDirection.magnitude <= 0.5f)
                PlayAnimation(eAnimationType.Idle.ToString());
            else
                PlayAnimation(eAnimationType.Run.ToString());
            mCurrentNode = null;
        }
    }
    #endregion
}
