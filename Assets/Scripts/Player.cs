using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float height;
 List<Squad> squads = new List<Squad>();
 
   // Use this for initialization
    void Start()
    {
      var squads = GameObject.FindObjectsOfType<Squad>();
        foreach(var squad in squads)
        {
            this.squads.Add(squad);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {   
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                if (hit.transform)
                {
                    foreach (var squad in squads)
                    {
                        squad.addWaypoint(hit.point);
                    }
                } 
        }
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
