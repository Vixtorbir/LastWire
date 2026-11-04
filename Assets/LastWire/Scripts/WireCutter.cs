using Oculus.Interaction;
using UnityEngine;

public class WireCutter : MonoBehaviour
{
    public Grabbable grabbable;
    public float handHoldTime = 0.4f;

    Wire touchingWire;
    float touchTime;

    public void SetTouching(Wire wire)
    {
        touchingWire = wire;
        touchTime = 0f;
    }

    public void ClearTouching(Wire wire)
    {
        if (touchingWire == wire) touchingWire = null;
    }

    void Update()
    {
        if (touchingWire == null || touchingWire.IsCut) return;
        if (grabbable.SelectingPointsCount == 0) return;

        touchTime += Time.deltaTime;

        bool triggerPressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Touch)
            || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch);
        bool usingHands = OVRInput.IsControllerConnected(OVRInput.Controller.Hands);

        if (triggerPressed || (usingHands && touchTime >= handHoldTime))
        {
            touchingWire.Cut();
            touchingWire = null;
        }
    }
}
