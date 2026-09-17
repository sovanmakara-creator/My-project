using UnityEngine;
using System.Collections.Generic;

// Attach this to an empty GameObject called "TrackSpawner".
// trackSegmentPrefab: a cube/plane sized to one path tile, tagged "Ground".
// collectiblePrefab: your diamond prefab, tagged "Collectible", with a
//   trigger Collider and the Collectible.cs script attached.
public class TrackSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject trackSegmentPrefab;
    public GameObject collectiblePrefab;

    [Header("References")]
    public Transform player;

    [Header("Generation Settings")]
    public int segmentsAhead = 10;
    public float segmentLength = 2f;
    [Range(0f, 1f)] public float collectibleChance = 0.4f;
    [Range(0f, 1f)] public float turnChance = 0.5f;

    private List<GameObject> activeSegments = new List<GameObject>();
    private Vector3 nextSpawnPosition = Vector3.zero;
    private Vector3 currentSegmentDirection = Vector3.forward;

    void Start()
    {
        for (int i = 0; i < segmentsAhead; i++)
        {
            SpawnSegment();
        }
    }

    void Update()
    {
        // Keep generating ahead of the player as they move
        float distanceToLast = Vector3.Distance(player.position, nextSpawnPosition);
        if (distanceToLast < segmentsAhead * segmentLength)
        {
            SpawnSegment();
        }

        // Clean up segments far behind the player to save memory
        if (activeSegments.Count > segmentsAhead * 3)
        {
            Destroy(activeSegments[0]);
            activeSegments.RemoveAt(0);
        }
    }

    void SpawnSegment()
    {
        // Randomly decide whether the path turns at this tile
        if (Random.value < turnChance)
        {
            currentSegmentDirection = (currentSegmentDirection == Vector3.forward) ? Vector3.right : Vector3.forward;
        }

        GameObject segment = Instantiate(trackSegmentPrefab, nextSpawnPosition, Quaternion.identity, transform);
        activeSegments.Add(segment);

        if (collectiblePrefab != null && Random.value < collectibleChance)
        {
            Vector3 collectiblePos = nextSpawnPosition + Vector3.up * 1f;
            Instantiate(collectiblePrefab, collectiblePos, Quaternion.identity);
        }

        nextSpawnPosition += currentSegmentDirection * segmentLength;
    }
}
