using UnityEngine;

// Attach to the diamond/collectible prefab, alongside a trigger Collider
// (check "Is Trigger" in the Inspector) and the tag "Collectible".
public class Collectible : MonoBehaviour
{
    public float rotateSpeed = 90f;
    public float floatAmplitude = 0.2f;
    public float floatSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
