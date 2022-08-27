using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class spawner : MonoBehaviour
{
    public int level;
    public GameObject whiteenermyprefab;
    public GameObject redenermyprefab;
    public GameObject blueenermyprefab;
    public GameObject heartsprefab;
    public GameObject Coinprefab;
    public GameObject VictoryScreen;
    private GameObject[] spawned;
    private int number;
    private bool difficulty;
    private int coin;
    private int hearts;
    private int whiteenermy;
    private int blueenermy;
    private int redenermy;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = setvol.isHard;
        coin = 3;
        if(difficulty == true)
        {
            hearts = 1;
            if(level == 1)
            {
                whiteenermy = 10;
                blueenermy = 10;
                redenermy = 10;
            }else if(level == 2)
            {
                whiteenermy = 3;
                blueenermy = 3;
                redenermy = 3;
            }
            else if(level == 3)
            {
                whiteenermy = 5;
                blueenermy = 5;
                redenermy = 5;
            }else
            {
                whiteenermy = 0;
                blueenermy = 0;
                redenermy = 0;
            }
        }
        else
        {
            hearts = 3;
            if(level == 1)
            {
                whiteenermy = 8;
                blueenermy = 8;
                redenermy = 8;
            }else if(level == 2)
            {
                whiteenermy = 2;
                blueenermy = 2;
                redenermy = 2;
            }
            else if(level == 3)
            {
                whiteenermy = 3;
                blueenermy = 3;
                redenermy = 3;
            }
            else
            {
                whiteenermy = 0;
                blueenermy = 0;
                redenermy = 0;
            }
        }
        spawned = GameObject.FindGameObjectsWithTag("enermyspawn");
        number = spawned.Length - 1;
        for (int i = whiteenermy; i > 0; i--)
        {
            int rad = Random.Range(0, number);
            Instantiate(whiteenermyprefab, spawned[rad].transform.position, spawned[rad].transform.rotation);
            for (int j = number - rad; j > 0; j--)
            {
                spawned[rad] = spawned[rad + 1];
                rad += 1;
            }
            number -= 1;
        }
        for (int i = redenermy; i > 0; i--)
        {
            int rad = Random.Range(0, number);
            Instantiate(redenermyprefab, spawned[rad].transform.position, spawned[rad].transform.rotation);
            for (int j = number - rad; j > 0; j--)
            {
                spawned[rad] = spawned[rad + 1];
                rad += 1;
            }
            number -= 1;
        }
        for (int i = blueenermy; i > 0; i--)
        {
            int rad = Random.Range(0, number);
            Instantiate(blueenermyprefab, spawned[rad].transform.position, spawned[rad].transform.rotation);
            for (int j = number - rad; j > 0; j--)
            {
                spawned[rad] = spawned[rad + 1];
                rad += 1;
            }
            number -= 1;
        }
        for (int i = coin; i > 0; i--)
        {
            int rad = Random.Range(0, number);
            Instantiate(Coinprefab, spawned[rad].transform.position, spawned[rad].transform.rotation);
            for (int j = number - rad; j > 0; j--)
            {
                spawned[rad] = spawned[rad + 1];
                rad += 1;
            }
            number -= 1;
        }
        for (int i = hearts; i > 0; i--)
        {
            int rad = Random.Range(0, number);
            GameObject heart = Instantiate(heartsprefab, spawned[rad].transform.position, spawned[rad].transform.rotation);
            for (int j = number - rad; j > 0; j--)
            {
                spawned[rad] = spawned[rad + 1];
                rad += 1;
            }
            number -= 1;
        }
    }

    //
    void FixedUpdate()
    {
        if (level == 4)
        {
            return;
        }
        GameObject enermy = GameObject.FindWithTag("Enermy");
        if(enermy == null)
        {
            Time.timeScale = 0f;
            setvol.paused = true;
            VictoryScreen.SetActive(true);
        }
    }
}
