using UnityEngine;
using UnityEngine.InputSystem;

// Attach this to the player Cube.
// Requires: Rigidbody component (set "Freeze Rotation" on X/Y/Z in Inspector,
// or let this script do it in Start()).
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("References")]
    public GameManager gameManager;

    private Vector3 currentDirection = Vector3.forward; // starts moving along +Z
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

        // Desktop input: Spacebar or Left Mouse click toggles direction
        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            ToggleDirection();
        }
        
    }

    void FixedUpdate()
    {
        if (isDead) return;

        Vector3 move = currentDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    void ToggleDirection()
    {
        // Switches between moving along +Z (forward) and +X (right)
        currentDirection = (currentDirection == Vector3.forward) ? Vector3.right : Vector3.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Collectible"))
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        gameManager.GameOver();
    }
}
