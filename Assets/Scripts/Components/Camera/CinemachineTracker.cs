using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.XR;

public class CinemachineTracker : MonoBehaviour
{
    CinemachineCamera mCinemachineCamera;
    Camera mCamera;
    private void Awake()
    {
        mCinemachineCamera = GetComponent<CinemachineCamera>();
        mCamera = GetComponent<Camera>();
    }

    #region Receive
    public void SetTrackingTarget(CameraFlag target)
    {
        CameraTarget cameraTarget = new CameraTarget();
        cameraTarget.TrackingTarget = target.transform;
        mCinemachineCamera.Target = cameraTarget;
    }
    #endregion

    #region Send
    public Camera GetCamera() => mCamera;
    #endregion
}
