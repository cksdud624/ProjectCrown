using System;
using UnityEngine;
using UnityEngine.InputSystem;
using ControllerRelated;

public class ControllerPlayer : ControllerBase
{
    PlayerInput MainInput;

    public event Action<InputInfo<Vector2>> InputEventVector2;
    public event Action<InputInfo<int>> InputEventInt;

    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        MainInput = GetComponent<PlayerInput>();
        BindInput();

        IsPlayer = true;
    }

    #region Bind
    private void BindInput()
    {
        if (MainInput != null)
        {
            MainInput.actions["Move"].performed += OnMove;
            MainInput.actions["Move"].canceled += OnMove;

            MainInput.actions["MouseMove"].performed += OnDragMove;
            MainInput.actions["MouseMove"].canceled += OnDragMove;

            MainInput.actions["LeftClick"].performed += OnLeftClick;
            MainInput.actions["LeftClick"].canceled += OnLeftClick;
            
            MainInput.actions["RightClick"].performed += OnRightClick;
            MainInput.actions["RightClick"].canceled += OnRightClick;
        }
        else
            Debug.Log("Player Input is null(bind)");
    }

    private void UnbindInput()
    {
        if (MainInput != null)
        {
            MainInput.actions["Move"].performed -= OnMove;
            MainInput.actions["Move"].canceled -= OnMove;

            MainInput.actions["MouseMove"].performed -= OnDragMove;
            MainInput.actions["MouseMove"].canceled -= OnDragMove;

            MainInput.actions["LeftClick"].performed -= OnLeftClick;
            MainInput.actions["LeftClick"].canceled -= OnLeftClick;

            MainInput.actions["RightClick"].performed -= OnRightClick;
            MainInput.actions["RightClick"].canceled -= OnRightClick;

            MainInput = null;
        }
        else
            Debug.Log("Player Input is null(Unbind)");
    }
    #endregion

    protected void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        mCharacter.SetMove(moveInput);
    }

    protected void OnDragMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        mCharacter.SetDragMove(moveInput);
    }

    protected void OnLeftClick(InputAction.CallbackContext context)
    {
        int clickInput = Mathf.RoundToInt(context.ReadValue<float>());
        mCharacter.SetClick(clickInput);
    }

    protected void OnRightClick(InputAction.CallbackContext context)
    {
        int clickInput = Mathf.RoundToInt(context.ReadValue<float>()) + 2;
        mCharacter.SetClick(clickInput);
    }

    protected void OnDestroy()
    {
        UnbindInput();
    }
}
