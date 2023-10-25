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
            if (player.HasKitchenObject()) {
                // Player is carrying something
            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void MixIngredients(PlayerController player) {
        if (HasKitchenObject() && GetKitchenObject().CompareTag("Box")) {
           //mix ingredients
           Debug.Log("mMIIIIIIIIIIIIX");
        } else {
         // dont mix we need a box firts 
         Debug.Log("GO GEEEEEEET A BOOOOOOOOOOOOOOOOOOOOX");
        }
    }
}