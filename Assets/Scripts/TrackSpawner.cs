using UnityEngine;
using System.Collections.Generic;

public class TrackSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject trackSegmentPrefab;
    public GameObject obstaclePrefab;

    [Header("Food Prefabs")]
    public GameObject[] foodPrefabs;

    [Header("References")]
    public Transform player;

    [Header("Generation Settings")]
    public int segmentsAhead = 10;
    public float segmentLength = 2f;

    [Range(0f, 1f)]
    public float collectibleChance = 0.4f;

    [Range(0f, 1f)]
    public float obstacleChance = 0.3f;

    [Range(0f, 1f)]
    public float turnChance = 0.5f;

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
        if (player == null)
        {
            return;
        }

        // Generate new track ahead of the player
        float distanceToLast = Vector3.Distance(
            player.position,
            nextSpawnPosition
        );

        if (distanceToLast < segmentsAhead * segmentLength)
        {
            SpawnSegment();
        }

        // Remove old track segments
        if (activeSegments.Count > segmentsAhead * 3)
        {
            Destroy(activeSegments[0]);
            activeSegments.RemoveAt(0);
        }
    }


    void SpawnSegment()
    {
        // ----------------------------------------
        // 1. Randomly turn the track
        // ----------------------------------------

        if (Random.value < turnChance)
        {
            if (currentSegmentDirection == Vector3.forward)
            {
                currentSegmentDirection = Vector3.right;
            }
            else
            {
                currentSegmentDirection = Vector3.forward;
            }
        }


        // ----------------------------------------
        // 2. Spawn track
        // ----------------------------------------

        GameObject segment = Instantiate(
            trackSegmentPrefab,
            nextSpawnPosition,
            Quaternion.identity,
            transform
        );

        activeSegments.Add(segment);


        // ----------------------------------------
        // 3. Decide whether to spawn food
        // ----------------------------------------

        bool spawnedFood = false;

        if (foodPrefabs != null &&
            foodPrefabs.Length > 0 &&
            Random.value < collectibleChance)
        {
            int randomIndex = Random.Range(
                0,
                foodPrefabs.Length
            );

            GameObject foodPrefab = foodPrefabs[randomIndex];

            Vector3 foodPosition =
                nextSpawnPosition + Vector3.up * 0.8f;

            Quaternion foodRotation =
                Quaternion.Euler(
                    0f,
                    Random.Range(0f, 360f),
                    0f
                );

            // IMPORTANT:
            // Spawn first WITHOUT a parent.
            // This preserves the prefab's original scale.
            GameObject food = Instantiate(
                foodPrefab,
                foodPosition,
                foodRotation
            );

            // Preserve the exact prefab scale
            food.transform.localScale = foodPrefab.transform.localScale;

            // Parent afterward while preserving world transform
            food.transform.SetParent(
                segment.transform,
                true
            );

            spawnedFood = true;
        }


        // ----------------------------------------
        // 4. Spawn obstacle
        // ----------------------------------------

        // Don't spawn an obstacle on the same tile as food.
        if (!spawnedFood &&
            obstaclePrefab != null &&
            Random.value < obstacleChance)
        {
            Vector3 obstaclePosition =
                nextSpawnPosition + Vector3.up * 0.65f;

            // Spawn without parent first
            GameObject obstacle = Instantiate(
                obstaclePrefab,
                obstaclePosition,
                Quaternion.identity
            );

            // Preserve the exact prefab scale
            obstacle.transform.localScale =
                obstaclePrefab.transform.localScale;

            // Parent afterward while preserving world transform
            obstacle.transform.SetParent(
                segment.transform,
                true
            );
        }


        // ----------------------------------------
        // 5. Move to next track tile
        // ----------------------------------------

        nextSpawnPosition +=
            currentSegmentDirection * segmentLength;
    }
}