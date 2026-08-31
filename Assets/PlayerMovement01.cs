using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
<<<<<<< HEAD
    public Rigidbody rb; // Reference to the Rigidbody component
    public float forwardForce = 200f; // Force applied to move the player forward
    public float sidewaysForce = 10f; // Force applied to move the player sideways
    public float jumpForce = 5f; // Force applied to make the player jump
    public float BackwardForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isGrounded = true; // Flag to check if the player is on the ground
  
=======
    public Rigidbody rb;
    public float forwardSpeed = 20f;   // Direct forward velocity
    public float sidewaysSpeed = 12f;   // Direct lateral speed
    public float jumpForce = 6f;

    private bool isGrounded = true;

>>>>>>> e301eabe665b877fff22292c86d23af1cfb0fc23
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Set forward speed directly on X axis, preserve current Y (gravity/jump) and Z
        Vector3 currentVel = rb.linearVelocity; // Use rb.velocity if on Unity 2022 or older
        currentVel.x = forwardSpeed;

        float steerZ = 0f;
        Keyboard kb = Keyboard.current;

        if (kb != null)
        {
<<<<<<< HEAD
            rb.AddForce(-sidewaysForce, 0, 0, ForceMode.VelocityChange); 
        }
        if(kb.wKey.isPressed)
        {
            rb.AddForce(0, 0,sidewaysForce, ForceMode.VelocityChange);
        }
        if(kb.sKey.isPressed){
            rb.AddForce(0, 0, -BackwardForce, ForceMode.VelocityChange);
        }
        if (kb.spaceKey.isPressed)
        {
            if(isGrounded){
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            isGrounded = false;
=======
            // D = Right (-Z), A = Left (+Z) based on your camera rotation
            if (kb.dKey.isPressed) steerZ -= sidewaysSpeed;
            if (kb.aKey.isPressed) steerZ += sidewaysSpeed;

            // Jump
            if (kb.spaceKey.isPressed && isGrounded)
            {
                currentVel.y = jumpForce;
                isGrounded = false;
>>>>>>> e301eabe665b877fff22292c86d23af1cfb0fc23
            }
        }

        currentVel.z = steerZ;
        rb.linearVelocity = currentVel; // Use rb.velocity if on Unity 2022 or older
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}