using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyAudioVolume : MonoBehaviour
{
    public Slider backgroundVolSlider;
    public Slider sfxVolSlider;

    public AudioManager manager;

    private void Awake()
    {
        backgroundVolSlider = transform.GetChild(2).transform.GetComponent<Slider>();
        sfxVolSlider = transform.GetChild(3).transform.GetComponent<Slider>();

        backgroundVolSlider.normalizedValue = AudioManager.instance.backgroundAudioSource.volume;
        sfxVolSlider.normalizedValue = AudioManager.instance.sfxAudioSource.volume; 
    }

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    public void ChangeMusicVolume()
    {
        AudioManager.instance.backgroundAudioSource.volume = backgroundVolSlider.normalizedValue;
    }

    public void ChangeSfxVolume()
    {
        AudioManager.instance.sfxAudioSource.volume = sfxVolSlider.normalizedValue;
    }

}
