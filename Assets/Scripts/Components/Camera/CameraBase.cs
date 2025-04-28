using UnityEngine;

public class CameraBase : MonoBehaviour, IObjectComponent<ObjectBase, ObjectData>
{
    ObjectBase mMediator;
    CameraFlag mCameraFlag;

    #region Bind
    public void BindComponent(ObjectBase mediator, ObjectData data)
    {
        mMediator = mediator;
    }

    public void UnbindComponent()
    {
        mMediator = null;
    }
    #endregion

    #region AttachFlag
    public void AttachCameraFlag(CameraFlag flag)
    {
        mCameraFlag = flag;
        mCameraFlag.AttachParent(this);
    }    

    public void DetachCameraFlag()
    {
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