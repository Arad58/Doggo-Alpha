using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Individual GameObject variables for GoodBall and BadBall objects
    public GameObject goodBallObject;
    public GameObject badBallObject;

    // Arrays to hold multiple GoodBall and BadBall objects
    public GameObject[] goodBalls;
    public GameObject[] badBalls;

    void Start()
    {
        // Assign GameObject to individual variables for GoodBall
        goodBallObject = GameObject.Find("GoodBall");

        // Assign GameObject to individual variables for BadBall
        badBallObject = GameObject.Find("BadBall");

        // Initialize the arrays with GoodBall and BadBall objects
        goodBalls = new GameObject[] { goodBallObject };
        badBalls = new GameObject[] { badBallObject };
    }

    void Update()
    {
        // You can perform actions on individual GoodBall objects
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Destroy badBallObject when the space key is pressed
            Destroy(badBallObject);
        }

        // Loop through the array to perform actions on all GoodBall objects
        foreach (GameObject ball in goodBalls)
        {
            if (ball != null && Input.GetMouseButtonDown(0))
            {
                // Change the color of the GoodBall object
                Renderer renderer = ball.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.green;
                }
            }
        }
    }
}




