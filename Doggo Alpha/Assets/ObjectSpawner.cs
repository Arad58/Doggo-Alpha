using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // The prefab to be spawned
    public GameObject objectToSpawn;
    // The area where objects will be spawned
    public Vector3 spawnArea;
    // Minimum time between spawns.
    public float minSpawnInterval = 1f;
    // Maximum time between spawns.
    public float maxSpawnInterval = 5f;

    void Start()
    {
        // Start spawning objects at random intervals.
        InvokeRepeating("SpawnObject", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnObject()
    {
        // Calculate a random position within the spawn area.
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.x, spawnArea.x + spawnArea.z),
            spawnArea.y,
            Random.Range(spawnArea.y, spawnArea.y + spawnArea.y)
        );

        // Instantiate the object at the random position.
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}

