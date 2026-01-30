using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInputActions _playerInputActions;

    public System.Action OnJump;

    public System.Action<float> OnMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    void OnEnable()
    {
        //To listen for when the player presses the jump and movement keys
        _playerInputActions.Player.Jump.performed += OnJumpPressed;
        _playerInputActions.Player.Move.performed += OnMovement;
        //To listen and prevent the continuation of OnMovement during fixed update
        _playerInputActions.Player.Move.canceled += OnMovement;
    }

    void OnDisable()
    {
        _playerInputActions.Player.Jump.performed -= OnJumpPressed;
        _playerInputActions.Player.Move.performed -= OnMovement;
    }

    void OnJumpPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        OnJump?.Invoke();
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        //Debug.Log("move");
        OnMove?.Invoke(context.ReadValue<float>());
    }
    
}
