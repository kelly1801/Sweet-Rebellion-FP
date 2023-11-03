using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private AudioManager.AudioType type = AudioManager.AudioType.Null;
    #endregion

    #region privatefields
    private Slider slider;
    #endregion

    #region privatemethods
    private void Start()
    {
        if (type == AudioManager.AudioType.Null)
        {
            Debug.Log($"{gameObject.name}: The audio type is null");
        }
        else
        {
            slider = gameObject.GetComponent<Slider>();
            slider.value = AudioManager.GetVolume(type);
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        SetVolume(value);
    }

    private void SetVolume(float value)
    {
        AudioManager.SetVolume(type, value);
    }
    #endregion
}