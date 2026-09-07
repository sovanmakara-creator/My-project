using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement01 : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 10f;
    public float jumpForce = 6f;
    public float stoppingFriction = 2f;
    public float sidewaysSpeed = 12f;

    private bool isGrounded = true;
    private bool hasFinished = false;

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (hasFinished)
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * stoppingFriction);
            return;
        }

        rb.AddForce(0f, 0f, forwardForce);

        Keyboard kb = Keyboard.current;
        if (kb == null)
            return;

        if (kb.dKey.isPressed)
            rb.AddForce(sidewaysForce, 0f, 0f, ForceMode.VelocityChange);

        if (kb.aKey.isPressed)
            rb.AddForce(-sidewaysForce, 0f, 0f, ForceMode.VelocityChange);

        if (kb.wKey.isPressed)
            rb.AddForce(0f, 0f, sidewaysForce, ForceMode.VelocityChange);

        if (kb.sKey.isPressed)
            rb.AddForce(0f, 0f, -sidewaysForce, ForceMode.VelocityChange);

        if (kb.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finished"))
        {
            Debug.Log("Hit the finish line! Disabling controls and slowing down...");
            hasFinished = true;
        }
    }
}

