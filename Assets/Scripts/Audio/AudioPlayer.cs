using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private new Audio audio;

    public void PlaySound()
    {
        if (audio == null)
        {
            Debug.Log($"{gameObject.name}: audio (Audio instance) is null");
        }
        else
        {
            audio.AudioSource.Play();
        }
    }
}
