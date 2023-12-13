using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private Image[] icons;

    public void SetRecipeIngredients(RecipeSO recipe)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            KitchenObjectSO ingredient = recipe.ingredientsList[i];
            icons[i].sprite = ingredient.elementIcon;
        }
    }
}