using UnityEngine;

public class CameraBase : MonoBehaviour, IObjectComponent
{
    protected PlayerBase mPlayer;
    protected Camera mMainCamera;

    [SerializeField]
    protected Transform mCameraTracker;

    protected Vector2 mRotation = Vector2.zero;

    public void SetMediator(ObjectBase objectBase)
    {
        Init();

        if (objectBase is PlayerBase)
            mPlayer = (PlayerBase)objectBase;
        else
            Debug.Log("Cast Error on CameraBase");
    }

    protected void Init()
    {
        mMainCamera = GetComponent<Camera>();
    }

    protected void FixedUpdate()
    {
        if(mCameraTracker != null)
            RotateTracker();
    }

    protected void RotateTracker()
    {
        mCameraTracker.Rotate(Vector3.up * mRotation.x * Time.fixedDeltaTime);
    }

    #region Receive

    public void SetRotation(Vector2 rotation)
    {
        mRotation = rotation;
        Debug.Log(rotation.x);
    }


    #endregion
}