using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class DeliveryCounter : InteractableObject
{
   [SerializeField] private RandomAudioPlayer piggyCashSounds;
   [SerializeField] private RandomAudioPlayer twinklesSounds;
   [SerializeField] private ParticleSystem coins;

   private DeliveryManager deliveryManager;

   private void Start(){
      deliveryManager = FindAnyObjectByType<DeliveryManager>();
   }

   public override void Interact(PlayerController player)
   {
      if (player.HasKitchenObject())
      {
         if (player.GetKitchenObject().TryGetBox(out BoxObject box))
         {
            bool deliveredRecipe = deliveryManager.DeliverRecipe(box);
            player.GetKitchenObject().gameObject.SetActive(false);
            player.ClearKitchenObject();

            if (deliveredRecipe)
            {
               piggyCashSounds.PlayRandomSound();
               twinklesSounds.PlayRandomSound();

               coins.gameObject.SetActive(true);
               coins.Play();
               StartCoroutine(StopParticlesAfter(1f));
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
