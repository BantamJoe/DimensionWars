using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitWeapon))]
public class Unit : MonoBehaviour
{
    public bool isSelected;
    public UnitMover mover;
    public Unit target;
    public float waypointTargetDistance;
    public float gunCooldown;
    public Squad squad;
    public UnitWeapon weapon;

    List<Vector3> waypointList = new List<Vector3>();

    void Awake()
    {
        mover = GetComponent<UnitMover>();
        squad = transform.parent.GetComponent<Squad>();
        weapon = GetComponent<UnitWeapon>();
    }

    void Update()
    {
        gunCooldown -= Time.deltaTime;

        if (waypointList.Count != 0)
        {
            var pos = waypointList[0];
            var distance = Vector3.Distance(transform.position, pos);
            if (distance < waypointTargetDistance)
            {
                waypointList.RemoveAt(0);
                if (waypointList.Count != 0)
                {
                    mover.SetTarget(waypointList[0]);
                }
            }
        }
    }

    public void SetSelected()
    {
        isSelected = true;
    }

    public void SetUnselected()
    {
        isSelected = false;
    }

    public void SetTarget(Unit target)
    {
        this.target = target;
    }

    public void AddWaypoint(Vector3 pos)
    {
        var isEmpty = waypointList.Count == 0;
        waypointList.Add(pos);
        if (isEmpty)
        {
            mover.SetTarget(waypointList[0]);
        }
    }
}
