using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static HUDScript;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}