using UnityEngine;

public class ClearTable : InteractableObject
{
    public override void Interact(PlayerController player)
    {
        if (!HasKitchenObject()) 
        {
            
            if(player.HasKitchenObject()){
                        
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else
            {
        
            }
        } else
        {
            if (player.HasKitchenObject())
            {
        
            } else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}