using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class ObjectAudio : Audio
{
    private static readonly UnityEvent volumeChanged = new();

    #region publicstaticproperties
    public static float Volume
    {
        get => PlayerPrefs.GetFloat(nameof(SoundAudio), 0.2f);
        set
        {
            PlayerPrefs.SetFloat(nameof(SoundAudio), value);
            volumeChanged?.Invoke();
        }
    }
    #endregion

    #region protectedmethods
    protected override void SetVolume()
    {
        audioSource.volume = Volume * multiplier;
    }
    #endregion

    #region privatemethods
    private new void Awake()
    {
        base.Awake();

        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0.5f;

        volumeChanged.AddListener(SetVolume);

        SetVolume();
    }
    #endregion
}