using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the movement artificial intelligence of the enermy game object.
public class Enermy1 : MonoBehaviour
{
    public int type;
    private float moveSpeed;
    private float lookraduis;
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 movement;
    private bool difficulty;

    // Start is called before the first frame update to set the move speed of the enermy game object.
    void Start()
    {
        difficulty = setvol.isHard;
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        lookraduis = 6f;
        if (difficulty == true)
        {
            if(type == 0)
            {
                moveSpeed = 3f;
            }
            else
            {
                moveSpeed = 2f;
            }
        }
        else
        {
            if (type == 0)
            {
                moveSpeed = 2.5f;
            }else
            {
                moveSpeed = 2f;
            }
        }
    }

    // Update is called once per frame to make the game object face the player.
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= lookraduis)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
    }

    //This function is called in a fixed interval to move the game object by a certain distance towards the player.
    void FixedUpdate()
    {
        moveChatacter(movement);
    }

    //This function is to move the game object.
    void moveChatacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
