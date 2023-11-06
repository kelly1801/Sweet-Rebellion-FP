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

    protected new void Start()
    {
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
        this.FillAmount = GameManager.Instance.payedDebt / GameManager.Instance.DebtGoal;

        if (moneyField != null)
        {
            moneyField.text = $"{moneyPlaceholder}${GameManager.Instance.payedDebt}";
        }
        if (moneyGoalField != null)
        {
            moneyGoalField.text = $"{moneyGoalPlaceholder}${GameManager.Instance.DebtGoal}";
        }
        if (moneyGoalField != null)
        {
            string p = $"{FillAmount * 100}";
            percentageField.text = $"{percentagePlaceholder}{p}%";
        }
    }
}