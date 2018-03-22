using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    GameObject selectedUnit;
    bool isSelected;
    bool isTarget;
    Vector3 mousePos = new Vector3();
    Unit waypoint;
    List<Unit> squadUnits = new List<Unit>();
    Unit unit;
    

    void Start()
    {
        var squadUnits = transform.GetComponentsInChildren<Unit>();
        foreach(var squadUnit in squadUnits)
        {
            this.squadUnits.Add(squadUnit);
        }
        //waypoint = GameObject.FindObjectOfType<Unit>();
        isSelected = false;
        isTarget = false;

        mousePos = new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.z);

    }

    void Update()
    {
  

    }

    public void setSelected(GameObject selection)
    {
        
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.setSelected(selectedUnit); ;
        }
      
    }

    public void setUnselected()
    {
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.setUnselected(); 
        }
       
    }

    public void setTarget(Unit target)
    {
       
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.setTarget(target);
        };
        
    }

    public void addWaypoint(Vector3 pos)
    {
        foreach (var squadUnit in squadUnits)
        {
            squadUnit.addWaypoint(pos);
        } 
    }
}
