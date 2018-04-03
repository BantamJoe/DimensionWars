using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
[RequireComponent(typeof(Unit))]
public class SoldierBehaviourTree : MonoBehaviour {
    public BehaviourTree bt;
    public Unit unit;

	void Awake () {
        unit = GetComponent<Unit>();
		bt = GetComponent<BehaviourTree>();

        bt.context = new BehaviourNode.Context
        {
            unit = unit
        };

        var attackSequence = bt.CreateNode<SequenceNode>();

        var isEnemyInSight = bt.CreateNode<IsEnemyInSight>();
        isEnemyInSight.targetingDistance = 200;

        var canShoot = bt.CreateNode<CanShootTarget>();

        var stop = bt.CreateNode<StopMovement>();

        var shoot = bt.CreateNode<ShootTarget>();
        shoot.cooldown = 1;

        attackSequence.children = new List<BehaviourNode>
        {
            isEnemyInSight,
            canShoot,
            stop,
            shoot,
        };

        var moveSequence = bt.CreateNode<SequenceNode>();

        var startMovement = bt.CreateNode<StartMovement>();

        moveSequence.children = new List<BehaviourNode>
        {
            startMovement,
        };

        var root = bt.CreateNode<SelectorNode>();
        root.children = new List<BehaviourNode>
        {
            attackSequence,
            moveSequence,
        };

        bt.root = root;
    }

}
