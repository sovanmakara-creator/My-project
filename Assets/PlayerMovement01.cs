using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed = 20f;   // Direct forward velocity
    public float sidewaysSpeed = 12f;   // Direct lateral speed
    public float jumpForce = 6f;

    private bool isGrounded = true;

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
            // D = Right (-Z), A = Left (+Z) based on your camera rotation
            if (kb.dKey.isPressed) steerZ -= sidewaysSpeed;
            if (kb.aKey.isPressed) steerZ += sidewaysSpeed;

            // Jump
            if (kb.spaceKey.isPressed && isGrounded)
            {
                currentVel.y = jumpForce;
                isGrounded = false;
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