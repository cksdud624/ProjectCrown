using UnityEngine;
using System.Collections.Generic;

public class AnimatorBase : MonoBehaviour, IObjectComponent
{
    //애니메이터 베이스 -> 애니메이션 공통부분을 담당한다.
    protected CharacterBase mCharacter;
    protected Animator mAnimator;

    protected ComboRoute mComboRoute;
    protected ComboNode currentNode = null;
    public ComboNode CurrentNode { get { return currentNode; } }

    protected Vector2 mModelDirection = Vector2.zero;
    protected float mMoveLerp = 0f;
    protected bool mIsRestrict = false;


    public void SetMediator(ObjectBase objectBase)
    {
        Init();

        if (objectBase is CharacterBase)
            mCharacter = (CharacterBase)objectBase;
        else
            Debug.Log("Cast Error on AnimatorBase");
    }

    public void SetComboRoute(ComboRoute comboRoute)
    {
        mComboRoute = comboRoute;
    }


    protected virtual void Init()
    {
        mAnimator = GetComponent<Animator>();
    }

    protected void Update()
    {
        SetVelocityParameter();
        RotateModel();
    }

    protected void RotateModel()
    {
        if (mIsRestrict)
            return;

        if(mModelDirection != Vector2.zero)
        {
            Vector3 forwardDirection = mCharacter.GetCameraDirection();
            forwardDirection.y = 0;
            Vector3 rightDirection = Vector3.Cross(Vector3.up, forwardDirection);
            Vector3 moveDirection = forwardDirection * mModelDirection.y + rightDirection * mModelDirection.x;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 12);
        }
    }

    protected void SetVelocityParameter()
    {
        if (mCharacter.IsMoving())
        {
            mMoveLerp = Mathf.Lerp(mMoveLerp, 1, Time.deltaTime * 15);
            if (mMoveLerp > 0.99f)
                mMoveLerp = 1;
        }
        else
        {
            mMoveLerp = Mathf.Lerp(mMoveLerp, 0, Time.deltaTime * 15);
            if (mMoveLerp < 0.01f)
                mMoveLerp = 0;
        }

        mAnimator.SetFloat("Velocity", mMoveLerp);
    }

    #region StateMachine
    public void EndStateAuto(ComboNode comboNode)
    {
        if(comboNode == currentNode)
        {
            currentNode = null;
            mAnimator.CrossFade("Idle", 0.1f);
            SetRestrict(false);
        }
    }
    #endregion


    #region Receive
    public void SetModelRotation(Vector2 rotation)
    {
        mModelDirection = rotation;
    }

    public void SetInput(int input)
    {
        PlayAction(input);
    }
    #endregion

    protected void PlayAction(int input)
    {
        bool isChanged = false;

        if (!CanCancelCombo())
            return;

        for (int i = 0; i < mComboRoute.ComboNodes.Count; i++)
        {
            ComboNode tempNode = mComboRoute.ComboNodes[i];
            if(currentNode == null)
            {
                if(tempNode.PreviousNode == null && tempNode.EntryInput == (EClick)input)
                {
                    currentNode = tempNode;
                    isChanged = true;
                    break;
                }
            }
            else
            {
                if (tempNode.PreviousNode == currentNode && tempNode.EntryInput == (EClick)input)
                {
                    currentNode = tempNode;
                    isChanged = true;
                    break;
                }
            }
        }

        if(isChanged)
        {
            mAnimator.CrossFade(currentNode.ActionIndex.ToString(), 0.1f, 0);
            SetRestrict(true);
        }
    }

    protected bool CanCancelCombo()
    {
        float normalizedTime = mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (currentNode == null)
            return true;

        if (normalizedTime < currentNode.CancelMin || normalizedTime > currentNode.CancelMax)
            return false;

        return true;
    }

    protected void SetRestrict(bool isRestrict)
    {
        mCharacter.RestrictMove(isRestrict);
        mIsRestrict = isRestrict;
    }

}
public enum EClick
{
    LeftCancel, LeftClick, RightCancel, RightClick, ShiftCancel, ShiftClick, SpaceCancel, SpaceClick
}