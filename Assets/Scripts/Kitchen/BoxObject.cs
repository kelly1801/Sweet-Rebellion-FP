using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : KitchenObject
{
    private List<KitchenObjectSO> ingredientsList;
    [SerializeField] private List<KitchenObjectSO> validIngredientsList;
    private void Awake()
    {
        ingredientsList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO ingredient)
    {
        if (!validIngredientsList.Contains(ingredient))
        {
            // the ingredient is not valid
            return false;
        }
        if (ingredientsList.Contains((ingredient)))
        {
            return false;
        }
        else
        {
            ingredientsList.Add(ingredient);

            return true;
        }
        
    }

}
