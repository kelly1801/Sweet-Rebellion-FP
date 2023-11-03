using UnityEngine;
using UnityEngine.Events;

// audio manager class
public abstract class Audio : MonoBehaviour
{
    #region serializedfields
    [SerializeField] protected float multiplier = 1f;
    #endregion

    #region publicstaticfields
    private static readonly UnityEvent audioStopped = new();
    #endregion

    #region privatefields
    protected AudioSource audioSource;
    #endregion

    #region publicproperties
    public AudioSource AudioSource { get => audioSource; }
    #endregion

    #region protectedabstractmethods
    protected abstract void SetVolume();
    #endregion

    #region publicstaticmethods
    public static void Play(Audio audio, AudioClip clip, float volumeScale = 1f)
    {
        audio.audioSource.PlayOneShot(clip, volumeScale);
    }

    public static void Stop()
    {
        audioStopped?.Invoke();
    }
    #endregion

    #region protectedmethods
    protected void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        audioStopped.AddListener(OnAudioStopped);

        GameManager.OnPauseEvent += Pause;
    }
    #endregion

    #region privatemethods
    private void OnAudioStopped()
    {
        audioSource.Stop();
    }

    private void Pause()
    {
        if (GameManager.Pause)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    private void OnDestroy()
    {
        GameManager.OnPauseEvent -= Pause;
    }
    #endregion
}
