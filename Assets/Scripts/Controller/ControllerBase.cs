using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerBase : MonoBehaviour, IObjectComponent
{
    //��Ʈ�ѷ� ���̽� -> AI, �÷��̾ ������� �������� �κ��� ���
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