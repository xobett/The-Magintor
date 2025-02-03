using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOption : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private string creditsScene;

    [SerializeField] private GameObject settingsMenu;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(gameScene);
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync(creditsScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DisplaySettings()
    {
        settingsMenu.SetActive(true);
    }

    public void HideSettings()
    {
        settingsMenu.SetActive(false);
    }
}
