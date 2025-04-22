using UnityEngine;

public class CameraFlag : MonoBehaviour
{
    //ī�޶� ���� ȸ���� ���� �÷���
    CameraBase mParent;
    eCameraState mCameraState = eCameraState.Playable;
    OptionData mOptionData;

    #region Attach
    public void AttachParent(CameraBase parent)
    {
        mParent = parent;
        transform.SetParent(mParent.transform);
    }

    public void DetachParent()
    {
        transform.SetParent(null);
    }
    #endregion

    #region Receive
    public void Rotate(Vector2 delta)
    {
        if(mOptionData == null)
            mOptionData = OptionManager.Instance.OptionData;

        switch (mCameraState)
        {
            case eCameraState.Playable:
                float rotateX = delta.x;
                transform.Rotate(new Vector3(0, rotateX * mOptionData.Sensitivity, 0));
                break;
        }
    }
    #endregion
}
