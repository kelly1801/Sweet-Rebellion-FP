using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : InteractableObject
{
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    public override void Interact(PlayerController player)
    {
        if (player.HasKitchenObject())
        {
            GameObject kitchenGameObject = player.GetKitchenObject().gameObject;
            kitchenGameObject.transform.parent = _transform;
            kitchenGameObject.gameObject.SetActive(false);
        }
    }
}
