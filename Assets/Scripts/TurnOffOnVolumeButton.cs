using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TurnOffOnVolumeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioListener _listener;

    public bool IsMuted { get; private set; } = false;

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
        IsMuted = !IsMuted;
        AudioListener.pause = IsMuted;
    }
}
