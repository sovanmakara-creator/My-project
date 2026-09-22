using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Collision : MonoBehaviour
{
    public PlayerMovement01 movement;
    public Transform player;
    public GameObject GameOverPanel;

    // FIX 1: Changed "Updated" to "Update" so Unity automatically calls it every frame
    void Update()
    {
        // FIX 2: Changed "player.Transform.position" to "player.position" 
        if (player.position.y < -1f)
        {
            
            StartCoroutine(ShowGameOverAfterDelay());
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            StartCoroutine(ShowGameOverAfterDelay());
        }
    }

    IEnumerator ShowGameOverAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);

        GameOverPanel.SetActive(true);
        movement.enabled = false;  
    }
}
