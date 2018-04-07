using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float health;
    public bool isDead;

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);

        if (health == 0)
        {
            isDead = true;
        }
    }
}