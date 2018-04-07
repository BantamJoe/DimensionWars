using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        /*
        for (int i = 0; i < 10; i++)
        {
            context.unit.transform.Rotate(-10, 0, 0);
            context.waitFor = 0.1f;
            yield return BehaviourStatus.Running;
        }
        */

        Destroy(context.unit.gameObject);

        yield break;
    }
}
