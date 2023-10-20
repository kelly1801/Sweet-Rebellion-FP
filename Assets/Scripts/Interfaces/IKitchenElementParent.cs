using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenElementParent
{

    public Transform GetKitchenElementNewTransform();

    public KitchenObject GetKitchenObject();
    public void SetKitchenObject(KitchenObject kitchenObject);
    public void ClearKitchenObject();
    public bool HasKitchenObject();
}
