using TMPro;
using UnityEngine;

public class BombDisplay : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro timerText;
    public TextMeshPro strikesText;

    int shownSeconds = -1;
    int shownStrikes = -1;

    void Update()
    {
        int seconds = Mathf.CeilToInt(gameManager.TimeLeft);
        if (seconds != shownSeconds)
        {
            shownSeconds = seconds;
            timerText.text = (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        if (gameManager.Strikes != shownStrikes)
        {
            shownStrikes = gameManager.Strikes;
            string strikes = "";
            for (int i = 0; i < shownStrikes; i++)
            {
                strikes += "X ";
            }
            strikesText.text = strikes;
        }
    }
}
