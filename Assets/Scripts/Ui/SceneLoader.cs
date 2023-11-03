using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region publicstaticmethods
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void LoadNextScene()
    {
        ScenesManager.Scene++;
    }

    public static void LoadFirstScene()
    {
        ScenesManager.Scene = 0;
    }

    public static void LoadLastScene()
    {
        ScenesManager.Scene = ScenesManager.ScenesQuantity - 1;
    }
    #endregion
}