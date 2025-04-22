using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputPlayerBase : InputBase
{
    protected PlayerInput mPlayerInput;

    #region Bind
    public override void BindComponent(ObjectBase mediator)
    {
        base.BindComponent(mediator);
        mPlayerInput = GetComponent<PlayerInput>();
        BindInputEvent();
    }

    public override void UnbindComponent()
    {
        base.UnbindComponent();
        UnbindInputEvent();
        mPlayerInput = null;
    }

    protected void BindInputEvent()
    {
        mPlayerInput.actions["Move"].performed += Move;
        mPlayerInput.actions["Move"].canceled += Stop;
        mPlayerInput.actions["Rotate"].performed += Rotate;
    }

    protected void UnbindInputEvent()
    {
        mPlayerInput.actions["Move"].performed -= Move;
        mPlayerInput.actions["Move"].canceled -= Stop;
        mPlayerInput.actions["Rotate"].performed -= Rotate;
    }
    #endregion

    #region InputEvent
    protected void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        Move(direction);
    }

    protected void Stop(InputAction.CallbackContext context)
    {
        Stop();
    }

    protected void Rotate(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        //x : аб, ©Л y : ╩С го
        mMediator.Rotate(delta);
    }
    #endregion
}