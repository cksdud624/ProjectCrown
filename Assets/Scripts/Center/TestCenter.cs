using UnityEngine;
using XNode;

public class TestCenter : MonoBehaviour
{
    public CharacterBase player;
    public CinemachineTracker tracker;
    public CameraFlag flag;
    public CharacterData characterData;

    private void Awake()
    {
        InitGame();
    }

    private void InitGame()
    {
    }

    private void Start()
    {
        player.Bind(characterData);
        tracker.SetTrackingTarget(flag);
        player.AttachCameraFlag(flag);
    }
}