using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
     private PlayerInputActions _testActions;
     
     private PlayerController _playerController;
    
        void Awake()
        {
            _testActions = new PlayerInputActions(); //we created an object 
            _testActions.Enable(); //we turn it on to listen to key inputs
            _playerController = gameObject.GetComponent<PlayerController>();
        }
    
        private void OnEnable()
        {
            _testActions.Player.Jump.performed += Jump;
            _testActions.Player.Move.performed += Move;
            _testActions.Player.Move.canceled += Move; //note tht this function allows for the player to cancel the imput of the movemnt 
        }
    
        private void OnDisable()
        {
            _testActions.Player.Jump.performed -= Jump;
            _testActions.Player.Move.performed -= Move;
        }
    
        void Jump(InputAction.CallbackContext ctx)
        {
            Debug.Log("Jump");
        }

        void Move(InputAction.CallbackContext ctx)
        {
            //call the move function in the player controller
            Debug.Log("move");
            _playerController.Move(ctx.ReadValue<Vector2>());
        }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
