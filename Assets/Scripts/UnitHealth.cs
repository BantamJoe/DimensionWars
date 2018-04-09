using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float health;
    public bool isDead;
    public Unit attacker;
    public bool isUnderAttack;

    public void TakeDamage(float damage, Unit attacker)
    {
        health -= damage;
        health = Mathf.Max(health, 0);

        StartCoroutine(SetUnderAttack());
        this.attacker = attacker;

        if (health == 0)
        {
            isDead = true;
        }
    }

    IEnumerator SetUnderAttack()
    {
        if (isUnderAttack)
        {
            yield break;
        }

        isUnderAttack = true;
        yield return new WaitForSeconds(1);
        isUnderAttack = false;
    }
}
