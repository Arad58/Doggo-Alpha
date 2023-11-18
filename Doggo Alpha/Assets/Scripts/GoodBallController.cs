using UnityEngine;

public class GoodBallController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform player; 
    private Rigidbody objectRb;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (player != null)
        {
            // Move the object towards the player's position using steady speed
            Vector3 direction = (player.position - transform.position).normalized;
            objectRb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreScript scoreScript = Object.FindFirstObjectByType<ScoreScript>(); 

            if (scoreScript != null)
            {
                scoreScript.AddPoints(10);
            }

            Destroy(gameObject);
        }
    }
}


