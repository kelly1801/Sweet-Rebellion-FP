using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : InteractableObject
{
    
   // public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(PlayerController player)
    {
        Debug.Log(player);
        Debug.Log(player.GetKitchenElementNewTransform());
        if (!player.HasKitchenObject()) {
            // Player is not carrying anything
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

           // OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    
    }

}