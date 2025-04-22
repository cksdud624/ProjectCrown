using UnityEngine;

public class TestCenter : MonoBehaviour
{
    public CharacterBase player;
    public CinemachineTracker tracker;
    public CameraFlag flag;

    private void Awake()
    {
        InitGame();
    }

    private void InitGame()
    {
    }

    private void Start()
    {
        player.BindComponent();
        tracker.SetTrackingTarget(flag);
        player.AttachCameraFlag(flag);
    }
}
