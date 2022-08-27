using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the script for the bullet game object.
public class bulletcode : MonoBehaviour
{
    public int number;
    private int counter = 0;
    
    //This function destroys the bullet after a certain amount of time.
    void FixedUpdate()
    {
        if (counter == number)
        {
            Destroy(gameObject);
        }
        else
        {
            counter += 1;
        }
    }

    //This function destroys the bullet when the bullet collides with anything object other than a type of bullet object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tagg = collision.gameObject.tag;
        if (tagg == "bullet")
        {
            return;
        }else if(tagg == "bullet2")
        {
            return;
        }else if(tagg == "bullet3")
        {
            return;
        }
        Destroy(gameObject);
    }
}
