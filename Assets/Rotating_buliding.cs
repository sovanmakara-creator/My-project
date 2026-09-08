using UnityEngine;

public class Rotating_buliding : MonoBehaviour
{
 [Header("Movement Settings")]
    public float speed = 2f;
    public float distance = 3f;

    [Header("Timing")]
    public bool randomizeStart = true; // Check this to automatically desync them
    public float timeOffset = 0f;      // Use this if you want to manually type a delay

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        // If randomizeStart is checked, give this specific cube a random time shift
        if (randomizeStart)
        {
            timeOffset = Random.Range(0f, 10f);
        }
    }

    void Update()
    {
        // We add the timeOffset to Time.time so each cube reads a different point in the Sine wave
        float offset = Mathf.Sin((Time.time + timeOffset) * speed) * distance;
        
        transform.position = startPosition + (Vector3.right * offset);
    }
}
