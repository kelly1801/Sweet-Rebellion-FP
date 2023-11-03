using UnityEngine;

public static class AudioManager
{
    public enum AudioType
    {
        Music,
        Sound,
        Null
    }

    public static float GetVolume(AudioType type)
    {
        return type switch
        {
            AudioType.Music => MusicAudio.Volume,
            AudioType.Sound => SoundAudio.Volume,
            _ => 0f,
        };
    }

    public static void SetVolume(AudioType type, float volume)
    {
        switch (type)
        {
            case AudioType.Music:
                MusicAudio.Volume = volume;
                break;
            case AudioType.Sound:
                SoundAudio.Volume = volume;
                break;
            case AudioType.Null:
                break;
        };
    }
}