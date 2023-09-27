using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = SoundManager.Instance.getMusicVolume();
        sfxSlider.value = SoundManager.Instance.getSfxVolume();

        musicSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.ChangeMusicVolume(value);
        });
        sfxSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.ChangeEffectsVolume(value);
        });
        
    }
}
