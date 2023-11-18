using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    private float xBound = 48;
    private float zBound = 24;
    private Rigidbody playerRb;
    public TimerScript timerScript;
    public ScoreScript scoreScript;
    public Text passedLevelText;
    public Text gameOverText;
    public GameObject[] collectibles; 
    public List<GameObject> enemies = new List<GameObject>(); 

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        DisablePassedLevel();
        gameOverText.gameObject.SetActive(false);
        if (passedLevelText != null)
        {
            passedLevelText.gameObject.SetActive(false);
        }

        // Finding and adding collectibles with the tag "GoodBall" to the array
        collectibles = GameObject.FindGameObjectsWithTag("GoodBall");

        // Finding and adding enemies with the tags "Car1", "Car2", and "BadBall" to the list
        GameObject[] car1Objects = GameObject.FindGameObjectsWithTag("Car1");
        GameObject[] car2Objects = GameObject.FindGameObjectsWithTag("Car2");
        GameObject[] badBallObjects = GameObject.FindGameObjectsWithTag("BadBall");

        enemies.AddRange(car1Objects);
        enemies.AddRange(car2Objects);
        enemies.AddRange(badBallObjects);
    }

    void Update()
    {
        MovePlayer();
        CheckPassedCoordinates();
    }

    void FixedUpdate()
    {
        ConstrainPlayerPositionX();
        ConstrainPlayerPositionZ();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput, ForceMode.VelocityChange);
        playerRb.AddForce(Vector3.right * speed * horizontalInput, ForceMode.VelocityChange);
    }

    void ConstrainPlayerPositionX()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    void ConstrainPlayerPositionZ()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            playerRb.velocity = Vector3.zero;
        }
    }

    void DisablePassedLevel()
    {
        if (passedLevelText != null)
        {
            passedLevelText.gameObject.SetActive(false);
        }
    }

    void CheckPassedCoordinates()
    {
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        float playerZ = transform.position.z;

        // Range of coordinates to trigger "Passed Level!"
        float minX = -4.4f;
        float maxX = 5.3f;
        float targetY = 0f;
        float targetZ = 24f;
        float threshold = 0.1f;

        // Check if player is in the specified coordinates range
        if (playerX >= minX && playerX <= maxX &&
            Mathf.Abs(playerY - targetY) <= threshold &&
            Mathf.Abs(playerZ - targetZ) <= threshold)
        {
            // Trigger "Passed Level!" message
            DisplayPassedLevelMessage();
            ShowPassedLevelText();
            UpdateScore();
            ResetGame();
        }
    }

    void DisplayPassedLevelMessage()
    {
        Debug.Log("Passed Level!");
    }

    void ShowPassedLevelText()
    {
        if (passedLevelText != null)
        {
            passedLevelText.text = "Passed Level!";
            passedLevelText.gameObject.SetActive(true); 
        }
    }

    void UpdateScore()
    {
        if (scoreScript != null)
        {
            scoreScript.AddPoints(100);
        }
    }

    void ResetGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoodBall"))
        {
            Debug.Log("Collided with GoodBall");
        }
        else if (collision.gameObject.CompareTag("BadBall"))
        {
            Debug.Log("Collided with BadBall");
            if (timerScript != null)
            {
                timerScript.ShowGameOver();
            }
        }
        else if (collision.gameObject.CompareTag("Car1"))
        {
            Debug.Log("Collided with Car1");
            timerScript.ShowGameOver();
        }
        else if (collision.gameObject.CompareTag("Car2"))
        {
            Debug.Log("Collided with Car2");
            timerScript.ShowGameOver();
        }
    }
}
