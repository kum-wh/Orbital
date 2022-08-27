using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the scripts for the actions that can be done on the main menu screen.
public class Mainmenu : MonoBehaviour
{

    //Settings for full screen
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //Quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
