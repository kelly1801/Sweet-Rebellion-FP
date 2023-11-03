using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIObserver : MonoBehaviour
{
    #region serializedfields
    [SerializeField] Crossfade crossfade;
    [SerializeField] ScenesManager scenesManager;
    #endregion

    #region privatemethods
    private void Start()
    {
        scenesManager.openLevelEvent += RunOpenCrossfade;
        scenesManager.exitLevelEvent += () => RunExitCrossfade();
        scenesManager.quitGameEvent += () => RunQuitCrossfade();
    }

    private void RunOpenCrossfade()
    {
        crossfade.DisappearCrossfade();
    }
    #endregion

    #region coroutines
    private void RunExitCrossfade()
    {
        crossfade.AppearCrossfade();
    }

    private void RunQuitCrossfade()
    {
        crossfade.AppearCrossfade();
    }
    #endregion
}
