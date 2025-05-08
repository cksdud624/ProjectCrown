using System;
using UnityEngine;

public class ObjectChannel : ScriptableObject
{
    //ObjectBase 중재자와 연결된 컴포넌트들이 활용하는 정보
    protected eObjectState mObjectState = eObjectState.Normal;
    public eObjectState ObjectState
    {
        get { return mObjectState; }
        set
        {
            mObjectState = value;
            OnObjectStateChanged?.Invoke(value);
        }
    }
    public event Action<eObjectState> OnObjectStateChanged;


    private Transform mGlobalTransform = null;
    public event Action<Transform> OnGlobalTransformChanged;
    public Transform GlobalTransform
    {
        get { return mGlobalTransform; }
        set
        {
            mGlobalTransform = value;
            OnGlobalTransformChanged?.Invoke(value);
        }
    }

    protected Vector2 mLocalDirection = Vector2.zero;
    public event Action<Vector2> OnLocalDirectionChanged;
    public Vector2 LocalDirection
    {
        get { return mLocalDirection; }
        set
        {
            mLocalDirection = value;
            OnLocalDirectionChanged?.Invoke(value);
        }
    }

    protected eInputCommand mInputCommand = eInputCommand.None;
    public event Action<eInputCommand> OnInput;
    public eInputCommand InputCommand
    {
        get { return mInputCommand; }
        set
        {
            mInputCommand = value;
            OnInput?.Invoke(value);
        }
    }

    protected Vector2 mDragDelta = Vector2.zero;
    public event Action<Vector2> OnDrag;
    public Vector2 DragDelta
    {
        get { return mDragDelta; }
        set
        {
            mDragDelta = value;
            OnDrag?.Invoke(value);
        }
    }
}