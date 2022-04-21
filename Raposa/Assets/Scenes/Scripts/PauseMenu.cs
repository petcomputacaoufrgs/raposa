using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject MapUI;
    private bool inMenu = false;
    private bool inMap = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && inMenu)
            {
                PauseMenuUI.SetActive(false);
                inMenu = false;
                Resume();
            }
            else if (!inMap)
            {
                PauseMenuUI.SetActive(true);
                inMenu = true;
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameIsPaused && inMap)
            {
                MapUI.SetActive(false);
                inMap = false;
                Resume();
            }
            else if (!inMenu)
            {
                MapUI.SetActive(true);
                inMap = true;
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //todo
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
