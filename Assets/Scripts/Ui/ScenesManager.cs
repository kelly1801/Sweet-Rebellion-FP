using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    #region publicstaticfields
    public static ScenesManager Instance { get => instance; }
    public static int ScenesQuantity { get => scenesQuantity; }
    #endregion

    #region privatestaticfields
    private static ScenesManager instance;
    private static UnityEvent onSceneChange;
    private static int scene;
    private static readonly int scenesQuantity = 4;
    private static readonly int loadSceneAfter = 1; // seconds
    #endregion

    #region publicstaticproperties
    public static int Scene
    {
        get { return scene; }
        set
        {
            scene = value;
            onSceneChange?.Invoke();
            if (Instance == null)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
    #endregion

    #region publicfields
    public delegate void OpenLevelDelegate();
    public delegate void ExitLevelDelegate();
    public delegate void QuitGameDelegate();

    public OpenLevelDelegate openLevelEvent;
    public ExitLevelDelegate exitLevelEvent;
    public QuitGameDelegate quitGameEvent;
    #endregion

    #region privatemethods
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scene = 0;

        SceneManager.sceneLoaded += OnEsceneLoaded;

        onSceneChange = new();
        onSceneChange.AddListener(OnSceneChanged);

        Application.wantsToQuit += OnGameQuited;
    }

    private void OnEsceneLoaded(Scene scene, LoadSceneMode modo)
    {
        openLevelEvent?.Invoke();
    }

    private bool OnGameQuited()
    {
        quitGameEvent?.Invoke();
        float secondsElapsed = 0;
        while (secondsElapsed < loadSceneAfter)
        {
            secondsElapsed += Time.deltaTime;
        }
        return true;
    }

    private void OnSceneChanged()
    {
        exitLevelEvent();
        StartCoroutine(LoadScene(scene, loadSceneAfter));
    }
    #endregion

    #region coroutines
    private IEnumerator LoadScene(int scene, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
    #endregion
}
