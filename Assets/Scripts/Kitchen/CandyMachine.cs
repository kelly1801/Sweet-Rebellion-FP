using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CandyMachine : InteractableObject
{
    [Header("POOL")]
    [SerializeField] private ObjectPool candyPool;
    [SerializeField][Min(0)] private float fillInterval;

    [Header("OUTPUT")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip leverAnimation;
    [SerializeField] private Transform exitPoint;

    [Header("OTHERS")]
    [SerializeField] private ObjectDetector candyDetector;

    public override void Interact(PlayerController player)
    {
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
        if (candyPool != null)
        {
            StartCoroutine(FillMachine());
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

            try
            {
                candy.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            }
            catch (Exception e)
            {
                Debug.Log("This object in pool is not a valid KitcheObject");
                Debug.LogException(e);
            }
        }
        else
        {
            StartCoroutine(FillMachine());
        }
    }

    private IEnumerator FillMachine()
    {
        foreach (GameObject candy in candyPool.Pool)
        {
            candy.transform.SetPositionAndRotation(candyPool.Parent.position, Quaternion.identity);
            candy.transform.parent = candyPool.Parent;
            candy.SetActive(true);

            float secondsElapsed = 0;
            while (secondsElapsed < fillInterval)
            {
                secondsElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

}
