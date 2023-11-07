using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class TrashCan : InteractableObject
{
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;
    [SerializeField] private ParticleSystem dust;

    public override void Interact(PlayerController player)
    {
        Debug.Log("TrashCan");

        if (player.HasKitchenObject())
        {
            randomAudioPlayer.PlayRandomSound();
            KitchenObject ingredient = player.GetKitchenObject();
            ingredient.SetKitchenObjectParent(this);
            ingredient.gameObject.SetActive(false);

            dust.gameObject.SetActive(true);
            dust.Play();
            StartCoroutine(StopParticlesAfter(1f));
        }
    }

    private IEnumerator StopParticlesAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dust.gameObject.SetActive(false);
    }
}
