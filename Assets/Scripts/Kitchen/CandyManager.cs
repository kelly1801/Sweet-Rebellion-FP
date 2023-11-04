using System;
using System.Collections;
using UnityEngine;

public class CandyManager : InteractableObject
{
    [Header("POOL")]
    [SerializeField] private CandyMachine candyMachine = null;
    [SerializeField] private Transform candiesParent = null;

    [Header("VISUALS")]
    [SerializeField] private Transform fakeCandiesParent = null;

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
            Debug.Log("ERROR, you already have candy");
        }
    }

    private void Start()
    {
        candyPool = new(candyMachine.Candy, candiesParent, candyMachine.CandiesQuantity);

        candyPool.FillPool();

        StartCoroutine(FillMachineVisually());

        GameObject exitCandy = Instantiate(candyMachine.Candy, exitPoint.position, Quaternion.identity);
        exitCandy.transform.parent = exitPoint;
    }

    private IEnumerator FillMachineVisually()
    {
        for (int i = 0; i < candyMachine.FakeCandiesQuantity; i++)
        {
            GameObject candyInstance = Instantiate(candyMachine.FakeCandy, fakeCandiesParent.position, Quaternion.identity);
            candyInstance.transform.parent = fakeCandiesParent;
            candyInstance.SetActive(true);
            yield return new WaitForSeconds(candyMachine.FillSeconds);
            yield return null;
        }

        yield return new WaitForSeconds(10f);

        foreach (Transform fakeCandy in fakeCandiesParent)
        {
            Rigidbody rigidBody = fakeCandy.gameObject.GetComponent<Rigidbody>();
            Destroy(rigidBody);

            Collider collider = fakeCandy.gameObject.GetComponent<Collider>();
            Destroy(collider);
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
