using System;
using UnityEngine;

public class Dispenser : InteractableObject
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(PlayerController player)
    {
     
        if (!player.HasKitchenObject())
        {
            Transform ingredientTransform = Instantiate(kitchenObjectSO.prefab);
            ingredientTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        } else
        {
           
            player.GetKitchenObject().SetKitchenObjectParent(player);
            
        }
    }

   
}