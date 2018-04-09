using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationToTarget : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        context.unit.mover.SetTarget(context.target.transform.position);
        yield break;
    }
}
