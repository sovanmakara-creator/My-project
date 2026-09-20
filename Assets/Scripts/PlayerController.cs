using UnityEngine;
using UnityEngine.InputSystem;

// Attach this to the Player.
// Requires a Rigidbody component.
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("References")]
    public GameManager gameManager;

    private Vector3 currentDirection = Vector3.forward;
    private Rigidbody rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX
                        | RigidbodyConstraints.FreezeRotationY
                        | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        if (isDead) return;

<<<<<<< HEAD
        // Spacebar - New Input System
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ToggleDirection();
        }

        // Left mouse click - New Input System
        if (Mouse.current != null &&
=======
        // Desktop input: Spacebar or Left Mouse click toggles direction
        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
>>>>>>> main
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            ToggleDirection();
        }
        
    }

    void FixedUpdate()
    {
        if (isDead) return;

        Vector3 move =
            currentDirection *
            moveSpeed *
            Time.fixedDeltaTime;

        rb.MovePosition(rb.position + move);
    }

    void ToggleDirection()
    {
        if (currentDirection == Vector3.forward)
        {
            currentDirection = Vector3.right;
        }
        else
        {
            currentDirection = Vector3.forward;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        // Collect food
        if (other.CompareTag("Collectible"))
        {
            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }

            Destroy(other.gameObject);
        }

        // Hit obstacle
        else if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }
}