using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.Rotate(new Vector3(xRotation, yRotation, zRotation));
    }

}