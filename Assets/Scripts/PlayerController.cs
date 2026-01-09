using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Rigidbody2D RB;
    public PhysicsMaterial2D PhysicsMat;

    public float MovementSpeed;

    public void Move(Vector2 Inputdirection)
    {
        Debug.Log(Inputdirection);
        RB.linearVelocity =  Inputdirection * MovementSpeed;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody2D>();
        }

        RB.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        
        // RB.sharedMaterial = PhysicsMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
