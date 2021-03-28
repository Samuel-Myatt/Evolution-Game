using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static HUDScript;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject menu;
    public GameObject HUD;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
       
        menu.SetActive(false);
        
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pause()
    {
        
        menu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
