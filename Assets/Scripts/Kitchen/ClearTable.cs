using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class ClearTable : InteractableObject
{
 
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    public override void Interact(PlayerController player) {

        Debug.Log("Table");

        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (player.HasKitchenObject()) {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
                randomAudioPlayer.PlayRandomSound();
            } else {
                // Player not carrying anything
            }
        } else {
            // There is a KitchenObject here
            if (player.HasKitchenObject())
                // player has somethig
            {
                if (player.GetKitchenObject().TryGetBox(out BoxObject box))
                // player has a box
                {
                    if (box.TryAddIngredient(GetKitchenObject().GetKitchenObject()))
                    {
                        KitchenObject ingredient = GetKitchenObject();
                        ingredient.gameObject.SetActive(false);
                    }
                }
                else
                {
                    // is holding something different that a box
                    if (GetKitchenObject().TryGetBox(out box))
                    {
                        if (box.TryAddIngredient(player.GetKitchenObject().GetKitchenObject()))
                        {
                            KitchenObject ingredientOnPlayer = player.GetKitchenObject();
                            ingredientOnPlayer.gameObject.SetActive(false);
                            player.ClearKitchenObject();
                        }
                    }
                }
            }
            else {
                // Player is not carrying something
                GetKitchenObject().SetKitchenObjectParent(player);
            } 
        }
    }
}