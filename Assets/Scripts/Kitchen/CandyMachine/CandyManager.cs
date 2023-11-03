using System;
using System.Collections;
using UnityEngine;

public class CandyManager : InteractableObject
{
    private ObjectPool candyPool;

    [Header("POOL")]
    [SerializeField] private CandyMachine candyMachine = null;
    [SerializeField] private Transform candisParent = null;

    [Header("OUTPUT")]
    [SerializeField] private ObjectDetector candyDetector = null;
    [SerializeField] private Transform exitPoint = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private AnimationClip leverAnimation = null;

    public override void Interact(PlayerController player)
    {
        Debug.Log("Hola");
        if (!player.HasKitchenObject())
        {
            StartCoroutine(RollLever(player));
        }
        else
        {
            Debug.Log("ERROR, you already have candy");
        }
    }

    private void Start()
    {
        candyPool = new(candyMachine.CandyObjectSO.prefab.gameObject, candisParent, candyMachine.Quantity);

        candyPool.FillPool();

        StartCoroutine(FillMachine());
    }

    private IEnumerator FillMachine()
    {
        foreach (GameObject candy in candyPool.Pool)
        {
            candy.transform.SetPositionAndRotation(candyPool.Parent.position, Quaternion.identity);
            candy.transform.parent = candyPool.Parent;
            candy.SetActive(true);

            float secondsElapsed = 0;
            while (secondsElapsed < candyMachine.FillInterval)
            {
                secondsElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

    private IEnumerator RollLever(PlayerController player)
    {
        animator.SetTrigger("roll");
        yield return new WaitForSeconds(leverAnimation.length);

        GameObject candy = candyDetector.GetObject();

        if (candy != null)
        {
            candy.GetComponent<Collider>().enabled = false;
            candy.GetComponent<Rigidbody>().useGravity = false;
            candy.GetComponent<Rigidbody>().Sleep();
            candy.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
        else
        {
            StartCoroutine(FillMachine());
        }
    }
}
