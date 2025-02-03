using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject centerDot;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsSystem;
    [SerializeField] private GameObject controlsSystem;

    [SerializeField] private string sceneToLoad;

    public bool pausedMenu = false;

    private GameObject audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        centerDot = transform.parent.GetChild(1).gameObject;
    }

    void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausedMenu)
        {
            audioManager.GetComponentInChildren<AudioLowPassFilter>().enabled = true;

            Time.timeScale = 0f;

            pausedMenu = true;
            centerDot.SetActive(false);
            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausedMenu)
        {
            DeactivateOpenSystems();

            audioManager.GetComponentInChildren<AudioLowPassFilter>().enabled = false;

            Time.timeScale = 1;

            pausedMenu = false;
            centerDot.SetActive(true);
            pausePanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void DeactivateOpenSystems()
    {
        settingsSystem.SetActive(false);
        controlsSystem.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausedMenu = false;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.GetComponentInChildren<AudioLowPassFilter>().enabled = false;
    }

    public void ShowSettings()
    {
        settingsSystem.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void HideSettings()
    {
        settingsSystem.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ShowControls()
    {
        controlsSystem.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void HideControls()
    {
        controlsSystem.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void LoadMainMenu()
    {
        audioManager.GetComponentInChildren<AudioLowPassFilter>().enabled = true;
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

}
