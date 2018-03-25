using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovement : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        context.unit.mover.ResumeMovement();
        yield break;
    }
}
