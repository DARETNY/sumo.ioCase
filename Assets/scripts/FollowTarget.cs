using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float cameraDistance = 10f;

    void LateUpdate()
    {
        if (!target)
            return;

        Vector3 targetScale = target.localScale;
        float maxTargetScale = Mathf.Max(targetScale.x, targetScale.y, targetScale.z);

        Vector3 desiredPosition = target.position + (Quaternion.Euler(transform.eulerAngles) * Vector3.back * (cameraDistance * maxTargetScale));
        transform.position = desiredPosition;

        transform.LookAt(target.position);
    }
}
