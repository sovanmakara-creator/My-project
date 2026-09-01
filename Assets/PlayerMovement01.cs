using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody component
    public float forwardSpeed = 20f;   // Direct forward velocity
    public float sidewaysSpeed = 12f;   // Direct lateral speed
    public float jumpForce = 6f;       // Force applied to make the player jump

    private bool isGrounded = true;    // Flag to check if the player is on the ground

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get current velocity and preserve gravity
        Vector3 currentVel = rb.linearVelocity;
        currentVel.x = forwardSpeed;

        float steerZ = 0f;
        Keyboard kb = Keyboard.current;

        if (kb != null)
        {
            // D = Right, A = Left
            if (kb.dKey.isPressed) 
                steerZ -= sidewaysSpeed;
            if (kb.aKey.isPressed) 
                steerZ += sidewaysSpeed;

            // W = Forward on Z axis
            if (kb.wKey.isPressed)
            {
                rb.AddForce(0, 0, sidewaysSpeed, ForceMode.VelocityChange);
            }

            // S = Backward on Z axis
            if (kb.sKey.isPressed)
            {
                rb.AddForce(0, 0, -sidewaysSpeed, ForceMode.VelocityChange);
            }

            // Jump
            if (kb.spaceKey.isPressed && isGrounded)
            {
                currentVel.y = jumpForce;
                isGrounded = false;
            }
        }

        currentVel.z = steerZ;
        rb.linearVelocity = currentVel;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
