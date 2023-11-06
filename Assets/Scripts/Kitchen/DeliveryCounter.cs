using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class DeliveryCounter :  InteractableObject
{
   [SerializeField] private RandomAudioPlayer randomAudioPlayer;

   public override void Interact(PlayerController player)
   {
      if (player.HasKitchenObject())
      {
         if (player.GetKitchenObject().TryGetBox(out BoxObject box))
         {
            randomAudioPlayer.PlayRandomSound();
            DeliveryManager.Instance.DeliverRecipe(box);
            player.GetKitchenObject().gameObject.SetActive(false);
            player.ClearKitchenObject();
         }
      }
   }
}
