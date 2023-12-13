using System;
using System.Collections;
using UnityEngine;

public class CandyManager : InteractableObject
{
    [Header("POOL")]
    [SerializeField] private CandyMachine candyMachine = null;
    [SerializeField] private Transform candiesParent = null;

    [Header("VISUALS")]
    [SerializeField] private Transform fakeCandies = null;
    [SerializeField] private Renderer candyPhotoBorder = null;
    [SerializeField] private Renderer candyPhoto = null;

    [Header("OUTPUT")]
    [SerializeField] private Transform exitPoint = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private AnimationClip leverAnimation = null;

    private ObjectPool candyPool;

    public override void Interact(PlayerController player)
    {
        Debug.Log("Candy");

        //if (player.GetComponent<PlayerController>().pickPoint.transform.childCount < 1)
        if (!player.HasKitchenObject())
        {
            StartCoroutine(RollLever(player));
        }
        else
        {
            Debug.Log("ERROR: you already have candy");
        }
    }

    private void Awake()
    {
        FillMachineVisually();
    }

    private void Start()
    {
        candyPool = new(candyMachine.Candy, candiesParent, candyMachine.CandiesQuantity);

        candyPool.FillPool();

        Material newBorderMaterial = new(candyPhotoBorder.GetComponent<Renderer>().sharedMaterial)
        {
            mainTexture = candyMachine.Sprite.texture
        };
        Renderer borderRenderer = candyPhotoBorder.GetComponent<Renderer>();
        borderRenderer.material = newBorderMaterial;

        Material newPhotoMaterial = new(candyPhoto.GetComponent<Renderer>().sharedMaterial)
        {
            mainTexture = candyMachine.Sprite.texture
        };
        Renderer photoRenderer = candyPhoto.GetComponent<Renderer>();
        photoRenderer.material = newPhotoMaterial;

        GameObject exitCandy = Instantiate(candyMachine.Candy, exitPoint.position, Quaternion.identity);
        exitCandy.transform.parent = exitPoint;
    }

    private void FillMachineVisually()
    {
        foreach (Transform fakeCandyTransform in fakeCandies)
        {
            GameObject candyInstance = Instantiate(candyMachine.FakeCandy, fakeCandyTransform.position, fakeCandyTransform.rotation);
            candyInstance.transform.parent = fakeCandyTransform;
            candyInstance.SetActive(true);
        }
    }

    private IEnumerator RollLever(PlayerController player)
    {
        animator.SetTrigger("roll");
        yield return new WaitForSeconds(leverAnimation.length);

        GameObject candy = candyPool.PullOne();

        try
        {
            candy.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            candy.SetActive(true);
        }
        catch (Exception)
        {
            Debug.Log("This is not a Kitchen Object");
        }
    }
}
