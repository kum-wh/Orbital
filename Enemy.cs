using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int type;
    [HideInInspector]
    public int damageStrength;
    public AudioClip landingAudio;
    private int startingHitPoints;
    private int currhealth;
    private bool difficulty;
     
    void Start()
    {
        difficulty = setvol.isHard;
        if (type == 0)
        {
            startingHitPoints = 1;
            damageStrength = 1;
        }
        else if (type == 1)
        {
            if (difficulty == true)
            {
                startingHitPoints = 3;
                damageStrength = 2;
            }
            else
            {
                startingHitPoints = 2;
                damageStrength = 1;
            }
        }
        else
        {
            if(difficulty == true)
            {
                startingHitPoints = 5;
                damageStrength = 1;
            }
            else
            {
                startingHitPoints = 3;

                damageStrength = 1;
            }
        }
        currhealth = startingHitPoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagg = collision.gameObject.tag;
        if (tagg == "bullet")
        {
            takeDamage(1);
        }
        if (tagg == "bullet2")
        {
            takeDamage(3);
        }
    }

    private void takeDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(landingAudio, Camera.main.transform.position);
        if (currhealth != 0)
        {
            currhealth = currhealth - damage;
        }
        if(currhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
