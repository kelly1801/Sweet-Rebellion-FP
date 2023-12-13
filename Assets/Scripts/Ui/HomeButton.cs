using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HomeButton : MonoBehaviour
{
    #region privatefields
    private Button _button;
    #endregion

    #region privatemethods
    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(GoHome);
    }

    private void GoHome()
    {
        Audio.Stop();
        UnpauseGame();
        ScenesManager.Scene = "Home";
    }

    private void UnpauseGame()
    {
        if (GameManager.Pause)
        {
            GameManager.Pause = false;
        }
    }
    #endregion
}