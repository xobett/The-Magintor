using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
}
