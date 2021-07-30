using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float speed;

    private Vector2 distination;
    private Vector2 startpt;
    private float percentComplete;

    // Update is called once per frame
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

    void OnEnable()
    {
        startpt = transform.position;
        distination = Weapon.mousePos;
    }

    void OnDisable()
    {
        percentComplete = 0.0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
