using RPGCharacterAnims.Lookups;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //오브젝트 베이스 : 체력, 방어력을 가질 수 있는 모든 오브젝트들을 포함
    [SerializeField]
    protected ObjectStat ObjectStatus;

    public int Hp { get; set; }
    public int Defense { get; set; }

    protected RigidbodyBase MainRigidbody;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        MainRigidbody = GetComponent<RigidbodyBase>();
        MainRigidbody.SetMediator(this);
    }

    #region Status
    public int GetHp() => ObjectStatus.Hp;
    public int GetDefense() => ObjectStatus.Defense;
    public float GetMoveSpeed() => ObjectStatus.MoveSpeed;
    #endregion

    #region Controller
    public void SetMove(Vector2 move)
    {
        MainRigidbody.SetDirection(move);
    }

    public void SetClick(int click)
    {
        MainRigidbody.SetInput(click);
    }
    #endregion

    #region Rigidbody
    public bool IsMoving() => MainRigidbody.IsMoving;
    #endregion

}
