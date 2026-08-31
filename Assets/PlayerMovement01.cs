using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody component
    public float forwardForce = 200f; // Force applied to move the player forward
    public float sidewaysForce = 10f; // Force applied to move the player sideways
    public float jumpForce = 5f; // Force applied to make the player jump
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isGrounded = true; // Flag to check if the player is on the ground
  
    void Start()
    {
        Debug.Log("Game Started!"); 
    }
    // Update is called once per frame
    void FixedUpdate() 
    {
        rb.AddForce(0,0,forwardForce);// 1. Add a forward force to the player every frame
        Keyboard kb = Keyboard.current; 
        

    // 2. Make sure the keyboard actually exists so we don't crash
    if (kb != null)
    {
        // 3. Move Right
        if (kb.dKey.isPressed)
        {
            // Notice there is no Time.deltaTime here! Just raw, powerful physics force.
            rb.AddForce(sidewaysForce, 0, 0, ForceMode.VelocityChange); 
        }

        // 4. Move Left
        if (kb.aKey.isPressed)
        {
            rb.AddForce(-sidewaysForce, 0, 0, ForceMode.VelocityChange); 
        }
        if(kb.wKey.isPressed)
        {
            rb.AddForce(0, 0,sidewaysForce, ForceMode.VelocityChange);
        }
        if (kb.spaceKey.isPressed)
        {
            if(isGrounded){
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            isGrounded = false;
            }
                 
        }
        
        // if(kb.sKey.isPressed)
        // {
        //     rb.AddForce(0, 0,-sidewaysForce, ForceMode.VelocityChange);
        // }
    }
            
        
    
    
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set the grounded flag to true
        }
    }


}
