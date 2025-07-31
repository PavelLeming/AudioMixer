using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameterName;
    [SerializeField] private TurnOffOnButtonSettings _turnOffOnButtonSettings;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        if (_turnOffOnButtonSettings._isMuted == false)
        {
            if (volume == 0)
            {
                _audioMixer.audioMixer.SetFloat(_exposedParameterName, -80);
            }
            else
            {
                _audioMixer.audioMixer.SetFloat(_exposedParameterName, Mathf.Log10(volume) * 20);
            }
        }
    }
}
