using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMusic : MonoBehaviour
{
    private void Start()
    {
        var actualScene = SceneManager.GetActiveScene();

        if (actualScene.name == "Start Menu" || actualScene.name == "Final Credits")
        {
            AudioManager.instance.PlayBackground(AudioManager.instance.menuMusic);
        }
        else
        {
            AudioManager.instance.PlayBackground(AudioManager.instance.backgroundMusic);

        }
    }
}
