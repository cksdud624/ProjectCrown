using RPGCharacterAnims.Lookups;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //오브젝트 베이스 : 체력, 방어력을 가질 수 있는 모든 오브젝트들을 포함
    [SerializeField]
    protected ObjectStat mObjectStatus;

    public int Hp { get; set; }
    public int Defense { get; set; }

    protected RigidbodyBase mMainRigidbody;

    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        mMainRigidbody = GetComponent<RigidbodyBase>();
        mMainRigidbody.SetMediator(this);
    }

    #region Status
    public int GetHp() => mObjectStatus.Hp;
    public int GetDefense() => mObjectStatus.Defense;
    public float GetMoveSpeed() => mObjectStatus.MoveSpeed;
    #endregion

    #region Controller
    public void SetMove(Vector2 move)
    {
        mMainRigidbody.SetDirection(move);
    }

    public virtual void SetDragMove(Vector2 move)
    {

    }

    public void SetClick(int click)
    {
        mMainRigidbody.SetInput(click);
    }
    #endregion

    #region Rigidbody
    public bool IsMoving() => mMainRigidbody.IsMoving;
    #endregion

}
