using UnityEngine;

public class RigidbodyBase : MonoBehaviour, IObjectComponent<ObjectBase>
{
    ObjectBase mMediator;
    Rigidbody mRigidbody;
    Vector2 mDirection = Vector2.zero;

    protected void FixedUpdate()
    {
        SetVelocity();
    }

    protected void SetVelocity()
    {
    }

    #region Bind
    public void BindComponent(ObjectBase mediator)
    {
        mMediator = mediator;
        mRigidbody = GetComponent<Rigidbody>();
    }

    public void UnbindComponent()
    {
        mMediator = null;
        mRigidbody = null;
    }
    #endregion

    #region Receive
    public void SetDirection(Vector2 direction)
    {
        mDirection = direction;
    }
    #endregion
}
