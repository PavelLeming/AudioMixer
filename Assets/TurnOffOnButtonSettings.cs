using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TurnOffOnButtonSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Button _button;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private string _exposedParameterName;

    public bool _isMuted { get; private set; } = false;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume()
    {
        if (_isMuted == false)
        {
            _audioMixer.audioMixer.SetFloat(_exposedParameterName, -80);
            _isMuted = true;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_exposedParameterName, Mathf.Log10(_masterSlider.value) * 20);
            _isMuted = false;
        }
    }
}
