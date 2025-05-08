using UnityEngine;

public class CameraBase : MonoBehaviour, IObjectComponent<ObjectBase, ObjectData, ObjectChannel>
{
    ObjectBase mMediator;
    ObjectData mObjectData;
    ObjectChannel mObjectChannel;

    CameraFlag mCameraFlag;

    #region Bind
    public void Bind(ObjectBase mediator, ObjectData data, ObjectChannel channel)
    {
        mMediator = mediator;
        mObjectData = data;
        mObjectChannel = channel;
        mObjectChannel.OnDrag += Rotate;
    }

    public void Unbind()
    {
        mMediator = null;
        mObjectData = null;
        mObjectChannel.OnDrag -= Rotate;
        mObjectChannel = null;
    }
    #endregion

    #region AttachFlag
    public void AttachCameraFlag(CameraFlag flag)
    {
        mCameraFlag = flag;
        mCameraFlag.AttachParent(this);
        mObjectChannel.GlobalTransform = mCameraFlag.transform;
    }    

    public void DetachCameraFlag()
    {
        mObjectChannel.GlobalTransform = null;
        mCameraFlag = null;
    }

    #endregion

    #region Receive
    public void Rotate(Vector2 delta)
    {
        mCameraFlag.Rotate(delta);
    }
    #endregion

    #region Send
    public Vector3 GetForward() => mCameraFlag.transform.forward;
    #endregion
}