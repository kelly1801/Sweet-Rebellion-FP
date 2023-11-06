using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class BoxObject : KitchenObject
{
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;

    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO _ingredient;
    }
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
            randomAudioPlayer.PlayRandomSound();
            ingredientsList.Add(ingredient);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs 
            
            {
              _ingredient = ingredient
            });
            return true;
        }
        
    }
    
    public List<KitchenObjectSO> GetKitchenObjectSOList() {
        return ingredientsList;
    }

}
