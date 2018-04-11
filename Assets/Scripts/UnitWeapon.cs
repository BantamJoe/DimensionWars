using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWeapon : MonoBehaviour
{
    public Transform bulletSpawn;
    public float speed;

    public void Shoot(GameObject target)
    {
        var t = target.transform.Find("RaycastTarget");
        if (t != null)
        {
            var direction = t.transform.position - bulletSpawn.transform.position;
            Debug.DrawRay(bulletSpawn.position, direction, Color.yellow, 5 * Time.deltaTime);
        }

        var unit = GetComponent<Unit>();
        var health = target.GetComponent<UnitHealth>();
        if (health != null)
        {
            health.TakeDamage(10, unit);
        }
    }
}
