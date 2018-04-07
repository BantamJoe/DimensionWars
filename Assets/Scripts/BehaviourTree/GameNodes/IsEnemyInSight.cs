﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyInSight : BehaviourNode
{
    public float targetingDistance;

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var units = FindObjectsOfType<Unit>();
        foreach (var unit in units)
        {
            if (unit.squad.team != context.unit.squad.team)
            {
                var distance = Vector3.Distance(context.unit.transform.position, unit.transform.position);
                if (distance < targetingDistance)
                {
                    // Trace LOS
                    var start = context.unit.transform.Find("RaycastTarget").transform.position;
                    var end = unit.transform.Find("RaycastTarget").transform.position;
                    var direction = end - start;
                    var d = Vector3.Distance(start, end);
                    RaycastHit hit;

                    // If found target
                    if (Physics.Raycast(start, direction, out hit, d))
                    {
                        // Check if valid target
                        var hitUnit = hit.collider.GetComponent<Unit>();
                        if (hitUnit == unit)
                        {
                            context.target = unit;
                            yield break;
                        }
                    }

                }
            }

        }
        yield return BehaviourStatus.Failed;
    }
}