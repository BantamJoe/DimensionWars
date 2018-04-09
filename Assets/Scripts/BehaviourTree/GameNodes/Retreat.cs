using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var attackDirection = context.target.transform.position - context.unit.transform.position;
        attackDirection.Normalize();

        var moveTarget = attackDirection * 10.0f;

        context.unit.mover.SetTarget(moveTarget);
        context.unit.mover.agent.isStopped = false;
        yield break;
    }
}
