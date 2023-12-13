using UnityEngine;

public class PlayerSelector : MonoBehaviour
{

    [SerializeField] private PlayerDisplay playerDisplay;

    [SerializeField] private PlayerSet playerSet;

    private Player[] players;

    private static readonly string PLAYER = "PLAYER";

    public static int Selection
    {
        get => PlayerPrefs.GetInt(PLAYER, 0);
        set => PlayerPrefs.SetInt(PLAYER, value);
    }

    private void Start()
    {
        players = playerSet.players;
        UpdatePlayerSelection(Selection);
    }

    private void UpdatePlayerSelection(int selection)
    {
        playerDisplay.UpdatePlayer(players[selection]);
    }

    public void SelectPrevPlayer()
    {
        Selection--;
        if (Selection < 0)
        {
            Selection = players.Length - 1;
        }
        UpdatePlayerSelection(Selection);
    }

    public void SelectNextPlayer()
    {
        Selection++;
        if (Selection >= players.Length)
        {
            Selection = 0;
        }
        UpdatePlayerSelection(Selection);
    }


}

