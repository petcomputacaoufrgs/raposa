using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static bool InMap = false;
    public GameObject MapUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (InMap)
            {
                MapResume();
            }
            else if(PauseMenu.GameIsPaused)
            {
                FindObjectOfType<PauseMenu>().MenuResume();
                SetMap();
            }
            else
            {
                SetMap();
            }
        }
    }
    public void MapResume()
    {
        MapUI.SetActive(false);
        FindObjectOfType<PlayerControl>().enabled = true;
        Time.timeScale = 1f;
        InMap = false;
        PauseMenu.GameIsPaused = false;
    }
    public void SetMap()
    {
        MapUI.SetActive(true);
        FindObjectOfType<PlayerControl>().enabled = false;
        Time.timeScale = 0f;
        InMap = true;
        PauseMenu.GameIsPaused = true;
    }

}
