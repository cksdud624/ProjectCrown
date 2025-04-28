using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //모든 오브젝트 들이 공통으로 가지는 클래스
    RigidbodyBase mRigidbodyBase;
    InputBase mInputBase;
    CameraBase mCameraBase;

    #region Bind
    virtual public void BindComponent()
    {
        mRigidbodyBase = GetComponent<RigidbodyBase>();
        mRigidbodyBase.BindComponent(this);

        mInputBase = GetComponent<InputBase>();
        mInputBase.BindComponent(this);

        mCameraBase = GetComponent<CameraBase>();
        mCameraBase.BindComponent(this);
    }

    virtual public void UnbindComponent()
    {
        mRigidbodyBase.UnbindComponent();
        mRigidbodyBase = null;

        mInputBase.UnbindComponent();
        mInputBase = null;

        mCameraBase.UnbindComponent();
        mCameraBase = null;
    }
    #endregion

    #region Receive
    //Rigidbody
    virtual public void SetDirection(Vector2 direction)
    {
        mRigidbodyBase.SetDirection(direction);
    }

    //Camera
    virtual public void AttachCameraFlag(CameraFlag flag)
    {
        mCameraBase.AttachCameraFlag(flag);
    }

    virtual public void DetachCameraFlag()
    {
        mCameraBase.DetachCameraFlag();
    }

    virtual public void Rotate(Vector2 delta)
    {
        mCameraBase.Rotate(delta);
    }

    //Input
    virtual public void ProcessInputCommand(eInputCommand inputCommand)
    {
    }
    #endregion

    #region Send
    virtual public Vector3 GetForward()
    {
        return mCameraBase.GetForward();
    }

    #endregion

}
