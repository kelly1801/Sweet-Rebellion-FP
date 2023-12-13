using System;
using UnityEngine;
public class DeliverManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;

    private GameManager gameManager;
    private DeliveryManager deliveryManager;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        deliveryManager = FindAnyObjectByType<DeliveryManager>();

        deliveryManager.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        deliveryManager.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;

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
        gameManager.payedDebt += e.RecipeValue;
    }


    private void UpdateVisual()
    {
        foreach (Transform template in container)
        {
            if (template == recipeTemplate) continue;

            template.gameObject.SetActive(false);
        }

        foreach (RecipeSO recipe in deliveryManager.GetWaitingRecipes())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<RecipeUI>().SetRecipeIngredients(recipe);
        }
    }

}
