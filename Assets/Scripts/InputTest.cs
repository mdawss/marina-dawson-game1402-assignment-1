using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
     private PlayerInputActions _testActions;
    
        void Awake()
        {
            _testActions = new PlayerInputActions(); //we created an object 
            _testActions.Enable(); //we turn it on to listen to key inputs
        }
    
        private void OnEnable()
        {
            _testActions.Player.Jump.performed += Jump;
        }
    
        private void OnDisable()
        {
            _testActions.Player.Jump.performed -= Jump;
        }
    
        void Jump(InputAction.CallbackContext ctx)
        {
            Debug.Log("Jump");
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
