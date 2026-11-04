using UnityEngine;

public class Wire : MonoBehaviour
{
    public WireModule module;
    public GameObject intactWire;
    public GameObject cutWire;

    public bool IsCut { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (IsCut || !other.CompareTag("Cutter")) return;
        WireCutter cutter = other.GetComponentInParent<WireCutter>();
        if (cutter != null) cutter.SetTouching(this);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Cutter")) return;
        WireCutter cutter = other.GetComponentInParent<WireCutter>();
        if (cutter != null) cutter.ClearTouching(this);
    }

    public void Cut()
    {
        if (IsCut) return;
        if (module.gameManager.State != GameManager.GameState.Playing) return;

        IsCut = true;
        intactWire.SetActive(false);
        cutWire.SetActive(true);
        module.WireCut(this);
    }
}
