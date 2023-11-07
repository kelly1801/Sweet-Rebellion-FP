using System;
using UnityEngine;

public class AudioObserver : MonoBehaviour
{

    [SerializeField] private new Audio audio;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip victoryClip;

    private void Start()
    {
        GameManager.HurryUpEventDelegate += RunHurryUpSettings;
        GameManager.GameOverEventDelegate += RunGameOverMusic;
        GameManager.VictoryEventDelegate += RunVictoryMusic;
    }

    private void RunVictoryMusic()
    {
        RunEndingClip(victoryClip);
    }

    private void RunGameOverMusic()
    {
        RunEndingClip(gameOverClip);
    }

    private void RunHurryUpSettings()
    {
        AcceleratePitch();
    }

    private void AcceleratePitch()
    {
        audio.AudioSource.pitch = 1.25f;
    }

    private void NormalizePitch()
    {
        audio.AudioSource.pitch = 1f;
    }

    private void RunEndingClip(AudioClip clip)
    {
        NormalizePitch();
        audio.AudioSource.clip = victoryClip;
        audio.AudioSource.Play();
    }
}