using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public TimerScript timerScript;
    public Text gameOverText;

    void Start()
    {
        timerScript = GetComponent<TimerScript>();
    }

    void Update()
    {
        if (timerScript != null && timerScript.IsGameOver())
        {
            ShowGameOverText();
        }
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
