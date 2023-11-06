using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private Transform[] iconSpots;

    public void SetRecipeIngredients(RecipeSO recipe)
    {
        List<Transform> availableIconSpot = new List<Transform>(iconSpots);

        for (int i = 0; i < recipe.ingredientsList.Count; i++)
        {
            KitchenObjectSO ingredient = recipe.ingredientsList[i];
            availableIconSpot[i].GetComponent<Image>().sprite = ingredient.elementIcon;
        }
    }
}
