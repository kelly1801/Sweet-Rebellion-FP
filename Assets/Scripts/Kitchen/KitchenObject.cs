using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenElementParent kitchenElementParent;
    public KitchenObjectSO GetKitchenObject()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenElementParent kitchenElementParent)
    {
        if (this.kitchenElementParent != null)
        {
            this.kitchenElementParent.ClearKitchenObject();
        }

        this.kitchenElementParent = kitchenElementParent;

        kitchenElementParent.SetKitchenObject(this);
        transform.parent = kitchenElementParent.GetKitchenElementNewTransform();

        transform.localPosition = Vector3.zero;
        

    }
    public IKitchenElementParent GetKitchenElementParent()
    {
        return kitchenElementParent;
    }
}
