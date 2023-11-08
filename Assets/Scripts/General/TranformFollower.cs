using UnityEngine;

public class TransformFollower : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 positionOffset = new(0, 0, 0);
    [SerializeField] private Vector3 rotationOffset = new(0, 0, 0);
    [SerializeField] private float speed = 0f;
    [SerializeField] private float wait = 0f;

    private float initTime = 0f;
    private float deltaTimeCount = 0f;

    private void Start()
    {
        initTime = Time.time;
    }

    private void LateUpdate()
    {
        FollowTransform(targetTransform);
    }

    private void FollowTransform(Transform targetTransform)
    {
        if (Time.time - initTime > wait)
        {
            transform.position = Vector3.Lerp(transform.position, targetTransform.position + positionOffset, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, speed + deltaTimeCount) * Quaternion.Euler(rotationOffset);
            deltaTimeCount += Time.deltaTime;
        }
    }
}