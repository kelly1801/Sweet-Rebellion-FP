using System;
using UnityEngine;

public class Dispenser : InteractableObject
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform pool;
    [SerializeField] private int quantity;

    private ObjectPool dispensedPool;

    private void Awake()
    {
        dispensedPool = new(kitchenObjectSO.prefab.gameObject, pool, quantity);

        dispensedPool.FillPool();
    }

    public override void Interact(PlayerController player)
    {
        Debug.Log("Dispenser");

        if (!player.HasKitchenObject())
        {
            Dispense(player);
            // OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Dispense(PlayerController player)
    {
        GameObject dispensed = dispensedPool.PullOne();

        try
        {
            dispensed.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            dispensed.SetActive(true);
        }
        catch (Exception)
        {
            Debug.Log("This is not a Kitchen Object");
        }
    }
}