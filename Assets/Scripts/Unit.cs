using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
public class Unit : MonoBehaviour
{
    public bool isSelected;
    public bool isTarget;
    public GameObject selectedUnit;
    UnitMover mover;
    GameObject waypoint;
    Unit unit;
    
    List<Vector3> waypointList = new List<Vector3>();

    void Start()
    {
        //squadUnit = GameObject.FindObjectOfType<Squad>();
        waypoint = GameObject.FindObjectOfType<GameObject>();
        isSelected = false;
        isTarget = false;
        mover = GetComponent<UnitMover>();
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 0.0f);
    }

    void Update()
    {
        if(waypointList.Count == 0)
        {
            return;
        }

        var pos = waypointList[0];
        var d = Vector3.Distance(transform.position, pos);

        if(d < 5)
        {
            waypointList.RemoveAt(0);
            if(waypointList.Count != 0)
                mover.setTarget(waypointList[0]);
            
        }


        //if(squadUnit.selectedUnit != null)
        //{
        //    this.transform.position = squadUnit.selectedUnit.transform.position;
        //}
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if(Physics.Raycast(ray, out hit ))
        //{
        //    GameObject hitObject = hit.transform.parent.gameObject;

        //    squadUnit.setSelected(hitObject);
        //}

        //else
        //    squadUnit.setUnselected();
        //    if (Input.GetMouseButtonDown(2))
        //        waypoint.addWaypoint(Input.mousePosition);
        //}
        //void FixedUpdate()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        bool hit = false;
        //        RaycastHit ray = new RaycastHit();
        //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray))
        //        {
        //            if (ray.collider.tag == "Unit")
        //                hit = true;
        //        }

        //        unSelected();
        //        if (hit)
        //            setSelected();
        //    }
    }

    public void setSelected(GameObject selection)
    {
        if (selectedUnit != null)
        {
            if (selection == selectedUnit)

                return;

            setUnselected();
        }

        selectedUnit = selection;
        //if (selectedUnit != null)
        //{
        //    if (selection == selectedUnit)

        //        return;

        //       setUnselected();
        //}
        isSelected = true;
        selectedUnit = selection;
        //squadUnit.setSelected(selectedUnit);
        //isSelected = true;
        //gameObject.tag = "Selected";
        Debug.Log("Selected");
    }

    public void setUnselected()
    {
        //squadUnit.setUnselected();
        isSelected = false;
        //gameObject.tag = "Unit";
        Debug.Log("Unselcted");

    }

    public void setTarget(Unit target)
    {
        unit = target;
        //squadUnit.setTarget(unit);
        isTarget = true;
        Debug.Log("Target");
        //if (Input.GetMouseButtonDown(1) && gameObject.tag == "Enemy")
        //{
        //    target = unit;
        //    isTarget = true;
        //    target.gameObject.tag = "Target";
        //}
    }

    public void addWaypoint(Vector3 pos)
    {
        var isEmpty = waypointList.Count == 0;
        
        waypointList.Add(pos);
        if (isEmpty)
            mover.setTarget(waypointList[0]);
    }
}
