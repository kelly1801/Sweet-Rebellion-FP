using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private Transform spherePosition;
    [SerializeField] private float radius;
    [SerializeField] private Color color;

    private GameObject objectDetected;

    private void OnCollisionEnter(Collision collision)
    {
        objectDetected = collision.gameObject;
    }

    public GameObject GetObject()
    {
        return objectDetected;
    }
}
