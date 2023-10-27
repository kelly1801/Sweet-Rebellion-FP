using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;

    [SerializeField] private GameObject swimmerModel;
    [SerializeField] private Transform parent;
    [SerializeField] private int quantity;

    public List<GameObject> Pool { get => pool; }

    public Transform Parent { get => parent; }

    public GameObject PullOne()
    {
        foreach (GameObject swimmer in pool)
        {
            if (!swimmer.activeSelf)
            {
                return swimmer;
            }
        }
        return null;
    }

    public void FillPool()
    {
        for (int i = 0; i < quantity; i++)
        {
            PushOne();
        }
    }

    private void Awake()
    {
        pool = new();

        FillPool();
    }

    private void PushOne()
    {
        GameObject swimmer = Instantiate(swimmerModel, parent);
        swimmer.SetActive(false);

        pool.Add(swimmer);
    }

}
