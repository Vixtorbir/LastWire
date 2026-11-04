using TMPro;
using UnityEngine;

public class StatusPanel : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI strikesText;
    public TextMeshProUGUI modulesText;

    int shownSeconds = -1;
    int shownStrikes = -1;
    int shownModules = -1;

    void Update()
    {
        int seconds = Mathf.CeilToInt(gameManager.TimeLeft);
        if (seconds != shownSeconds)
        {
            shownSeconds = seconds;
            timeText.text = "TIME   " + (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        if (gameManager.Strikes != shownStrikes)
        {
            shownStrikes = gameManager.Strikes;
            strikesText.text = "STRIKES   " + shownStrikes + " / " + gameManager.maxStrikes;
        }

        if (gameManager.SolvedModules != shownModules)
        {
            shownModules = gameManager.SolvedModules;
            modulesText.text = "MODULES   " + shownModules + " / " + gameManager.modulesToSolve;
        }
    }
}
