using UnityEngine;

public class SelectedInteractable : MonoBehaviour
{
    [SerializeField] private GameObject visualObject;
    [SerializeField] private InteractableObject interactableObject;

    private PlayerController playerController;

    private void Start()
    { 
        playerController = FindAnyObjectByType<PlayerController>();
        playerController.OnSelectedElementChanged += Player_OnSelectedElementChanged;
    }

    private void Player_OnSelectedElementChanged(object sender, PlayerController.OnSelectedElementChangedEventArgs e)
    {
        
        InteractableObject selectedInteractableObject = e.selectedInteractableObject;
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
