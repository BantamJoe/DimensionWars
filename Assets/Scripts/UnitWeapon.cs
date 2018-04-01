using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWeapon : MonoBehaviour
{
    /*public*/ Unit target;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float speed;
    bool targetInSight;

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (targetInSight)
            Shoot();

        if (Input.GetKeyDown(KeyCode.E))
            FireAt(target);
    }

    void FireAt(Unit targetAt)
    {
        target.SetTarget(targetAt);
        targetInSight = true;
    }

    void Shoot()
    {
        bullet = GameObject.Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed * Time.deltaTime;

        Destroy(bullet, 5.0f);
    }
}
