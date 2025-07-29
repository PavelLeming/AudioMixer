using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    private const string _music = "Music";
    private const string _master = "Master";
    private const string _effects = "Effects";

    [SerializeField] private AudioMixerGroup _audioMixer;

    private bool _isMute = false;
    private float _masterVolume = 1;
    private float _musicVolume = 1;
    private float _effectsVolume = 1;

    public void Mute()
    {
        if (_isMute)
        {
            _isMute = !_isMute;
            ChangeMusicVolume(_musicVolume);
            ChangeEffectsVolume(_effectsVolume);
            ChangeMasterVolume(_masterVolume);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_master, -80);
            _isMute = !_isMute;
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        if (_isMute == false)
        {
            _audioMixer.audioMixer.SetFloat(_music, Mathf.Log10(volume) * 20);
        }

        _musicVolume = volume;
    }

    public void ChangeEffectsVolume(float volume)
    {
        if (_isMute == false)
        {
            _audioMixer.audioMixer.SetFloat(_effects, Mathf.Log10(volume) * 20);
        }

        _effectsVolume = volume;
    }

    public void ChangeMasterVolume(float volume)
    {
        if (_isMute == false)
        {
            _audioMixer.audioMixer.SetFloat(_master, Mathf.Log10(volume) * 20);
        }

        _masterVolume = volume;
    }
}
