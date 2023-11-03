using UnityEngine;

public class CandyMachine : MonoBehaviour
{
    [Header("PARAMETERS")]
    [SerializeField] private KitchenObjectSO candyObjectSO = null;
    [SerializeField][Min(0)] private int quantity = 0;
    [SerializeField][Min(0)] private float fillInterval = 0;

    public KitchenObjectSO CandyObjectSO
    {
        get => candyObjectSO;
    }

    public int Quantity
    {
        get => quantity;
    }

    public float FillInterval
    {
        get => fillInterval;
    }
}
