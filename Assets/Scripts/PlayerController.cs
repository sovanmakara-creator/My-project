
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("References")]
    public GameManager gameManager;

    [Header("Start UI")]
    public GameObject startInstructionText;

    private Vector3 currentDirection = Vector3.forward;
    private Rigidbody rb;

    private bool hasGameStarted = false;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ;

        currentDirection = Vector3.forward;

        hasGameStarted = false;
        isDead = false;

        if (startInstructionText != null)
        {
            startInstructionText.SetActive(true);
        }
    }

    void Update()
    {
        if (isDead) return;

        if (gameManager != null && gameManager.IsGameFinished)
            return;

        bool spacePressed =
            Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame;

        bool mouseClicked =
            Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame;

        // First Space press starts the game.
        if (!hasGameStarted)
        {
            if (spacePressed && Time.timeScale > 0f)
            {
                hasGameStarted = true;

                if (startInstructionText != null)
                {
                    startInstructionText.SetActive(false);
                }
            }

            return;
        }

        // Do not turn while the game is paused.
        if (Time.timeScale == 0f)
            return;

        // Once the game has started, Space or click changes direction.
        if (spacePressed || mouseClicked)
        {
            ToggleDirection();
        }
    }

    void FixedUpdate()
    {
        if (!hasGameStarted || isDead)
            return;

        if (gameManager != null && gameManager.IsGameFinished)
            return;

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
        if (!hasGameStarted || isDead)
            return;

        if (gameManager != null && gameManager.IsGameFinished)
            return;

        Debug.Log(
            "Trigger collided with: " +
            other.gameObject.name +
            " | Tag: " +
            other.tag
        );

        // Collect food.
        if (other.CompareTag("Collectible"))
        {
            // Keep your existing collectible sound.
            if (MusicManager.instance != null)
            {
                MusicManager.instance.PlayCollectingCoinSound();
            }

            Destroy(other.gameObject);

            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }
        }

        // Hit obstacle.
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