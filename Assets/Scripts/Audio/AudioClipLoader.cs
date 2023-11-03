using System;
using UnityEngine;

public class AudioClipLoader : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private new Audio audio;
    [SerializeField] private AudioClip clip;
    #endregion

    #region privatemethods
    private void Start()
    {
        if (audio == null)
        {
            Debug.Log($"{gameObject.name}: audio (Audio instance) is null");
        }
        else
        {
            AudioSource audioSource = audio.AudioSource;
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    #endregion
}
