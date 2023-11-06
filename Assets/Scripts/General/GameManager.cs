using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    public event EventHandler VictoryEvent;
    public event EventHandler GameOverEvent;

    [SerializeField, Min(0)] private float timerDurationInMinutes = 5f;
    [SerializeField] private int debtGoal;
    public int DebtGoal
    {
        get => debtGoal;
    }

    [SerializeField] private ImageFiller timerImage;

    public float payedDebt;
    private bool victoryTriggered = false;

    private float remainingSeconds = 0;
    public float RemainingSeconds
    {
        get => remainingSeconds;
    }

    public float GameMinutes
    {
        get => timerDurationInMinutes;
    }

    private static bool gameOver = false;
    public static bool GameOver { get => gameOver; set => gameOver = value; }

    public delegate void PauseDelegate();
    public static event PauseDelegate OnPauseEvent;

    [SerializeField] private string[] validSceneNames; // Array to store valid scene names

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timerImage.FillAmount = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (IsValidScene(currentSceneName))
        {
            StartCoroutine(StartTimer(timerDurationInMinutes));
        }
    }

    private bool IsValidScene(string sceneName)
    {
        foreach (string validSceneName in validSceneNames)
        {
            if (sceneName.Equals(validSceneName))
            {
                return true;
            }
        }
        return false;
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

    IEnumerator StartTimer(float durationInMinutes)
    {
        float totalSeconds = durationInMinutes * 60;
        remainingSeconds = totalSeconds;

        while (remainingSeconds > 0 && payedDebt < debtGoal)
        {
            yield return new WaitForSeconds(1f);
            remainingSeconds -= 1;
            timerImage.Fill(remainingSeconds, totalSeconds);
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
        OnPauseEvent?.Invoke();
    }

    private void OnVictory()
    {
        VictoryEvent?.Invoke(this, EventArgs.Empty);
    }

    public void OnGameOver()
    {
        Debug.Log("YOU LOOOOOOOOOOST");
        GameOverEvent?.Invoke(this, EventArgs.Empty);
    }
}
