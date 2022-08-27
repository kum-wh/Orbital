using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class Player : MonoBehaviour
{
    public Slider slider;
    public Transform Respawn;
    public AudioClip gettinghit;
    public AudioClip dead;
    public AudioClip coinsound;
    public AudioClip heartsound;
    public GameObject game;
    [SerializeField] Text cointext;
    private int coincount = 0;
    private int startingHitPoints;
    private int currplayerhealth;
    Coroutine damageCoroutine;

    //
    void Start()
    {
        startingHitPoints = 5;
        currplayerhealth = startingHitPoints;
        slider.value = currplayerhealth;
        cointext.text = coincount.ToString();
    }

    //
    public void ResetCharacter()
    {
        setvol.paused = false;
        Time.timeScale = 1f;
        game.SetActive(false);
        currplayerhealth = startingHitPoints;
        slider.value = currplayerhealth;
        gameObject.transform.position = Respawn.position;
        gameObject.transform.rotation = Respawn.rotation;
    }

    //
    IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
          {
            currplayerhealth = currplayerhealth - damage;
            slider.value = currplayerhealth;
            if (currplayerhealth <= 0 )
            {
                AudioSource.PlayClipAtPoint(dead, Camera.main.transform.position);
                Time.timeScale = 0f;
                setvol.paused = true;
                game.SetActive(true);
                break;
            }
            AudioSource.PlayClipAtPoint(gettinghit, Camera.main.transform.position);
            StartCoroutine(FlickerChar());
            if (interval > 0)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    //
    IEnumerator FlickerChar()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    //
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tagg = collision.gameObject.tag;
        if (tagg == "Pickable")
        {
            AudioSource.PlayClipAtPoint(coinsound, Camera.main.transform.position);
            coincount += 1;
            cointext.text = coincount.ToString();
            collision.gameObject.SetActive(false);
        }
        else if(tagg == "heart")
        {
            AudioSource.PlayClipAtPoint(heartsound, Camera.main.transform.position);
            if (currplayerhealth < startingHitPoints)
            {
                currplayerhealth = currplayerhealth + 1;
                slider.value = currplayerhealth;
            }
            collision.gameObject.SetActive(false); 
        }else if (tagg == "Enermy")
        {
            int damage = collision.gameObject.GetComponent<Enemy>().damageStrength;
            damageCoroutine = StartCoroutine(DamageCharacter(damage, 1.0f));
        }
        else if (tagg == "enermy2")
        {
            int damage = collision.gameObject.GetComponent<Enemy>().damageStrength;
            damageCoroutine = StartCoroutine(DamageCharacter(damage, 1.0f));
        }
        else if (tagg == "bullet3")
        {
            currplayerhealth = currplayerhealth - 1;
            slider.value = currplayerhealth;
            if (currplayerhealth <= 0)
            {
                AudioSource.PlayClipAtPoint(dead, Camera.main.transform.position);
                Time.timeScale = 0f;
                setvol.paused = true;
                game.SetActive(true);
                return;
            }
            AudioSource.PlayClipAtPoint(gettinghit, Camera.main.transform.position);
            StartCoroutine(FlickerChar());
        }
    }

    //
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enermy" )
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }else if(collision.gameObject.tag == "enermy2")
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}
