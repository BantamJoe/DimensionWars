using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    public bool isSelected;
    public int team;

    public void SetSelected(GameObject selection)
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.SetSelected();
        }

    }

    public void SetUnselected()
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.SetUnselected();
        }

    }

    public void SetTarget(Unit target)
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();

        foreach (var squadUnit in squadUnits)
        {
            squadUnit.SetTarget(target);
        };

    }

    public void SetImmediateMoveTarget(Vector3 pos)
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();

        foreach (var squadUnit in squadUnits)
        {
            squadUnit.SetImmediateMoveTarget(pos);
        }
    }

    public void AddWaypoint(Vector3 pos)
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();

        foreach (var squadUnit in squadUnits)
        {
            squadUnit.AddWaypoint(pos);
        }
    }

    public void SetCoverTarget(GameObject cover)
    {
        // TODO Use context sens. choice.
        var side = cover.transform.Find("Front");
        var i = 1;
        var squadUnits = transform.GetComponentsInChildren<Unit>();
        foreach (var unit in squadUnits)
        {
            var pointName = "CoverPos" + i;
            var pointTarget = side.Find(pointName);
            unit.SetImmediateMoveTarget(pointTarget.transform.position);
            i++;
        }
        print("Moved to cover!");
    }
}
