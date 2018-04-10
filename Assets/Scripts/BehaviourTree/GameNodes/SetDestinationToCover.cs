using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationToCover : BehaviourNode
{
    float maxDistance = 30;

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var coverSelectionBoxes = GameObject.FindGameObjectsWithTag("CoverPoint");
        var closest = 100f;
        GameObject target = null;
        foreach (var cover in coverSelectionBoxes)
        {
            //Debug.DrawLine(context.unit.transform.position, cover.transform.position, Color.magenta, 100, false);
            var d = Vector3.Distance(context.unit.transform.position, cover.transform.position);
            if (d < maxDistance && d < closest)
            {
                closest = d;
                target = cover;
            }
        }

        if (target != null)
        {
            var root = target.transform.parent;
            var side = root.transform.Find("Front");
            var node = side.transform.Find("CoverPos2");
            context.unit.mover.SetTarget(node.transform.position);
            //Debug.DrawLine(context.unit.transform.position, node.transform.position, Color.white, 100, false);
        }
        else
        {
            yield return BehaviourStatus.Failed;
        }
    }
}
