using UnityEngine;

public class RigidbodyBase : MonoBehaviour, IObjectComponent<ObjectBase, ObjectData, ObjectChannel>
{
    protected Rigidbody mRigidbody;

    protected ObjectBase mMediator;
    protected ObjectData mObjectData;
    protected ObjectChannel mObjectChannel;

    protected void FixedUpdate()
    {
        SetVelocity();
    }

    protected void SetVelocity()
    {
        if (mObjectChannel == null)
            return;
        if (mObjectChannel.GlobalTransform == null)
            return;
        if (mObjectChannel.ObjectState != eObjectState.Normal)
            return;

        Vector3 forward = mObjectChannel.GlobalTransform.forward;
        Vector2 localDirection = mObjectChannel.LocalDirection;
        forward.y = 0;
        Vector3 right = Vector3.Cross(Vector3.up, forward);
        Vector3 velocity = forward * localDirection.y + right * localDirection.x;

        mRigidbody.linearVelocity = velocity;
    }

    #region Bind
    public void Bind(ObjectBase mediator, ObjectData data, ObjectChannel channel)
    {
        mMediator = mediator;
        mObjectData = data;
        mObjectChannel = channel;

        mRigidbody = GetComponent<Rigidbody>();
    }

    public void Unbind()
    {
        mMediator = null;
        mObjectData = null;
        mObjectChannel = null;

        mRigidbody = null;
    }
    #endregion
}
