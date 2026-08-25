using UnityEngine;

public class Camera_scrolling : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset between the camera and the player 3 values for x, y, and z
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = player.position + offset; // Update the camera's position to follow the player with the specified offset
    }
}
