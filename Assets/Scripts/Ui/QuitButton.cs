using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    #region privatefields
    private Button _button;
    #endregion

    #region privatemethods
    private void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
            gameObject.SetActive(true);
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(QuitGame);
        #else
            gameObject.SetActive(false);
        #endif
    }

    private static void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
