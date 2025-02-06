using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerBase : MonoBehaviour, IObjectComponent
{
    //컨트롤러 베이스 -> AI, 플레이어에 상관없이 공통적인 부분을 담당
    public bool IsPlayer { get; protected set; }

    protected CharacterBase character;

    public void InitializeComponent()
    {
    }

    public void SetMediator(ObjectBase objectBase)
    {
        if (objectBase is CharacterBase)
        {
            character = objectBase as CharacterBase;
        }
        else
            Debug.Log("Cast Error on ControllerBase");
    }
}