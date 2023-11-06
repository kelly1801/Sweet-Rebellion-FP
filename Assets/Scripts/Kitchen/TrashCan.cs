using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class TrashCan : InteractableObject
{
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    public override void Interact(PlayerController player)
    {
        Debug.Log("TrashCan");

        if (player.HasKitchenObject())
        {
            randomAudioPlayer.PlayRandomSound();
            KitchenObject ingredient = player.GetKitchenObject();
            ingredient.SetKitchenObjectParent(this);
            ingredient.gameObject.SetActive(false);
        }
    }
}
