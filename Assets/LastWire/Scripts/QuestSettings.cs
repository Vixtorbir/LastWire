using UnityEngine;

public class QuestSettings : MonoBehaviour
{
    void Start()
    {
        OVRManager.foveatedRenderingLevel = OVRManager.FoveatedRenderingLevel.High;
        OVRManager.useDynamicFoveatedRendering = true;
    }
}
