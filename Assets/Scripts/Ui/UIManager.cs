using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("INI")]
    [SerializeField] private AnimationClip readyClip;
    [SerializeField] private GameObject readyPanel;

    [Header("MID")]
    [SerializeField] private AnimationClip hurryUpClip;
    [SerializeField] private GameObject hurryUpPanel;

    [Header("END")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    private void Start()
    {
        StartCoroutine(ActivateReadyPanel());

        GameManager.HurryUpEventDelegate += () => StartCoroutine(ActivateHurryUpPanel());
        GameManager.GameOverEventDelegate += ActivateGameOverPanel;
        GameManager.VictoryEventDelegate += ActivateVictoryPanel;

        readyPanel.SetActive(true);
        hurryUpPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    private IEnumerator ActivateReadyPanel()
    {
        GameManager.Instance.enabled = false;

        readyPanel.SetActive(true);

        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.enabled = false;

        float musicVolume = MusicAudio.Volume;
        float soundVolume = SoundAudio.Volume;

        MusicAudio.Volume /= 1.5f;
        SoundAudio.Volume /= 1.5f;

        yield return new WaitForSeconds(readyClip.length);

        MusicAudio.Volume = musicVolume;
        SoundAudio.Volume = soundVolume;

        PlayerController.Instance.enabled = true;

        Destroy(readyPanel);

        GameManager.Instance.enabled = true;
    }

    private IEnumerator ActivateHurryUpPanel()
    {
        hurryUpPanel.SetActive(true);
        yield return new WaitForSeconds(hurryUpClip.length);
        Destroy(hurryUpPanel);
    }

    private void ActivateVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    private void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

}