using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    [SerializeField] private AudioClip _musicClip;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }


    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        _musicSource.PlayOneShot(_musicClip);
        
    }

    public void ChangeMusicVolume(float vol)
    {
        _musicSource.volume = vol;
    }

    public void ChangeEffectsVolume(float vol)
    {
        _effectsSource.volume = vol;
    }

    public float getMusicVolume()
    {
        return _musicSource.volume;
    }

    public float getSfxVolume()
    {
        return _effectsSource.volume;
    }
}
