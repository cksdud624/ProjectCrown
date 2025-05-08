using System;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //모든 오브젝트 들이 공통으로 가지는 클래스
    protected RigidbodyBase mRigidbodyBase;
    protected InputBase mInputBase;
    protected CameraBase mCameraBase;

    //데이터
    ObjectData mObjectData;
    protected ObjectChannel mObjectChannel;

    #region Bind
    virtual public void Bind(ObjectData data)
    {
        mObjectData = data;
        InstantiateChannel();

        mRigidbodyBase = GetComponent<RigidbodyBase>();
        mRigidbodyBase.Bind(this, mObjectData, mObjectChannel);

        mInputBase = GetComponent<InputBase>();
        mInputBase.Bind(this, mObjectData, mObjectChannel);

        mCameraBase = GetComponent<CameraBase>();
        mCameraBase.Bind(this, mObjectData, mObjectChannel);
    }

    virtual public void Unbind()
    {
        mObjectData = null;
        mObjectChannel = null;

        mRigidbodyBase.Unbind();
        mRigidbodyBase = null;

        mInputBase.Unbind();
        mInputBase = null;

        mCameraBase.Unbind();
        mCameraBase = null;
    }
    #endregion

    #region Instantiate
    virtual protected void InstantiateChannel()
    {
        mObjectChannel = ScriptableObject.CreateInstance<ObjectChannel>();
    }
    #endregion

    #region Receive
    //External
    virtual public void AttachCameraFlag(CameraFlag flag) => mCameraBase.AttachCameraFlag(flag);

    virtual public void DetachCameraFlag() => mCameraBase.DetachCameraFlag();
    #endregion
}
