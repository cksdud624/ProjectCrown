using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class AnimatorBase : MonoBehaviour, IObjectComponent<CharacterBase, CharacterData>
{
    protected Animator mAnimator;

    protected CharacterBase mMediator;
    protected Transform mModel;
    protected Vector2 mDirection = Vector2.zero;

    protected List<ComboNode> mCombo;
    protected ComboNode mCurrentNode = null;

    protected void Update()
    {
        RotateModel();
        if(mCurrentNode != null && mAnimator != null)
        {
            float time;
            if (mAnimator.IsInTransition(0))
            {
                time = mAnimator.GetNextAnimatorStateInfo(0).normalizedTime;
            }
            else
            {
                time = mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            }

            if (time > 1f)
            {
                mAnimator.CrossFade(eAnimationType.Idle.ToString(), 0.5f);
                mCurrentNode = null;
            }
        }
    }

    protected void RotateModel()
    {
        if (mDirection == Vector2.zero)
            return;

        Vector3 forward = mMediator.GetForward();
        forward.y = 0;

        Vector3 right = Vector3.Cross(Vector3.up, forward);

        Vector3 direction = forward * mDirection.y + right * mDirection.x;

        Quaternion rotation = Quaternion.LookRotation(direction);
        mModel.rotation = Quaternion.Lerp(mModel.rotation, rotation, 0.1f);
    }

    #region Bind
    public void BindComponent(CharacterBase mediator, CharacterData data)
    {
        mMediator = mediator;
        mAnimator = transform.GetComponentInChildren<Animator>();
        mModel = mAnimator.transform;
        mCombo = data.ComboNodeGraph.GetComboNodes();
    }

    public void UnbindComponent()
    {
        mMediator = null;
        mAnimator = null;
        mModel = null;
    }
    #endregion

    #region Receive
    public void SetModelDirection(Vector2 direction)
    {
        mDirection = direction;
    }
    #endregion

    #region AnimationPlay
    public void PlayMoveAnimation(eAnimationType type, eAnimationIndexType indexType, int index = 0)
    {
        string stateName = type.ToString();
        mAnimator.CrossFade(stateName, 0.5f);
    }

    public void PlayAnimation(eInputCommand inputCommand)
    {
        string stateName = "";
        if (mCurrentNode == null)
        {
            mCurrentNode = mCombo.First(node => node.InputCommand == inputCommand
            && node.PreviousNodes.Count == 0);
            if (mCurrentNode.IndexType == eAnimationIndexType.Single)
            {
                stateName = mCurrentNode.AnimationType.ToString();
                mAnimator.CrossFade(stateName, 0.5f);
            }
            else if (mCurrentNode.IndexType == eAnimationIndexType.Several)
            {
                stateName = mCurrentNode.AnimationType.ToString() + mCurrentNode.AnimationIndex.ToString();
                mAnimator.CrossFade(stateName, 0.5f);
            }
            else
                return;
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
                    mCurrentNode = mCurrentNode.NextNodes.First(node => node.InputCommand == inputCommand);
                    if (mCurrentNode.IndexType == eAnimationIndexType.Single)
                    {
                        stateName = mCurrentNode.AnimationType.ToString();
                        mAnimator.CrossFade(stateName, 0.5f);
                    }
                    else if (mCurrentNode.IndexType == eAnimationIndexType.Several)
                    {
                        stateName = mCurrentNode.AnimationType.ToString() + mCurrentNode.AnimationIndex.ToString();
                        mAnimator.CrossFade(stateName, 0.5f);
                    }
                }
            }
        }
    }
    #endregion
}
