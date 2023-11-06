using System.Collections;
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
    #endregion

    #region publicmethods
    public void Pause()
    {
        if (GameManager.Pause)
        {
            Continue();
        }
        else
        {
            Stop();
        }
    }
    #endregion

    #region privatemethods
    private void Start()
    {
        pausePanel.gameObject.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(PlayAsynchronically());
        }
    }

    private IEnumerator PlayAsynchronically()
    {
        if (audio != null)
        {
            Audio.Play(audio, clip, 1.5f);
        }
        yield return new WaitForSeconds(1);
        Pause();
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
