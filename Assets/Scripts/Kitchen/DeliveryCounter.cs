using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter :  InteractableObject
{
   public override void Interact(PlayerController player)
   {
      if (player.HasKitchenObject())
      {
         Debug.Log("DELIVERYINGG");
         if (player.GetKitchenObject().TryGetBox(out BoxObject box))
         {
            player.GetKitchenObject().gameObject.SetActive(false);
         }
      }
   }
}
