using TMPro;
using UnityEngine;

public class KeypadModule : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro inputText;
    public TextMeshPro clueText;
    public Renderer statusLed;
    public Material solvedMaterial;

    string code;
    string input = "";
    bool solved;

    void Start()
    {
        code = Random.Range(1000, 10000).ToString();
        clueText.text = code;
        inputText.text = "____";
    }

    public void Press(string key)
    {
        if (solved) return;
        if (gameManager.State != GameManager.GameState.Playing) return;

        if (key == "C")
        {
            input = "";
        }
        else if (key == "OK")
        {
            if (input.Length == 4) CheckCode();
        }
        else if (input.Length < 4)
        {
            input += key;
        }

        if (!solved) inputText.text = input.PadRight(4, '_');
    }

    void CheckCode()
    {
        if (input == code)
        {
            solved = true;
            inputText.text = "OK";
            statusLed.sharedMaterial = solvedMaterial;
            gameManager.ModuleSolved();
        }
        else
        {
            input = "";
            gameManager.AddStrike();
        }
    }
}
