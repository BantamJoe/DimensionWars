using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTarget : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        context.unit.mover.SetTarget(context.target.transform.position);
        context.unit.mover.agent.isStopped = false;
        yield break;
    }
}
