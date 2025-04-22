using UnityEngine;

public class InputBase : MonoBehaviour, IObjectComponent<ObjectBase>
{
    protected ObjectBase mMediator;

    #region Bind
    virtual public void BindComponent(ObjectBase mediator)
    {
        mMediator = mediator;
    }

    virtual public void UnbindComponent()
    {
        mMediator = null;
    }
    #endregion

    #region Send
    protected void Move(Vector2 direction)
    {
        mMediator.SetDirection(direction);
    }

    protected void Stop()
    {
        mMediator.SetDirection(Vector2.zero);
    }

    protected void Rotate(Vector2 direction)
    {

    }
    #endregion
}