using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class handles the movement of the player object.
public class player4 : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    private float moveSpeed;
    private bool difficulty;
    string animationState = "AnimationState";

    Vector2 movement;
    Vector2 mousePos;

    enum CharStates
    {
        left = 1,
        down = 2,
        right = 3,
        up = 4,

        idle = 5
    }

    //This function is called at the start to initialize the player movement speed.
    void Start()
    {
        moveSpeed = 2.5f;
    }

    // Update is called once per frame to update the movement vector of the player.
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        UpdateState();
    }

    //This function is called repeatedly with a interval to move the player object.
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb2.transform.position = rb.transform.position;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2.rotation = angle;
        rb.rotation = 0f;
    }

    //This function is called to update the animation state of the player object.
    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.right);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.left);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.down);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.up);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idle);
        }
    }
}
