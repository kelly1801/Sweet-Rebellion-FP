using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerFiller : ImageFiller
{

    private float gameSeconds;

    private GameManager gameManager;

    protected new void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        base.Start();

        FillAmount = 100;

        gameSeconds = gameManager.GameMinutes * 60f;
    }

    private void FixedUpdate()
    {
        this.Fill(gameManager.RemainingSeconds, gameSeconds);
    }

}