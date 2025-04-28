using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputPlayerBase : InputBase
{
    protected PlayerInput mPlayerInput;

    #region Bind
    public override void BindComponent(ObjectBase mediator, ObjectData data)
    {
        base.BindComponent(mediator, data);
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
        mPlayerInput.actions["LeftClick"].performed += FirstInput;
        mPlayerInput.actions["LeftClick"].canceled += FirstInput;
        mPlayerInput.actions["RightClick"].performed += SecondInput;
        mPlayerInput.actions["RightClick"].canceled += SecondInput;
    }

    protected void UnbindInputEvent()
    {
        mPlayerInput.actions["Move"].performed -= Move;
        mPlayerInput.actions["Move"].canceled -= Stop;
        mPlayerInput.actions["Rotate"].performed -= Rotate;
        mPlayerInput.actions["LeftClick"].performed -= FirstInput;
        mPlayerInput.actions["RightClick"].performed -= SecondInput;
        mPlayerInput.actions["LeftClick"].canceled -= FirstInput;
        mPlayerInput.actions["RightClick"].canceled -= SecondInput;
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
        Rotate(delta);
    }

    protected void FirstInput(InputAction.CallbackContext context)
    {
        int input = (int)context.ReadValue<float>();
        eInputCommand command;
        if (input == 0)
            command = eInputCommand.FirstRelease;
        else
            command = eInputCommand.FirstPress;
        Input(command);
    }

    protected void SecondInput(InputAction.CallbackContext context)
    {
        int input = (int)context.ReadValue<float>();
        eInputCommand command;
        if (input == 0)
            command = eInputCommand.SecondRelease;
        else
            command = eInputCommand.SecondPress;
        Input(command);
    }
    #endregion
}