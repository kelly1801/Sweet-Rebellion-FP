using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class DeliveryCounter :  InteractableObject
{
   [SerializeField] private RandomAudioPlayer piggyCashSounds;
   [SerializeField] private RandomAudioPlayer twinklesSounds;

   public override void Interact(PlayerController player)
   {
      if (player.HasKitchenObject())
      {
         if (player.GetKitchenObject().TryGetBox(out BoxObject box))
         {
            DeliveryManager.Instance.DeliverRecipe(box);
            player.GetKitchenObject().gameObject.SetActive(false);
            player.ClearKitchenObject();
            
            piggyCashSounds.PlayRandomSound();
            twinklesSounds.PlayRandomSound();
         }
      }
   }
}
