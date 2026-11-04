using UnityEngine;

public class WireModule : MonoBehaviour
{
    public GameManager gameManager;
    public Wire[] wires;
    public Renderer indicatorLight;
    public Color[] lightColors;
    public int[] wireToCutForColor;
    public Renderer statusLed;
    public Material solvedMaterial;

    int correctWire;
    bool solved;

    void Start()
    {
        int colorIndex = Random.Range(0, lightColors.Length);
        indicatorLight.material.color = lightColors[colorIndex];
        indicatorLight.material.SetColor("_EmissionColor", lightColors[colorIndex]);
        correctWire = wireToCutForColor[colorIndex];
    }

    public void WireCut(Wire wire)
    {
        if (solved) return;

        if (System.Array.IndexOf(wires, wire) == correctWire)
        {
            solved = true;
            statusLed.sharedMaterial = solvedMaterial;
            gameManager.ModuleSolved();
        }
        else
        {
            gameManager.AddStrike();
        }
    }
}
