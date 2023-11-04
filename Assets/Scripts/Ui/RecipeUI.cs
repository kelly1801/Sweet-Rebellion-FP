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

        foreach (KitchenObjectSO ingredient in recipe.ingredientsList)
        {
            int randIndex = UnityEngine.Random.Range(0, availableIconSpot.Count);
   
            Transform chosenIconSpot = availableIconSpot[randIndex];
            chosenIconSpot.GetComponent<Image>().sprite = ingredient.elementIcon;
            availableIconSpot.RemoveAt(randIndex);
        }

      
    }
}
