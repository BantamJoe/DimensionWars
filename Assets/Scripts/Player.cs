using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float height;
    public int team;
    public List<Squad> squads = new List<Squad>();
    public List<Squad> selectedSquads = new List<Squad>();

    private void Start()
    {
        var squads = FindObjectsOfType<Squad>();
        foreach (var squad in squads)
        {
            if (squad.team != team)
            {
                continue;
            }
            this.squads.Add(squad);
        }
    }

    public void SelectSquad(int id)
    {
        var index = id - 1;
        if (index >= 0 && index < squads.Count)
        {
            selectedSquads.Clear();
            selectedSquads.Add(squads[index]);
            print("Selected squad " + id);
        }
    }

    /// <summary>
    /// Sets the squad's target based on a given ray.
    /// </summary>
    /// <param name="ray">The ray we shoot and get the position from the hit.</param>
    public void SetSquadTarget(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "CoverPoint")
            {
                var target = hit.collider.transform.parent;
                foreach (var squad in selectedSquads)
                {
                    squad.SetCoverTarget(target.gameObject);
                }
            }
            else
            {
                foreach (var squad in selectedSquads)
                {
                    squad.SetImmediateMoveTarget(hit.point);
                }
            }

        }
    }

    /// <summary>
    /// Overloaded SetSquadTarget to accept a Vector3.
    /// </summary>
    /// <param name="pos">The vector3 position to add the waypoint.</param>
    public void SetSquadTarget(Vector3 pos)
    {
        foreach (var squad in selectedSquads)
        {
            squad.SetImmediateMoveTarget(pos);
        }
    }

    /// <summary>
    /// Teleports the player based on a given Ray
    /// </summary>
    /// <param name="ray">The ray to process and shoot, then move to if we hit something.</param>
    public void TeleportTo(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Start the fading effect from black
            SteamVR_Fade.Start(Color.black, 0);
            // To nothing
            SteamVR_Fade.Start(Color.clear, 1);
            Vector3 point = hit.point;

            // We give an offset of 2.0f for Y, and keep it throughout.
            Vector3 newPos = new Vector3(point.x, height, point.z);

            // Set the player's positions.
            transform.position = newPos;
        }
    }

    /// <summary>
    /// Overloaded TeleportTo to also accept a Vector3 from a RayCast done through VR.
    /// </summary>
    /// <param name="pos">The position to move to.</param>
    public void TeleportTo(Vector3 pos)
    {
        // Start the fading effect from black
        SteamVR_Fade.Start(Color.black, 0);
        // To nothing
        SteamVR_Fade.Start(Color.clear, 1);

        // We give an offset Y, and keep it throughout.
        Vector3 newPos = new Vector3(pos.x, height, pos.z);

        // Set the new positions for the player
        transform.position = newPos;
    }
}
