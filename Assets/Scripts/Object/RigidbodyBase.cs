using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RigidbodyBase : MonoBehaviour, IObjectComponent
{
    protected ObjectBase objectBase;

    Rigidbody MainRigidbody;

    protected Vector2 direction = Vector2.zero;
    public bool IsMoving { get; protected set; }

    protected float MoveSpeed = 1;

    public void SetMediator(ObjectBase objectBase)
    {
        this.objectBase = objectBase;
        Init();
    }

    protected void Init()
    {
        MainRigidbody = GetComponent<Rigidbody>();
        MoveSpeed = objectBase.GetMoveSpeed();
    }

    protected void FixedUpdate()
    {
        if(MainRigidbody)
        {
            float terminal = MainRigidbody.linearVelocity.y;

            Vector3 localDirection = new Vector3(direction.x, 0, direction.y);
            Vector3 worldDirection = transform.TransformDirection(localDirection);

            MainRigidbody.linearVelocity = new Vector3(worldDirection.x, terminal, worldDirection.z);
            if (direction != new Vector2(0, 0))
            {
                Quaternion targetRotation = Quaternion.LookRotation(localDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15);
            }
        }
    }

    #region Receive
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        if (direction.magnitude < 0.05)
            IsMoving = false;
        else
            IsMoving = true;
    }

    public void SetInput(int input)
    {
        Debug.Log(input);
    }
    #endregion
}
