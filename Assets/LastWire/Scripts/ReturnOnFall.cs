using Oculus.Interaction;
using UnityEngine;

public class ReturnOnFall : MonoBehaviour
{
    public Grabbable grabbable;
    public Rigidbody body;
    public float minHeight = 0.4f;
    public float restTime = 1f;

    Vector3 startPosition;
    Quaternion startRotation;
    float lowTime;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (grabbable.SelectingPointsCount > 0 || transform.position.y > minHeight)
        {
            lowTime = 0f;
            return;
        }

        lowTime += Time.deltaTime;
        if (lowTime >= restTime) ResetPose();
    }

    public void ResetPose()
    {
        lowTime = 0f;
        if (!body.isKinematic)
        {
            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
        body.position = startPosition;
        body.rotation = startRotation;
        transform.SetPositionAndRotation(startPosition, startRotation);
    }
}
