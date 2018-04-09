using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : BehaviourNode
{
    bool hasRetreated;

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        if (hasRetreated)
        {
            yield break;
        }

        var attackDirection = context.target.transform.position - context.unit.transform.position;
        attackDirection.Normalize();

        var moveTarget = attackDirection * 10.0f;

        Debug.DrawLine(context.unit.transform.position, moveTarget, Color.yellow, 100);

        context.unit.mover.SetTarget(moveTarget);
        hasRetreated = true;
        yield break;
    }
}
