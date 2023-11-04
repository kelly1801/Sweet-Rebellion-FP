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
    [SerializeField] private Slider moneySlider;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameManager _gameManager;

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
        UpdateVisual();
        // Update the money slider and text
        moneySlider.value += e.RecipeValue;
        moneyText.text = "$ " + moneySlider.value.ToString();
    
        // Update the GameManager's payedDebt value
        _gameManager.payedDebt = moneySlider.value;
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
                Debug.Log(recipe.recipeName + recipe.recipeValue.ToString());
                
            }
    }

}
