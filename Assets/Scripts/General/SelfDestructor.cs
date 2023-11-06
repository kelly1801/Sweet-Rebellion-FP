using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}