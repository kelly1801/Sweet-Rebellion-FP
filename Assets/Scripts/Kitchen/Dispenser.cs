using System;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class Dispenser : InteractableObject
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    public override void Interact(PlayerController player)
    {
        Debug.Log("Dispenser");

        if (!player.HasKitchenObject())
        {
            randomAudioPlayer.PlayRandomSound();
            Transform ingredientTransform = Instantiate(kitchenObjectSO.prefab);
            ingredientTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
        else
        {
            player.GetKitchenObject().SetKitchenObjectParent(player);

        }
    }


}