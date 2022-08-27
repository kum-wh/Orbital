using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contain the script for the second type of bullet game object.
public class bullet2 : MonoBehaviour
{
    public float speed;

    private Vector2 distination;
    private Vector2 startpt;
    private float percentComplete;

    // Update is called once per frame to update the movement of the bullet object
    void FixedUpdate()
    {
        if (gameObject.activeSelf == true)
        {
            if(percentComplete >= 1.0f)
            {
                gameObject.SetActive(false);
            }
            percentComplete += Time.deltaTime / speed;
            float currentHeight = Mathf.Sin(Mathf.PI * percentComplete);
            if (distination.y - startpt.y < 0)
            {
                transform.position = Vector2.Lerp(startpt, distination, percentComplete) + Vector2.down * currentHeight;
            }
            else
            {
                transform.position = Vector2.Lerp(startpt, distination, percentComplete) + Vector2.up * currentHeight;
            }
        }
    }

    //As this bullet type uses object pooling, this function set the position of the bullet when it "fired" by setting it position and setting it active.
    void OnEnable()
    {
        startpt = transform.position;
        distination = Weapon.mousePos;
    }

    //Set the neccessasry variable back to their initial value on disable.
    void OnDisable()
    {
        percentComplete = 0.0f;
    }

    //Disable the game object on collision with other objects.
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
