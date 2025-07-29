using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void PlaySound()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
