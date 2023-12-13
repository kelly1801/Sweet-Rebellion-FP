using UnityEngine;

public interface IKitchenElementParent
{

    public Transform GetKitchenElementNewTransform();

    public KitchenObject GetKitchenObject();
    public void SetKitchenObject(KitchenObject kitchenObject);
    public void ClearKitchenObject();
    public bool HasKitchenObject();
}
