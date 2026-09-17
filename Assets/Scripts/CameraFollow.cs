using UnityEngine;

// Attach this to the Main Camera. Set an isometric-style offset so the
// camera trails and looks down at the player, matching the reference screenshots.
public class CameraFollow : MonoBehaviour
{
    public Transform target; // drag the Player cube here in the Inspector

    [Header("Offset & Smoothing")]
    public Vector3 offset = new Vector3(-6f, 8f, -6f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1f);
    }
}
