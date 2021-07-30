using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class setvol : MonoBehaviour
{
    public AudioMixer mixer;
    public static bool isHard = false;
    public static bool paused = false;
    private setvol instance;
    
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

    public void SetLevel(float slidervalue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(slidervalue) * 20);
    }

    public void changedifficulty()
    {
        isHard = !isHard;//changes difficulty
    }
}
