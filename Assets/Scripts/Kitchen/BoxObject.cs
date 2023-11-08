using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[RequireComponent(typeof(RandomAudioPlayer))]
public class BoxObject : KitchenObject
{
    [SerializeField] private RandomAudioPlayer randomAudioPlayer;
    [SerializeField] private ParticleSystem stars;

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

            try
            {
                stars.gameObject.SetActive(true);
                stars.Play();
                StartCoroutine(StopParticlesAfter(1f));
            }
            catch (Exception)
            {
                Debug.Log($"{gameObject.name}: Particle system is null");
            }

            ingredientsList.Add(ingredient);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                _ingredient = ingredient
            });
            return true;
        }

    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return ingredientsList;
    }

    private IEnumerator StopParticlesAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        stars.gameObject.SetActive(false);
    }

}
