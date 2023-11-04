using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    [SerializeField] private PlayerSet playerSet;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        Instantiate(playerSet.players[PlayerSelector.Selection].prefab, playerTransform);
    }

}