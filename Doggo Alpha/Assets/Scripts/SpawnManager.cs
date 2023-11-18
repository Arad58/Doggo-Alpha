using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject goodBallPrefab;
    public GameObject badBallPrefab;
    public Transform player;
    public float xSpawnRange = 0.0f;
    public float ySpawnRange = 10.0f;
    public float zSpawnRange = 0.0f;
    private float badBallSpawnTime = 5.0f;
    private float goodBallSpawnTime = 5.0f;
    private float startDelay = 1.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player transform not found. Make sure the player has a 'Player' tag.");
        }

        InvokeRepeating("SpawnBadBall", startDelay, badBallSpawnTime);
        InvokeRepeating("SpawnGoodBall", startDelay, goodBallSpawnTime);
    }

    void SpawnBadBall()
    {
        MoveBallTowardsPlayer(badBallPrefab);
    }

    void SpawnGoodBall()
    {
        MoveBallTowardsPlayer(goodBallPrefab);
    }

    void MoveBallTowardsPlayer(GameObject ballPrefab)
    {
        if (player != null && ballPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnRange, Random.Range(-zSpawnRange, zSpawnRange));

            GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

            Rigidbody ballRb = ball.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                Vector3 direction = (player.position - ball.transform.position).normalized;
                ballRb.velocity = direction * 10f;
            }
            else
            {
                Debug.LogError("Ball prefab is missing a Rigidbody component.");
            }
        }
    }
}
