using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ImageFiller : MonoBehaviour
{
    private Image image;

    public float FillAmount {
        get => image.fillAmount;
        set => image.fillAmount = value;
    }

    protected void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void Fill(float remainingValue, float totalValue)
    {
        image.fillAmount = remainingValue / totalValue;
    }

}