using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationToCover : BehaviourNode
{
    float maxDistance = 30;

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var coverSelectionBoxes = GameObject.FindGameObjectsWithTag("CoverPoint");
        var closest = 10000;
        GameObject target = null;
        foreach (var cover in coverSelectionBoxes)
        {
            var d = Vector3.Distance(context.unit.transform.position, cover.transform.position);
            if (d < maxDistance && d < closest)
            {
                d = closest;
                target = cover;
            }
        }

        if (target != null)
        {
            var root = target.transform.parent;
            var side = root.transform.Find("Front");
            var node = side.transform.Find("CoverPos2");
            context.unit.mover.SetTarget(node.transform.position);
        }
        else
        {
            yield return BehaviourStatus.Failed;
        }
    }
}
