using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public void Activate()
    {
        objectToActivate.SetActive(true);
    }

}