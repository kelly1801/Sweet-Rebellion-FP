using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerFiller : ImageFiller
{

    private float gameSeconds;

    protected new void Start()
    {
        base.Start();

        FillAmount = 100;

        gameSeconds = GameManager.Instance.GameMinutes * 60f;
    }

    private void FixedUpdate()
    {
        this.Fill(GameManager.Instance.RemainingSeconds, gameSeconds);
    }

}