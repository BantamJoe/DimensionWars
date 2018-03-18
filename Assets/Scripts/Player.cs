using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float height;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TeleportTo(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;

            // We give an offset of 2.0f for Y, and keep it throughout.
            Vector3 newPos = new Vector3(point.x, height, point.z);

            // Set the player's positions.
            transform.position = newPos;
        }
    }
}
