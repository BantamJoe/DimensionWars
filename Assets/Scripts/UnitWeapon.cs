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
        //bullet = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(direction));
        //bullet.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;

        Debug.DrawRay(bulletSpawn.position, direction, Color.yellow, 5 * Time.deltaTime);

        //Destroy(bullet, 5.0f);
    }
}
