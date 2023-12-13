using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public event EventHandler VictoryEvent;
    public event EventHandler GameOverEvent;

    [SerializeField, Min(0), Tooltip("Minutes")] private float gameDuration = 5f;
    [SerializeField, Min(0)] private int debtGoal;

    public int DebtGoal
    {
        get => debtGoal;
    }

    public float payedDebt;
    private bool victoryTriggered = false;

    public float GameMinutes
    {
        get => gameDuration;
    }

    private float remainingSeconds = 999999999;

    public float RemainingSeconds
    {
        get => remainingSeconds;
    }

    private bool hurryUp;

    private static bool gameOver = false;
    public bool GameOver { get => gameOver; set => gameOver = value; }

    public delegate void PauseDelegate();
    public static event PauseDelegate PauseEvent;

    public delegate void HurryUpDelegate();
    public event HurryUpDelegate HurryUpEventDelegate;

    public delegate void GameOverDelegate();
    public event GameOverDelegate GameOverEventDelegate;

    public delegate void VictoryDelegate();
    public event VictoryDelegate VictoryEventDelegate;

    private PlayerController playerController;

    private void Start(){
        playerController = FindAnyObjectByType<PlayerController>();

        StartCoroutine(StartTimer(gameDuration));
    }

    private void Update()
    {
        if (payedDebt == debtGoal && !victoryTriggered)
        {
            victoryTriggered = true;
            Debug.Log("YOU PAYED YOUR DEEEEEEEEEEBT");
            OnVictory();
        }

        /*
        // Calculate remaining time in minutes and seconds
        float timeRemaining = Mathf.Max(timerDurationInMinutes * 60 - Time.timeSinceLevelLoad, 0);
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining) % 60;

        // Update the TextMeshPro text
        durationText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        */
    }

    private IEnumerator StartTimer(float durationInMinutes)
    {
        hurryUp = false;

        float totalSeconds = durationInMinutes * 60;

        remainingSeconds = totalSeconds;

        while (remainingSeconds > 0 && payedDebt < debtGoal)
        {
            yield return new WaitForSeconds(1f);
            remainingSeconds -= 1;

            if (hurryUp == false && remainingSeconds < totalSeconds * 0.25f)
            {
                hurryUp = true;
                OnHurryUp();
            }
        }

        if (payedDebt < debtGoal)
        {
            OnGameOver();
        }
        else
        {
            OnVictory();
        }
    }

    public static bool Pause
    {
        get { return Time.timeScale == 0; }
        set { Time.timeScale = value ? 0 : 1; OnPaused(); }
    }
    // event invocations
    public static void OnPaused()
    {
        PauseEvent?.Invoke();
    }

    public void OnHurryUp()
    {
        HurryUpEventDelegate?.Invoke();
    }

    private void OnVictory()
    {
        gameOver = false;
        playerController.enabled = false;
        VictoryEventDelegate();
        VictoryEvent?.Invoke(this, EventArgs.Empty);
    }

    public void OnGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        GameOverEventDelegate();
        GameOverEvent?.Invoke(this, EventArgs.Empty);
    }
}
