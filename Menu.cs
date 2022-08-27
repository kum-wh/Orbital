using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This class handles the pause function during game play.
public class Menu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    //Set Pause Menu to inactive and resume gameplay.
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Set Pause Menu to active and pause gameplay.
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //Return the user to the home scene.
    public void Home()
    {
        setvol.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //Quit the game.
    public void Quit()
    {
        Application.Quit();
    }

    //This function is called every frame to check if the Esc key is pressed.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
