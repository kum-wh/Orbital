using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
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

    // Update is called once per frame
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

    void moveChatacter(Vector2 direction)
    {
        rb3.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.transform.position = rb3.transform.position;
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
