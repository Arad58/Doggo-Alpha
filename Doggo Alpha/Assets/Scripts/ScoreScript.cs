using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned.");
        }
    }

    public int GetScore()
    {
        return score;
    }

    // ResetScore method here
    public void ResetScore()
    {
        // Reset the score to zero 
        score = 0;
        UpdateScoreText();
    }
}



