using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{
  [SerializeField] private RecipesListSO _recipesListSO;
  private List<RecipeSO> waitingRecipeList;

  private float spawnRecipeTimer;
  private float spawnRecipeTimerMax = 4f;

  private int maximunWaitingRecipes = 4;

  private void Awake()
  {
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
        Debug.Log(waitingRecipe.name);
        waitingRecipeList.Add(waitingRecipe);

      }
      
    }
    {
      
    }
  }
}
