using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
[RequireComponent(typeof(Unit))]
public class SoldierBehaviourTree : MonoBehaviour
{
    public BehaviourTree bt;
    public Unit unit;

    void Awake()
    {
        unit = GetComponent<Unit>();
        bt = GetComponent<BehaviourTree>();

        bt.context = new BehaviourNode.Context
        {
            unit = unit
        };

        if (unit.unitClass == Unit.Class.HeavyAssault)
        {
            bt.root = HeavyAssaultBehaviour();
        }
        else if (unit.unitClass == Unit.Class.Sniper)
        {
            bt.root = SniperBehaviour();
        }
        else if (unit.unitClass == Unit.Class.MG)
        {

        }
        else
        {
            bt.root = RiflemanBehaviour();
        }
    }

    BehaviourNode RiflemanBehaviour()
    {
        var root = bt.CreateNode<SelectorNode>();
        root.children = new List<BehaviourNode>
        {
            DieSequence(),
            MoveSequence(),
            CoverSequence(),
            AttackSequence(),
        };
        return root;
    }

    BehaviourNode HeavyAssaultBehaviour()
    {
        var root = bt.CreateNode<SelectorNode>();
        root.children = new List<BehaviourNode>
        {
            DieSequence(),
            ChargeSequence(),
        };
        return root;
    }

    BehaviourNode SniperBehaviour()
    {
        var root = bt.CreateNode<SelectorNode>();
        root.children = new List<BehaviourNode>
        {
            DieSequence(),
            RetreatSequence(),
            AttackSequence(150),
        };
        return root;
    }

    BehaviourNode DieSequence()
    {
        var dieSequence = bt.CreateNode<SequenceNode>();
        var isDead = bt.CreateNode<IsDead>();
        var die = bt.CreateNode<Die>();
        dieSequence.children = new List<BehaviourNode>
        {
            isDead,
            die,
        };
        return dieSequence;
    }

    BehaviourNode AttackSequence(float range = 100)
    {
        var attackSequence = bt.CreateNode<SequenceNode>();
        var isEnemyInSight = bt.CreateNode<IsEnemyInSight>();
        isEnemyInSight.targetingDistance = range;
        var canShoot = bt.CreateNode<CanShootTarget>();
        var shoot = bt.CreateNode<ShootTarget>();
        shoot.cooldown = 1;
        attackSequence.children = new List<BehaviourNode>
        {
            isEnemyInSight,
            canShoot,
            shoot,
        };
        return attackSequence;
    }

    BehaviourNode CoverSequence()
    {
        var coverSequence = bt.CreateNode<SequenceNode>();
        var isUnderAttack = bt.CreateNode<IsUnderAttack>();
        var findCover = bt.CreateNode<FindCover>();
        var moveToTarget = bt.CreateNode<MoveToTarget>();
        coverSequence.children = new List<BehaviourNode>
        {
            isUnderAttack,
            findCover,
            moveToTarget,
        };
        return coverSequence;
    }

    BehaviourNode MoveSequence()
    {
        var moveSequence = bt.CreateNode<SequenceNode>();
        var moveToTarget = bt.CreateNode<MoveToTarget>();
        moveSequence.children = new List<BehaviourNode>
        {
            moveToTarget,
        };
        return moveSequence;
    }

    BehaviourNode ChargeSequence()
    {
        var seq = bt.CreateNode<SequenceNode>();
        var isEnemyInSight = bt.CreateNode<IsEnemyInSight>();
        isEnemyInSight.targetingDistance = 100;
        var canShoot = bt.CreateNode<CanShootTarget>();
        var shoot = bt.CreateNode<ShootTarget>();
        shoot.cooldown = 1;
        seq.children = new List<BehaviourNode>
        {
            isEnemyInSight,
            bt.CreateNode<ChargeTarget>(),
            canShoot,
            shoot,
        };
        return seq;
    }

    BehaviourNode RetreatSequence()
    {
        var isEnemyInSight = bt.CreateNode<IsEnemyInSight>();
        var coverSequence = bt.CreateNode<SequenceNode>();
        var isUnderAttack = bt.CreateNode<IsUnderAttack>();
        var findCover = bt.CreateNode<FindCover>();
        var moveToTarget = bt.CreateNode<MoveToTarget>();
        coverSequence.children = new List<BehaviourNode>
        {
            isUnderAttack,
            isEnemyInSight,
            bt.CreateNode<Retreat>(),
            moveToTarget,
        };
        return coverSequence;
    }
}
