using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RigidbodyBase : MonoBehaviour, IObjectComponent
{
    protected ObjectBase mObject;

    Rigidbody mMainRigidbody;

    public bool IsMoving { get; protected set; }
    protected bool mIsPlayer = false;

    protected Vector2 mDirection = Vector2.zero;

    protected float mMoveSpeed = 1;
    protected bool mIsRestrict = false;

    public void SetMediator(ObjectBase objectBase)
    {
        mObject = objectBase;

        Init();
    }

    protected void Init()
    {
        mMainRigidbody = GetComponent<Rigidbody>();
        mMoveSpeed = mObject.GetMoveSpeed();

        if (mObject is PlayerBase)
            mIsPlayer = true;
    }

    protected void FixedUpdate()
    {
        if (mIsPlayer)
        {
            MovePlayer();
        }
    }

    protected void MovePlayer()
    {
        if (mMainRigidbody == null)
            return;

        float terminal = mMainRigidbody.linearVelocity.y;

        if (mIsRestrict)
        {
            mMainRigidbody.linearVelocity = new Vector3(0, terminal, 0);
            return;
        }

        Vector3 forwardDirection = ((PlayerBase)mObject).GetCameraDirection();
        forwardDirection.y = 0;
        Vector3 rightDirection = Vector3.Cross(Vector3.up, forwardDirection);

        Vector3 moveDirection = forwardDirection * mDirection.y + rightDirection * mDirection.x;

        mMainRigidbody.linearVelocity = new Vector3(moveDirection.x, terminal, moveDirection.z);
    }

    #region Receive
    public void SetDirection(Vector2 direction)
    {
        mDirection = direction;
        if (direction.magnitude < 0.05)
            IsMoving = false;
        else
            IsMoving = true;
    }

    public void RestrictMove(bool isRestrict)
    {
        mIsRestrict = isRestrict;
    }
    #endregion
}
