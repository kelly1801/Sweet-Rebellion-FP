using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DeliverManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;

        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, RecipeCompletedEventArgs e)
    {
        randomAudioPlayer.PlayRandomSound();

        UpdateVisual();
        // Update the money slider and text
    
        // Update the GameManager's payedDebt value
        GameManager.Instance.payedDebt += e.RecipeValue;
    }


    private void UpdateVisual()
    {
        foreach (Transform template in container)
        {
            if (template == recipeTemplate) continue;
            
                template.gameObject.SetActive(false);
            
        }

        foreach (RecipeSO recipe in DeliveryManager.Instance.GetWaitingRecipes())
        {
                Transform recipeTransform = Instantiate(recipeTemplate, container);
                recipeTransform.gameObject.SetActive(true);
                recipeTransform.GetComponent<RecipeUI>().SetRecipeIngredients(recipe);
        }
    }

}
