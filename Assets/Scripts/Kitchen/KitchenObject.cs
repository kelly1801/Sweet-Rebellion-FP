using System;
using Unity.Mathematics;
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
        
        // Set position and parent
        
        transform.parent = kitchenElementParent.GetKitchenElementNewTransform();
        transform.localPosition = Vector3.zero;
        transform.rotation = quaternion.identity;
   
    }

    public bool TryGetBox(out BoxObject box)
    {
        if (this is BoxObject)
        {
            box = this as BoxObject;
            return true;
        }
        else
        {
            box = null;
            return false;
        }
        
    }
    public IKitchenElementParent GetKitchenElementParent()
    {
        return kitchenElementParent;
    }
}
