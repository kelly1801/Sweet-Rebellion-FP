using UnityEngine;

public class ClearTable : InteractableObject
{
 
    public override void Interact(PlayerController player) {
        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (player.HasKitchenObject()) {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
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
                        Destroy(ingredient.gameObject);
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
                            Destroy(ingredientOnPlayer.gameObject);
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