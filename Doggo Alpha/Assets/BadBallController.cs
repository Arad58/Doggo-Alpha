using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadBallController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody objectRb;
    public Transform playerTransform;
    public GameObject gameOverText;
    private Vector3 startPosition;
    private bool hasCollided = false; 

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        startPosition = playerTransform.position;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    void Update()
    {
        if (hasCollided)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            ShowGameOver();

            // Get the AudioSource component attached to the game object
            AudioSource audioSource = GetComponent<AudioSource>();

            // Play the audio
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    void ShowGameOver()
    {
        if (gameOverText != null && !gameOverText.activeSelf)
        {
            gameOverText.SetActive(true);
            Invoke("ResetScene", 2f);
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetPlayer()
    {
        playerTransform.position = startPosition;
    }
}
