using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    #region publismethods
    public void LoadScene()
    {
        ScenesManager.Scene = sceneName;
    }
    #endregion
}