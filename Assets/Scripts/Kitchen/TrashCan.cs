using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : InteractableObject
{
    public override void Interact(PlayerController player)
    {
       
        if (player.HasKitchenObject())
        {
            KitchenObject ingredient = player.GetKitchenObject();
            ingredient.SetKitchenObjectParent(this);
            ingredient.gameObject.SetActive(false);
        }
    }
}
