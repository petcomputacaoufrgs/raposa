using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && !Map.InMap)
            {
                MenuResume();
            }
            else if (Map.InMap)
            {
                FindObjectOfType<Map>().MapResume();
                Pause();
            }
            else
            {
                Pause();
            }
        }
    }           
    public void MenuResume()
    {
        PauseMenuUI.SetActive(false);
        FindObjectOfType<PlayerControl>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        FindObjectOfType<PlayerControl>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //todo
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
