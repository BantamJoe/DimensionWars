using System.Collections;
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
                    context.target = unit;
                    yield break;
                }
            }

        }
        yield return BehaviourStatus.Failed;
    }
}
