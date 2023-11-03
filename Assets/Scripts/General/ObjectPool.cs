using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private readonly GameObject swimmerModel = null;
    private readonly Transform parent = null;
    private readonly int quantity = 0;
    private readonly List<GameObject> pool;

    public List<GameObject> Pool { get => pool; }
    public Transform Parent { get => parent; }

    public ObjectPool(GameObject swimmerModel, Transform parent, int quantity)
    {
        this.swimmerModel = swimmerModel;
        this.parent = parent;
        this.quantity = quantity;

        pool = new();
    }

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

    private void PushOne()
    {
        GameObject swimmer = GameObject.Instantiate(swimmerModel, parent.position, Quaternion.identity); // the object keeps global scale
        //GameObject swimmer = Instantiate(swimmerModel, parent); // the object doesn't keeps global scale

        swimmer.SetActive(false);

        pool.Add(swimmer);
    }
}