using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Collision : MonoBehaviour
{
    public PlayerMovement01 movement;
    [HideInInspector] public Transform player; // Hidden in inspector because it assigns automatically now
    public GameObject GameOverPanel;

    void Start()
    {
        // Automatically assigns the player transform so you don't get the error
        player = GetComponent<Transform>(); 
        
        // Optional: If movement is on the same object, we can auto-assign it too
        if (movement == null) 
        {
            movement = GetComponent<PlayerMovement01>();
        }
    }

    void Update()
    {
        if (player.position.y < -1f)
        {
            MusicManager.instance.PlayGameOverSound();
            StartCoroutine(ShowGameOverAfterDelay());
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {   
            MusicManager.instance.PlayGameOverSound();
            Debug.Log("We hit an obstacle");
            StartCoroutine(ShowGameOverAfterDelay());
        }
    }

    IEnumerator ShowGameOverAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);

        // Safety check to prevent a different error if the panel isn't assigned
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
        
        if (movement != null)
        {
            movement.enabled = false;  
        }
    }
}
