using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    private int state;
    public Slider slider;
    public GameObject bossrb;
    public GameObject shields;
    public GameObject player;
    public GameObject red;
    public GameObject blue;
    public GameObject white;
    public GameObject bossbullet;
    public GameObject victory;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    private float bulletForce;
    private float activating_distance;
    private int health = 50;
    private bool candmg = false;
    private int waves = 0;
    private GameObject array;
    private int shootcounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = health;
        state = 1;
        activating_distance = 5.7f;
        bulletForce = 6f;
    }
    void FixedUpdate()
    {
        shields.transform.Rotate(0,0,4,Space.Self);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= activating_distance)
        {
            if(state == 1)
            {
                boss_spawn(3);
            }else if(state == 2)
            {
                state2();
            }else if(state == 3)
            {
                state3();
            }
            else if(state == 4)
            {
                state4();
            }
        }
    }
    
    private void state2()
    {
        shoot(40);
    }

    private void state3()
    {
        boss_spawn(5);
    }

    private void state4()
    {
        shoot(35);
        boss_spawn(5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (candmg == true)
        {
            string tagg = collision.gameObject.tag;
            if (tagg == "bullet")
            {
                health -= 1;
            }
            else if (tagg == "bullet2")
            {
                health -= 3;
            }
            slider.value = health;
            if (health == 0)
            {
                victory.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (health == 15)
            {
                state = 4;
            }
            else if (health == 25)
            {
                state = 3;
                candmg = false;
                shields.SetActive(true);
            }
            else if (health == 40)
            {
                state = 2;
                activating_distance = 10f;
            }
        }
    }

    private void shoot(int interval)
    {
        if (shootcounter == interval)
        {
            shootcounter = 0;
            GameObject bullet1 = Instantiate(bossbullet, firepoint1.position, firepoint1.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firepoint1.up * bulletForce, ForceMode2D.Impulse);
            GameObject bullet2 = Instantiate(bossbullet, firepoint2.position, firepoint2.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firepoint2.up * bulletForce, ForceMode2D.Impulse);
            GameObject bullet3 = Instantiate(bossbullet, firepoint3.position, firepoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firepoint3.up * bulletForce, ForceMode2D.Impulse);
            GameObject bullet4 = Instantiate(bossbullet, firepoint4.position, firepoint4.rotation);
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            rb4.AddForce(firepoint4.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            shootcounter += 1;
        }
    }

    private GameObject enermytospawn(int index)
    {
        if (index == 0)
        {
            return white;
        }
        else if (index == 1)
        {
            return red;
        }
        else
        {
            return blue;
        }
    }

    private void boss_spawn(int wavesnum)
    {
        array = GameObject.FindWithTag("Enermy");
        if (array == null)
        {
            if (waves == 0)
            {
                Instantiate(red, spawn1.position, spawn1.rotation);
                Instantiate(red, spawn2.position, spawn2.rotation);
                Instantiate(red, spawn3.position, spawn3.rotation);
                Instantiate(red, spawn4.position, spawn4.rotation);
                waves += 1;
            }
            else if (waves == 1)
            {
                Instantiate(white, spawn1.position, spawn1.rotation);
                Instantiate(white, spawn2.position, spawn2.rotation);
                Instantiate(white, spawn3.position, spawn3.rotation);
                Instantiate(white, spawn4.position, spawn4.rotation);
                waves += 1;
            }
            else if(waves == 2)
            {
                Instantiate(blue, spawn1.position, spawn1.rotation);
                Instantiate(blue, spawn2.position, spawn2.rotation);
                Instantiate(blue, spawn3.position, spawn3.rotation);
                Instantiate(blue, spawn4.position, spawn4.rotation);
                waves += 1;
            }else
            {
                if (waves == wavesnum)
                {
                    shields.SetActive(false);
                    candmg = true;
                    waves = 0;
                    state = 0;
                }
                else
                {
                    GameObject enermy = enermytospawn(Random.Range(0, 2));
                    Instantiate(enermy, spawn1.position, spawn1.rotation);
                    enermy = enermytospawn(Random.Range(0, 2));
                    Instantiate(enermy, spawn2.position, spawn2.rotation);
                    enermy = enermytospawn(Random.Range(0, 2));
                    Instantiate(enermy, spawn3.position, spawn3.rotation);
                    enermy = enermytospawn(Random.Range(0, 2));
                    Instantiate(enermy, spawn4.position, spawn4.rotation);
                    waves += 1;
                }
            }
        }
    }
}
