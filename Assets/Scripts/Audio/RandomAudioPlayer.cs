using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField] private new Audio audio;
    [SerializeField] private AudioClip[] clips;

    public void PlayRandomSound()
    {
        if (audio == null)
        {
            Debug.Log($"{gameObject.name}: audio (Audio instance) is null");
        }
        else
        {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audio.AudioSource.PlayOneShot(clip);
        }
    }
}
