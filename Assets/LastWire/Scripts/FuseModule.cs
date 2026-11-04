using Oculus.Interaction;
using TMPro;
using UnityEngine;

public class FuseModule : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro serialText;
    public SnapInteractable socket;
    public Renderer statusLed;
    public Material solvedMaterial;

    int correctColor;
    bool solved;

    void Start()
    {
        int serial = Random.Range(10000, 100000);
        serialText.text = "SN " + serial;

        int lastDigit = serial % 10;
        if (lastDigit <= 3) correctColor = 0;
        else if (lastDigit <= 6) correctColor = 1;
        else correctColor = 2;
    }

    void OnEnable()
    {
        socket.WhenSelectingInteractorViewAdded += FuseInserted;
    }

    void OnDisable()
    {
        socket.WhenSelectingInteractorViewAdded -= FuseInserted;
    }

    void FuseInserted(IInteractorView interactor)
    {
        Fuse fuse = (interactor as Component).GetComponentInParent<Fuse>();
        if (fuse == null || solved) return;

        if (gameManager.State == GameManager.GameState.Playing && fuse.colorIndex == correctColor)
        {
            solved = true;
            fuse.Lock();
            statusLed.sharedMaterial = solvedMaterial;
            gameManager.ModuleSolved();
            return;
        }

        gameManager.AddStrike();
        fuse.Reject();
    }
}
