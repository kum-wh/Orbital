
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class spawner2 : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject white;
    public Tilemap door;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;

    private int counter;
    private int currentwave = 0;
    private int interval;
    private int waves;
    private bool difficulty;
    private GameObject array;

    void Start()
    {
        difficulty = setvol.isHard;
        interval = 90;
        if(difficulty == true)
        {
            waves = 5;
        }
        else
        {
            waves = 4;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        array = GameObject.FindWithTag("enermy2");
        if (array == null)
        {
            if (currentwave == waves)
            {
                door.ClearAllTiles();
            }
            else
            {
                if (counter == interval)
                {
                    counter = 0;
                    currentwave += 1;
                    spawn(currentwave);
                }
                counter += 1;
            }
        }
    }

    void spawn(int wave)
    {
        if(wave == 1)
        {
            GameObject enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn1.position, spawn1.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn2.position, spawn2.rotation);
        }else if(wave == 2)
        {
            GameObject enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn1.position, spawn1.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn2.position, spawn2.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn3.position, spawn3.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn4.position, spawn4.rotation);
        }else if(wave == 3)
        {
            GameObject enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn1.position, spawn1.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn2.position, spawn2.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn3.position, spawn3.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn4.position, spawn4.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn5.position, spawn5.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn6.position, spawn6.rotation);
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
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn5.position, spawn5.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn6.position, spawn6.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn7.position, spawn7.rotation);
            enermy = enermytospawn(Random.Range(0, 2));
            Instantiate(enermy, spawn8.position, spawn8.rotation);
        }
    }
    
    private GameObject enermytospawn(int index)
    {
        if(index == 0)
        {
            return white;
        }else if(index == 1)
        {
            return red;
        }else{
            return blue;
        }
    }
}
