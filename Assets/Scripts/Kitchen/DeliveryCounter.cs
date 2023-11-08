using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class DeliveryCounter : InteractableObject
{
   [SerializeField] private RandomAudioPlayer piggyCashSounds;
   [SerializeField] private RandomAudioPlayer twinklesSounds;
   [SerializeField] private ParticleSystem coins;

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

            if (coins != null)
            {
               coins.gameObject.SetActive(true);
               coins.Play();
               StartCoroutine(StopParticlesAfter(1f));
            }
            else
            {
               Debug.Log($"{gameObject.name}: Particle system is null");
            }
         }
      }
   }

   private IEnumerator StopParticlesAfter(float seconds)
   {
      yield return new WaitForSeconds(seconds);
      coins.gameObject.SetActive(false);
   }
}
