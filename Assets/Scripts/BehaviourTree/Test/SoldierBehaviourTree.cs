﻿using System.Collections;
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
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<IsDead>(),
            bt.CreateNode<Die>(),
        };
        return sequence;
    }

    BehaviourNode AttackSequence(float range = 100)
    {
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<IsEnemyInSight>().Initialize(range),
            bt.CreateNode<CanShootTarget>(),
            bt.CreateNode<ShootTarget>(),
        };
        return sequence;
    }

    BehaviourNode CoverSequence()
    {
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<IsUnderAttack>(),
            bt.CreateNode<FindCover>(),
            bt.CreateNode<MoveToTarget>(),
        };
        return sequence;
    }

    BehaviourNode MoveSequence()
    {
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<MoveToTarget>(),
        };
        return sequence;
    }

    BehaviourNode ChargeSequence()
    {
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<IsEnemyInSight>(),
            bt.CreateNode<ChargeTarget>(),
            bt.CreateNode<CanShootTarget>(),
            bt.CreateNode<ShootTarget>(),
        };
        return sequence;
    }

    BehaviourNode RetreatSequence()
    {
        var sequence = bt.CreateNode<SequenceNode>();
        sequence.children = new List<BehaviourNode>
        {
            bt.CreateNode<IsUnderAttack>(),
            bt.CreateNode<IsEnemyInSight>(),
            bt.CreateNode<Retreat>(),
            bt.CreateNode<MoveToTarget>(),
        };
        return sequence;
    }
}
