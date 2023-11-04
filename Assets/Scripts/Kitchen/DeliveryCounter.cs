using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter :  InteractableObject
{
   public override void Interact(PlayerController player)
   {
      if (player.HasKitchenObject())
      {
         if (player.GetKitchenObject().TryGetBox(out BoxObject box))
         {
            DeliveryManager.Instance.DeliverRecipe(box);
            player.GetKitchenObject().gameObject.SetActive(false);
            player.ClearKitchenObject();
         }
      }
   }
}
