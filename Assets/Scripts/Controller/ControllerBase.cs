using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerBase : MonoBehaviour, IObjectComponent
{
    //��Ʈ�ѷ� ���̽� -> AI, �÷��̾ ������� �������� �κ��� ���
    public bool IsPlayer { get; protected set; }

    protected CharacterBase mCharacter;

    public void InitializeComponent()
    {
    }

    public void SetMediator(ObjectBase objectBase)
    {
        if (objectBase is CharacterBase)
        {
            mCharacter = objectBase as CharacterBase;
        }
        else
            Debug.Log("Cast Error on ControllerBase");
    }
}