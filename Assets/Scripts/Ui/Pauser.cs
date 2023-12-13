using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private Image pausePanel;
    [SerializeField] private new Audio audio;
    [SerializeField] private AudioClip clip;
    #endregion

    #region privatefields
    private PlayerController playerController;
    private bool isPausing;
    #endregion

    #region publicmethods
    public void Pause()
    {
        isPausing = true;

        Audio.Play(audio, clip, 1.5f);

        if (GameManager.Pause)
        {
            Continue();
        }
        else
        {
            Stop();
        }

        isPausing = false;
    }
    #endregion

    #region privatemethods
    private void Start()
    {
        isPausing = false;

        pausePanel.gameObject.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPausing)
        {
            Pause();
        }
    }

    private void Continue()
    {
        if (playerController != null)
        {
            playerController.enabled = true;
        }
        GameManager.Pause = false;
        pausePanel.gameObject.SetActive(false);
    }

    private void Stop()
    {
        if (playerController != null)
        {
            playerController.enabled = false;
        }
        GameManager.Pause = true;
        pausePanel.gameObject.SetActive(true);
    }

    #endregion
}
