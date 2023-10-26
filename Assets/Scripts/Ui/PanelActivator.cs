using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;

    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        nextPanel.SetActive(true);
        currentPanel.SetActive(false);
    }
}
