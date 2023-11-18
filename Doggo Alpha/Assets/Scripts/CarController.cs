using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject player;

    void Update()
    {
        MoveTowardsPlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckCollision(collision);
    }

    void CheckCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
        else if (collision.gameObject.CompareTag("Car1"))
        {
            HandleCar1Collision();
        }
        else if (collision.gameObject.CompareTag("Car2"))
        {
            HandleCar2Collision();
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void HandlePlayerCollision()
    {
        Debug.Log("Collided with Player");
        GetComponent<AudioSource>().Play();
        RestartGame();
    }

    void HandleCar1Collision()
    {
        Debug.Log("Collided with Car1");
        GetComponent<AudioSource>().Play();
        RestartGame();
    }

    void HandleCar2Collision()
    {
        Debug.Log("Collided with Car2");
        GetComponent<AudioSource>().Play();
        RestartGame();
    }

    void RestartGame()
    {
        // Restart the game after a delay
        Invoke("ReloadScene", 2.0f);
    }

    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

