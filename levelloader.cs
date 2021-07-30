using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public Animator transtion;

    public void LoadSettings()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void Load1()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void Load2()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void Load3()
    {
        StartCoroutine(LoadLevel(4));
    }
    public void Load4()
    {
        StartCoroutine(LoadLevel(5));
    }
    public void back()
    {
        StartCoroutine(LoadLevel(0));
    }
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
