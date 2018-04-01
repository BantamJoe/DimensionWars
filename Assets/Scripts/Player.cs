using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float height;
    public int team;

    public void SetSquadTarget(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var squads = FindObjectsOfType<Squad>();
            foreach (var squad in squads)
            {
                if (squad.team != team)
                {
                    continue;
                }
                squad.AddWaypoint(hit.point);
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
