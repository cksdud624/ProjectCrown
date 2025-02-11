using UnityEngine;

public class PlayerBase : CharacterBase
{
    protected CameraBase mMainCamera;
    protected PlayerStat mPlayerStat;

    protected override void Init()
    {
        base.Init();

        for (int i = 0; i < transform.childCount; i++)
        {
            CameraBase tempCameraBase = transform.GetChild(i).GetComponent<CameraBase>();
            if(tempCameraBase != null)
            {
                mMainCamera = tempCameraBase;
                break;
            }
        }
        mMainCamera.SetMediator(this);

        if(mCharacterStatus is PlayerStat)
            mPlayerStat = (PlayerStat)mCharacterStatus;
        else
            Debug.Log("Cast Error On PlayerStat");
    }

    public override void SetDragMove(Vector2 move)
    {
        mMainCamera.SetRotation(move);
    }

    #region Camera
    public Vector3 GetCameraDirection() => mMainCamera.transform.forward;
    #endregion
}