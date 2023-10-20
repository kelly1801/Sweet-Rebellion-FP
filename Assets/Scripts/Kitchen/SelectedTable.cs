using UnityEngine;

public class SelectedTable : MonoBehaviour
{
    [SerializeField] private GameObject visualObject;
    [SerializeField] private InteractableObject interactableObject;
     private PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.OnSelectedElementChanged += Player_OnSelectedElementChanged;
    }

    private void Player_OnSelectedElementChanged(object sender, PlayerController.OnSelectedElementChangeEventArgs e)
    {
        InteractableObject selectedInteractableObject = e.SelectedInteractableObject;
        if (selectedInteractableObject == interactableObject)
        {
            ShowVisualElements();
        }
        else
        {
            HideVisualElements();
        }
    }

    private void ShowVisualElements()
    {
        visualObject.SetActive(true);
    }

    private void HideVisualElements()
    {
        visualObject.SetActive(false);
    }
}
