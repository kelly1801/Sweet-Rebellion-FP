using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MoneyFiller : ImageFiller
{

    [SerializeField] private string moneyPlaceholder = "";
    [SerializeField] private TMP_Text moneyField;

    [SerializeField] private string moneyGoalPlaceholder = "";
    [SerializeField] private TMP_Text moneyGoalField;

    [SerializeField] private string percentagePlaceholder = "";
    [SerializeField] private TMP_Text percentageField;

    private GameManager gameManager;

    protected new void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();

        base.Start();

        FillAmount = 0;

        if (moneyField != null)
        {
            moneyField.text = $"{moneyPlaceholder}$0";
        }
        if (moneyGoalField != null)
        {
            moneyGoalField.text = $"{moneyGoalPlaceholder}$0";
        }
        if (percentageField != null)
        {
            percentageField.text = $"{percentagePlaceholder}$0";
        }
    }

    private void FixedUpdate()
    {
        this.FillAmount = gameManager.payedDebt / gameManager.DebtGoal;

        if (moneyField != null)
        {
            moneyField.text = $"{moneyPlaceholder}${gameManager.payedDebt}";
        }

        if (moneyGoalField != null)
        {
            moneyGoalField.text = $"{moneyGoalPlaceholder}${gameManager.DebtGoal}";
        }

        if (percentageField != null)
        {
            string p = $"{FillAmount * 100}";
            percentageField.text = $"{percentagePlaceholder}{p}%";
        }
    }
}