using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text nameField;

    public void UpdatePlayer(Player player)
    {
        if (player != null)
        {
            image.sprite = player.sprite;
            nameField.text = player.name;
        }
    }
}