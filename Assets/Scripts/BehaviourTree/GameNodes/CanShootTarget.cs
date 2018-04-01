using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootTarget : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        if (context.unit.gunCooldown <= 0)
        {
            yield break;
        } else
        {
            yield return BehaviourStatus.Failed;
        }
    }
}
