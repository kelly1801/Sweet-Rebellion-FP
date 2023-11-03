using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("LEVEL")]
    [SerializeField] private float levelTime;
    [SerializeField] private int ingredientsQuantity;

    //[Header("RECIPES")]
    //[SerializeField] private [] ingredientsQuantity;

    private static bool gameOver = false;
    public static bool GameOver { get => gameOver; set => gameOver = value; }

    public delegate void PauseDelegate();
    public static event PauseDelegate OnPauseEvent;

    public static bool Pause
    {
        get { return Time.timeScale == 0; }
        set { if (value) { Time.timeScale = 0; } else { Time.timeScale = 1; } OnPaused(); }
    }

    public static void OnPaused()
    {
        OnPauseEvent?.Invoke();
    }

}
