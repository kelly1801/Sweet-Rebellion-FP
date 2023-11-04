using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{

  public static DeliveryManager Instance { get; private set; }
  
  [SerializeField] private RecipesListSO _recipesListSO;
  private List<RecipeSO> waitingRecipeList;

  private float spawnRecipeTimer;
  private float spawnRecipeTimerMax = 4f;

  private int maximunWaitingRecipes = 4;

  private void Awake()
  {
    Instance = this;
    waitingRecipeList = new List<RecipeSO>();
  }

  private void Update()
  {
    spawnRecipeTimer -= Time.deltaTime;
    if (spawnRecipeTimer <= 0f)
    {
      
      spawnRecipeTimer = spawnRecipeTimerMax;
      if (waitingRecipeList.Count < maximunWaitingRecipes)
      {
        RecipeSO waitingRecipe = _recipesListSO.recipesList[Random.Range(0, _recipesListSO.recipesList.Count)];
        Debug.Log(waitingRecipe.recipeName);
        waitingRecipeList.Add(waitingRecipe);

      }
      
    }
    {
      
    }
  }

  public void DeliverRecipe(BoxObject box)
  {
    for (int i = 0; i < waitingRecipeList.Count; i++)
    {
      RecipeSO waitingRecipe = waitingRecipeList[i];

      if (waitingRecipe.ingredientsList.Count == box.GetKitchenObjectSOList().Count)
      {
        bool plateContentMatchRecipe = true;
        // checks if the number of ingredients is correct for the recipe
        foreach (KitchenObjectSO recipeIngredient in waitingRecipe.ingredientsList)
        {
          bool ingredientFound = false;
          // goes through all the ingredients
          foreach (KitchenObjectSO boxObject in waitingRecipe.ingredientsList)
          {
            // goes through all the box
            if (boxObject == recipeIngredient)
            {
              // ingredients match
              ingredientFound = true;
              break;
            }
          }

          if (!ingredientFound)
          {
            plateContentMatchRecipe = false;
          }
        }

        if (plateContentMatchRecipe)
        {
          Debug.Log("correct recipe delivered");
          waitingRecipeList.RemoveAt(i);
          return;
        }
      }
    }
    
    // player did not deliver a valid recipe
    Debug.Log("not valid recipe asshole");
  }
}
