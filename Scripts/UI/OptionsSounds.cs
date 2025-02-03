using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSounds : MonoBehaviour
{
    public void PlayMousePressing()
    {
        AudioManager.instance.sfxAudioSource.clip = AudioManager.instance.mousePressingSelection;
        AudioManager.instance.sfxAudioSource.Play();
    }

    public void PlayMouseOver()
    {
        AudioManager.instance.sfxAudioSource.clip = AudioManager.instance.mouseOverSelection;
        AudioManager.instance.sfxAudioSource.Play();
    }
}
