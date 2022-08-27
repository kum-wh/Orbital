using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class handle the transition of one scene to another.
public class levelloader : MonoBehaviour
{
    public Animator transtion;

    //This function is called when the user select the setting page.
    public void LoadSettings()
    {
        StartCoroutine(LoadLevel(1));
    }

    //This function is called when the user select level 1.
    public void Load1()
    {
        StartCoroutine(LoadLevel(2));
    }

    //This function is called when the user select level 2.
    public void Load2()
    {
        StartCoroutine(LoadLevel(3));
    }

    //This function is called when the user select level 3.
    public void Load3()
    {
        StartCoroutine(LoadLevel(4));
    }

    //This function is called when the user select level 4.
    public void Load4()
    {
        StartCoroutine(LoadLevel(5));
    }

    //This function is called when the back button is pressed to load the home screen.
    public void back()
    {
        StartCoroutine(LoadLevel(0));
    }
    
    //This function is callled to load a certain scene with a transition animation.
    IEnumerator LoadLevel(int levelIndex)
    {
        if (setvol.paused == true)
        {
            Time.timeScale = 1f;
            setvol.paused = false;
        }
        transtion.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(levelIndex);
    }
}
