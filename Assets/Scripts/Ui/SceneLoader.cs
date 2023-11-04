using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    #region publismethods
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    #endregion

    #region publicstaticmethods
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