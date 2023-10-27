using UnityEngine;

public class InteractableObject : MonoBehaviour, IKitchenElementParent
{
    [SerializeField] private Transform tablePickPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact(PlayerController player)
    {
        Debug.LogError("Interact action is not set");
    }
    
    public Transform GetKitchenElementNewTransform()
    {
        return tablePickPoint;
    }

    public KitchenObject GetKitchenObject()
    {
       return kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
       return kitchenObject != null;
    }
}