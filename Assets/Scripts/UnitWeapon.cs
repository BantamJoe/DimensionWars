using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWeapon : MonoBehaviour
{
    public Transform bulletSpawn;
    public float speed;

    public void Shoot(GameObject target)
    {
        var direction = target.transform.position - bulletSpawn.transform.position;
        Debug.DrawRay(bulletSpawn.position, direction, Color.yellow, 5 * Time.deltaTime);

        var health = target.GetComponent<UnitHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}
