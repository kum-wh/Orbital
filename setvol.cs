using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//This class contain the script for the global variables.
public class setvol : MonoBehaviour
{
    public AudioMixer mixer;
    public static bool isHard = false;
    public static bool paused = false;
    private setvol instance;
    
    //This function set all instance of this object to the first instance.
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    //This function set the volume of the music and sound effects.
    public void SetLevel(float slidervalue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(slidervalue) * 20);
    }
    
    //This function set the game difficulty.
    public void changedifficulty()
    {
        isHard = !isHard;//changes difficulty
    }
}
