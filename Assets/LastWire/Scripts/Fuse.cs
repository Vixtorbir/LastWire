using System.Collections;
using Oculus.Interaction;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public int colorIndex;
    public GameObject grabInteraction;
    public SnapInteractor snapInteractor;
    public ReturnOnFall returnOnFall;

    public void Lock()
    {
        grabInteraction.SetActive(false);
        returnOnFall.enabled = false;
    }

    public void Reject()
    {
        StartCoroutine(RejectRoutine());
    }

    IEnumerator RejectRoutine()
    {
        yield return null;
        snapInteractor.enabled = false;
        yield return new WaitForFixedUpdate();
        returnOnFall.ResetPose();
        yield return new WaitForSeconds(0.5f);
        snapInteractor.enabled = true;
    }
}
