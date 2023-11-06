using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRecipe : MonoBehaviour
{
    [Serializable]
    public struct ingredient_GameObject
    {
        public KitchenObjectSO ingredientSO;
        public GameObject ingredientLine;
    }

    [SerializeField] private BoxObject box;
    [SerializeField] private List<ingredient_GameObject> ingredientsObjectsList;
    [SerializeField] private Transform[] spawnPoints; // Declare the spawnPoints variable here

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
                ActivateIngredientLine(ingredient);
            }
        }
    }

    private void ActivateIngredientLine(ingredient_GameObject ingredient)
    {
        // Find an available spawn point for the ingredient line
        Transform chosenSpawnPoint = GetAvailableSpawnPoint();

        // Set the position of the ingredient line to the chosen spawn point
        ingredient.ingredientLine.transform.position = chosenSpawnPoint.position;

        // Activate the ingredient line
        ingredient.ingredientLine.SetActive(true);
    }

    private Transform GetAvailableSpawnPoint()
    {
        // Check if there are available spawn points
        if (spawnPoints.Length > 0)
        {
            // Randomly select a spawn point index
            int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

            // Get the randomly chosen spawn point
            Transform chosenSpawnPoint = spawnPoints[randomIndex];

            // Remove the chosen spawn point from the array to prevent reuse
            List<Transform> remainingSpawnPoints = new List<Transform>(spawnPoints);
            remainingSpawnPoints.RemoveAt(randomIndex);
            spawnPoints = remainingSpawnPoints.ToArray();

            return chosenSpawnPoint;
        }
      
      
    }
}



