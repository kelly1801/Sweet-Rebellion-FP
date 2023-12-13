using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelActivator : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;
    #endregion

    #region privatefields
    private CrossfadeManager crossfadeManager;
    private Button _button;
    #endregion

    #region privatemethods
    private void Start()
    {
        crossfadeManager = FindFirstObjectByType<CrossfadeManager>();
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(() => crossfadeManager.Activate(currentPanel, nextPanel));
    }

    #endregion
}
