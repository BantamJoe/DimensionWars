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

    public void AddWaypoint(Vector3 pos)
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();

        foreach (var squadUnit in squadUnits)
        {
            squadUnit.AddWaypoint(pos);
        }
    }
}
