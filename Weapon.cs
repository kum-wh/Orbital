using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject image1;
    public GameObject image2;
    public Transform firePoint;
    public static Vector2 mousePos;
    public AudioClip shootingAudio;

    private float bulletForce;
    private int interval1;
    private int interval2;
    private int counter1 = 0;
    private int counter2 = 0;
    private bool canfire1 = true;
    private bool canfire2 = true;
    private bool difficulty;
    private int weaponstate = 0;
    public static Queue<GameObject> Pool;

    void Start()
    {
        difficulty = setvol.isHard;
        bulletForce = 10;
        if(difficulty == true)
        {
            interval1 = 20;
            interval2 = 100;
        }
        else
        {
            interval1 = 15;
            interval2 = 80;
        }
        Pool = new Queue<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject ammoObject = Instantiate(bulletPrefab2);
            ammoObject.SetActive(false);
            Physics2D.IgnoreCollision(ammoObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Pool.Enqueue(ammoObject);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (weaponstate == 0)
            {
                image1.SetActive(false);
                image2.SetActive(true);
                weaponstate = 1;
            }
            else if (weaponstate == 1)
            {
                image2.SetActive(false);
                image1.SetActive(true);
                weaponstate = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (weaponstate == 0)
            {
                if (canfire1 == true)
                {
                    canfire1 = false;
                    counter1 = 0;
                    AudioSource.PlayClipAtPoint(shootingAudio, Camera.main.transform.position);
                    shoot();
                }
            }
            else
            {
                if (canfire2 == true)
                {
                    canfire2 = false;
                    counter2 = 0;
                    AudioSource.PlayClipAtPoint(shootingAudio, Camera.main.transform.position);
                    FireAmmo();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (counter1 == interval1)
        {
            canfire1 = true;
        }
        if (counter2 == interval2)
        {
            canfire2 = true;
        }
        if (canfire1 == false)
        {
            counter1 += 1;
        }
        if (canfire2 == false)
        {
            counter2 += 1;
        }
    }

    private GameObject SpawnAmmo()
    {
        GameObject ammo = Pool.Dequeue();
        ammo.transform.position = firePoint.position;
        ammo.transform.rotation = firePoint.rotation;
        ammo.SetActive(true);
        Pool.Enqueue(ammo);
        return ammo;
    }

    private void FireAmmo()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject ammo = SpawnAmmo();
    }

    void OnDestroy()
    {
        Pool = null;
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

