using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody component
    public float forwardForce = 200f; // Force applied to move the player forward
    public float sidewaysForce = 10f; // Force applied to move the player sideways
    public float jumpForce = 5f; // Force applied to make the player jump
    public float stoppingFriction = 2f; // How fast the player slows down at the end

    bool isGrounded = true; // Flag to check if the player is on the ground
    bool hasFinished = false; // Flag to check if the player hit the finish line
  
    void Start()
    {
        Debug.Log("Game Started!"); 
    }

    void FixedUpdate() 
    {
        // 1. If the player has crossed the finish line, slow them down and ignore inputs
        if (hasFinished)
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * stoppingFriction);
            return; // This stops the rest of the code in FixedUpdate from running!
        }

        // 2. Normal movement (Only runs if hasFinished is false)
        rb.AddForce(0, 0, forwardForce); 
        Keyboard kb = Keyboard.current; 
        
        // 3. Make sure the keyboard actually exists so we don't crash
        if (kb != null)
        {
            // Move Right
            if (kb.dKey.isPressed)
            {
                rb.AddForce(sidewaysForce, 0, 0, ForceMode.VelocityChange); 
            }

            // Move Left
            if (kb.aKey.isPressed)
            {
                rb.AddForce(-sidewaysForce, 0, 0, ForceMode.VelocityChange); 
            }

            // Move Forward (Extra)
            if(kb.wKey.isPressed)
            {
                rb.AddForce(0, 0, sidewaysForce, ForceMode.VelocityChange);
            }

            // Jump
            if (kb.spaceKey.isPressed)
            {
                if(isGrounded)
                {
                    rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
                    isGrounded = false;
                }                 
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finished"))
        {
            Debug.Log("Hit the finish line! Disabling controls and slowing down...");
            hasFinished = true; // Triggers the stopping logic in FixedUpdate
        }
    }
}