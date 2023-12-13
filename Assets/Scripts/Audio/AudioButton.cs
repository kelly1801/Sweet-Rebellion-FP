using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButton : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private AudioClip clip;
    [SerializeField] private new Audio audio = null;
    [SerializeField] private float volume = 1f;
    #endregion

    #region privatefields
    private Button button;
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
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Play);
        }
    }

    private void Play()
    {
        audio.AudioSource.PlayOneShot(clip, volume);
    }
    #endregion

}
