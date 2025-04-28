using UnityEngine;
using XNode;

public class TestCenter : MonoBehaviour
{
    public CharacterBase player;
    public CinemachineTracker tracker;
    public CameraFlag flag;
    public ComboNodeGraph testGraph;

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
