using UnityEngine;

public class InputBase : MonoBehaviour, IObjectComponent<ObjectBase, ObjectData, ObjectChannel>
{
    protected ObjectBase mMediator;
    protected ObjectData mObjectData;
    protected ObjectChannel mObjectChannel;

    #region Bind
    virtual public void Bind(ObjectBase mediator, ObjectData data, ObjectChannel channel)
    {
        mMediator = mediator;
        mObjectData = data;
        mObjectChannel = channel;
    }

    virtual public void Unbind()
    {
        mMediator = null;
        mObjectData = null;
        mObjectChannel = null;
    }
    #endregion

    #region Send
    protected void Move(Vector2 direction) => mObjectChannel.LocalDirection = direction;

    protected void Stop() => mObjectChannel.LocalDirection = Vector2.zero;

    protected void Rotate(Vector2 delta) => mObjectChannel.DragDelta = delta;

    protected void Input(eInputCommand inputCommand) => mObjectChannel.InputCommand = inputCommand;
    #endregion
}