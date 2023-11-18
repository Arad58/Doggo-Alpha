using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private bool isGameOver = false;
    private float timerDuration = 60.0f;
    public Text timerText;
    public GameObject gameOverText;
    public AudioSource gameOverSound; 

    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (timerDuration > 0)
            {
                timerDuration -= Time.deltaTime;
                UpdateTimerDisplay();
                if (timerDuration <= 0)
                {
                    timerDuration = 0;
                    TriggerGameOver();
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Timer: " + timerDuration.ToString("F1");
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        ShowGameOver();
    }

    public void ShowGameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);

            if (gameOverSound != null)
            {
                gameOverSound.Play();
            }
        }
    }

    public void ResetTimer()
    {
        isGameOver = false;
        timerDuration = 0.0f;
        UpdateTimerDisplay();
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }
}
