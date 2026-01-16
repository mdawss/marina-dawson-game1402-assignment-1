using System;
using System.Collections;
using UnityEngine;

public class PlayerControllerExample : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;
    
    [SerializeField] private InputManager inputManager;

    [Header("Ground Check")] 
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private Vector2 startPointOffset;

    [SerializeField] private float groundCheckDistance;

    private float _moveInput = 0;
    private float _coyoteTimer = 0f;
    private Rigidbody2D _playerRB;

    private bool _isOnGround;
    private bool _canDoubleJump;

    [SerializeField] private float coyoteTime;
    
    void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        inputManager.OnJump += HandleJumpInput;
        inputManager.OnMove += HandleMoveInput;
    }
    void OnDisable()
    {
        inputManager.OnJump -= HandleJumpInput;
        inputManager.OnMove -= HandleMoveInput;
    }

   void HandleJumpInput()
    {
        //apply the jump force
        if (_playerRB == null) return;
        
        if (_isOnGround || coyoteTime < _coyoteTimer) //checking if I am on the ground or if  I can utilize coyote time
        {
            _playerRB.AddForceY(jumpForce, ForceMode2D.Impulse);
            _canDoubleJump = true;
        }
        else if (_canDoubleJump)
        {
            _playerRB.AddForceY(jumpForce, ForceMode2D.Impulse);
            _canDoubleJump = false;
        }
        _coyoteTimer = 0; //reset the coyote timer back to 0 so it can be utilized again
    }
   
    void HandleMoveInput(float value)
    {
        Debug.Log("MoveInput");
        _moveInput = value;
    }

    void FixedUpdate()
    {
        GroundCheck();
        HandleMovement();
        HandleCoyoteTime();
    }

    void HandleCoyoteTime()
    {
        if(_isOnGround) return;
        
        _coyoteTimer += Time.fixedDeltaTime;
    }

    void HandleMovement()
    {
        if (_playerRB == null) return;

        _playerRB.linearVelocityX = _moveInput * moveSpeed ;
    }

    void GroundCheck()
    {
        _isOnGround = Physics2D.Raycast((Vector2)transform.position + startPointOffset, Vector2.down, groundCheckDistance, groundLayer);
    }
    
    private void OnDrawGizmos()
    {
        Debug.DrawLine((Vector2)transform.position + startPointOffset, (Vector2) transform.position + startPointOffset + Vector2.down * groundCheckDistance, _isOnGround? Color.green : Color.red );
    }
}
