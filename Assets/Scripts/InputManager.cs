using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInputActions _playerInputActions;
    public System.Action OnJump;
    public System.Action<float> OnMove;
    
    public GameManager gameManager;
    
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
        _playerInputActions.Player.Pause.performed += OnPause;
        //To listen and prevent the continuation of OnMovement during fixed update
        _playerInputActions.Player.Move.canceled += OnMovement;
        gameManager = FindFirstObjectByType<GameManager>();
        
    }

    void OnDisable()
    {
        _playerInputActions.Player.Jump.performed -= OnJumpPressed;
        _playerInputActions.Player.Move.performed -= OnMovement;
    }

    void OnJumpPressed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    void OnMovement(InputAction.CallbackContext context)
    { 
        OnMove?.Invoke(context.ReadValue<float>());
    }

    void OnPause(InputAction.CallbackContext context) //imput action paused will call the pause function
    {
        Debug.unityLogger.Log("Game Pause");
        gameManager.Pause();
    }
    
}
