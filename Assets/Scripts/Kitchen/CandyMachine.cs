using UnityEngine;

public class CandyMachine : MonoBehaviour
{
    [Header("PARAMETERS")]
    [SerializeField] private KitchenObjectSO candyObjectSO = null;
    [SerializeField][Tooltip("Object pooling quantity")][Min(0)] private int candiesQuantity = 0;

    [Header("FAKE CANDIES")]
    [SerializeField] private GameObject fakeCandy = null;

    private GameObject candy;
    private Sprite sprite;

    private void Awake()
    {
        candy = candyObjectSO.prefab.gameObject;
        sprite = candyObjectSO.elementIcon;
    }
    

    public GameObject Candy
    {
        get => candy;
    }

    public Sprite Sprite
    {
        get => sprite;
    }

    public int CandiesQuantity
    {
        get => candiesQuantity;
    }

    public GameObject FakeCandy
    {
        get => fakeCandy;
    }
}
