using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AUDIO SOURCES")]
    public AudioSource backgroundAudioSource;
    public AudioSource sfxAudioSource;

    [Header("SFX CLIPS")]
    public AudioClip brushReturnToPlayerClip;
    public AudioClip throwBrushClip;
    public AudioClip teleportToBrushClip;
    public AudioClip brushTouchingBubbleClip;
    public AudioClip bubbleCollisionClip;
    public AudioClip playerDeathClip;
    public AudioClip destroyedPaintDoorClip;
    public AudioClip unlockedDoorClip;

    [Header("UI & MUSIC CLIPS")]
    public AudioClip menuMusic;
    public AudioClip backgroundMusic;
    public AudioClip mouseOverSelection;
    public AudioClip mousePressingSelection;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        PlayBackground(menuMusic);
    }

    public void PlaySfx(AudioClip sfxClip)
    {
        sfxAudioSource.clip = sfxClip;
        sfxAudioSource.Play();
    }

    public void PlayBackground(AudioClip backgroundClip)
    {
        backgroundAudioSource.clip = backgroundClip;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();
    }

    public void PlayButtonOver()
    {
        sfxAudioSource.clip = mouseOverSelection;
        sfxAudioSource.Play();
    }

    public void PlayButtonPressing()
    {
        sfxAudioSource.clip= mousePressingSelection;
        sfxAudioSource.Play();
    }
}
