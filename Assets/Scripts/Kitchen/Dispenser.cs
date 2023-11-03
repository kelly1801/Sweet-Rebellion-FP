using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : InteractableObject
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform pool;
    [SerializeField] private int quantity;

    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = new(kitchenObjectSO.prefab.gameObject, pool, quantity);
    }

    public override void Interact(PlayerController player)
    {
        Debug.Log("INTERACTING");
        if (!player.HasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            // OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }

    }
}