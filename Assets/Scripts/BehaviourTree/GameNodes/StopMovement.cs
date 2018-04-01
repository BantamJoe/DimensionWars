using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        context.unit.mover.StopMovement();
        yield break;
    }
}
