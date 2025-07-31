using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameterName;
    [SerializeField] private TurnOffOnVolumeButton _turnOffOnButtonSettings;

    private float _minVolume = -80f;
    private int _volumeCoefficient = 20;

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
        if (volume == 0)
        {
            _audioMixer.audioMixer.SetFloat(_exposedParameterName, _minVolume);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_exposedParameterName, Mathf.Log10(volume) * _volumeCoefficient);
        }
    }
}
