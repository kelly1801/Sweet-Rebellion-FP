using UnityEngine;

public class Dispenser : InteractableObject
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    public override void Interact(PlayerController player)
    {
        if (!player.HasKitchenObject())
        {
            Transform ingredientTransform = Instantiate(kitchenObjectSo.prefab);
            ingredientTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
        else
        {
            player.GetKitchenObject().SetKitchenObjectParent(player);
        }
    }

}