using Unity.VisualScripting;
using UnityEngine;

public class AnimatorBase : MonoBehaviour, IObjectComponent<CharacterBase>
{
    protected Animator mAnimator;

    protected CharacterBase mMediator;
    protected Transform mModel;
    protected Vector2 mDirection = Vector2.zero;
    protected string mStateName = "Idle";

    protected void Update()
    {
        RotateModel();
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
    public void BindComponent(CharacterBase mediator)
    {
        mMediator = mediator;
        mAnimator = transform.GetComponentInChildren<Animator>();
        mModel = mAnimator.transform;
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
    public void PlayAnimation(eAnimationType type, eAnimationIndexType indexType, int index = 0)
    {
        mStateName = type.ToString();
        mAnimator.CrossFade(mStateName, 0.5f);
    }

    public void PlayAnimation(eInputCommand inputCommand)
    {
        mAnimator.CrossFade("Attack1", 0.5f);
    }
    #endregion
}
