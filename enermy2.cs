using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the script for the enemy game object that can fire projectiles.
public class enermy2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;
    public Rigidbody2D rb3;
    private bool difficulty;
    private float moveSpeed;
    private float lookraduis;
    private int interval;
    private int bulletForce;
    private GameObject player;
    private int counter;
    private Vector2 movement;
    private float distance;

    // Start is called before the first frame update to set the neccessary variable of the enemy object.
    void Start()
    {
        moveSpeed = 1;
        lookraduis = 6f;
        difficulty = setvol.isHard;
        player = GameObject.Find("player");
        if(difficulty == true)
        {
            interval = 115;
            bulletForce = 8;
        }
        else
        {
            interval = 130;
            bulletForce = 6;
        }
    }

    // Update is called once per frame to make the game object face the player.
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= lookraduis)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 80f;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    //This function is called in a fixed interval that move the game object towards the player and fire a projectile with a longer interval.
    void FixedUpdate()
    {
        if (distance <= lookraduis)
        {
            if (counter == interval)
            {
                counter = 0;
                shoot();
            }
            else
            {
                counter += 1;
            }
        }
        moveChatacter(movement);
    }

    //This function moves the game object by a certain distance.
    void moveChatacter(Vector2 direction)
    {
        rb3.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.transform.position = rb3.transform.position;
    }
    
    //This function is called to create a bullet object and fire it towards the player.
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
