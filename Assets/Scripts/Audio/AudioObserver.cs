using UnityEngine;

public class AudioObserver : MonoBehaviour
{
    [SerializeField] private new Audio audio;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip victoryClip;

    private static AudioClip endingClip = null;
    public static AudioClip AudioClip { get => endingClip; }

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        gameManager.HurryUpEventDelegate += RunHurryUpSettings;
        gameManager.GameOverEventDelegate += RunGameOverMusic;
        gameManager.VictoryEventDelegate += RunVictoryMusic;
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
        endingClip = clip;
        NormalizePitch();
        audio.AudioSource.clip = clip;
        audio.AudioSource.Play();
    }
}