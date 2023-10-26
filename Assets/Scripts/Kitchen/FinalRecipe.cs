using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalRecipe : MonoBehaviour
{

    [Serializable]
    public struct ingredient_GameObject
    {
        public KitchenObjectSO ingredientSO;
        public GameObject gameObject;
        
    }
    [SerializeField] private BoxObject box;
    [SerializeField] private List<ingredient_GameObject> ingredientsObjectsList;
    
     void Start()
    {
        box.OnIngredientAdded += Box_OnIngredientAdded;
    }
    private void Box_OnIngredientAdded(object sender, BoxObject.OnIngredientAddedEventArgs e)
    {
        foreach (ingredient_GameObject ingredient in ingredientsObjectsList)
        {
            if (ingredient.ingredientSO == e._ingredient)
            {
                ingredient.gameObject.SetActive(true);
            }
        } 
    }
}
