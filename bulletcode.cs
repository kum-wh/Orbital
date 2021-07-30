using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcode : MonoBehaviour
{
    public int number;
    private int counter = 0;
    
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
