using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public int health;
    private bool isDamaged;
    private float timer = 2.0f;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerPrefs.GetInt("Health");

        if (isDamaged)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            TimeEnd();
        }
    }

    void takeDamage()
    {
        if (!isDamaged)
        {
            health--;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag ==  "Bullet")
        {
            takeDamage();
            if (isDamaged)
            {
                Color color = gameObject.GetComponent<SpriteRenderer>().color;
                color.a = 0.5f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    void TimeEnd()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 1.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        isDamaged = false;
        timer = 2.0f;
    }
}