using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : BehaviourNode
{
    public float cooldown;

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        if (context.target != null)
        {
            MonoBehaviour.print("Shot " + context.unit.target);
            context.unit.weapon.Shoot(context.target.gameObject);
            context.unit.gunCooldown += cooldown;
        }

        if (context.unit.target != null)
        {
            MonoBehaviour.print("Shot " + context.unit.target);
            context.unit.weapon.Shoot(context.target.gameObject);
            context.unit.gunCooldown += cooldown;
        }

        yield break;
    }
}
