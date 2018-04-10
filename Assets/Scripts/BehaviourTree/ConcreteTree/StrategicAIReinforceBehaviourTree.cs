using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
[RequireComponent(typeof(Unit))]
public class StrategicAIReinforceBehaviourTree : MonoBehaviour
{
    [SerializeField]
    private BehaviourTree bt;
    public Unit unit;
    public Squad reinforcementGroup;
    public GameObject reinforcementTarget;

    void Awake()
    {
        unit = GetComponent<Unit>();
        bt = GetComponent<BehaviourTree>();

        bt.context = new BehaviourNode.Context
        {
            unit = unit
        };

        bt.root = StrategicBehaviour();
    }

    BehaviourNode StrategicBehaviour()
    {
        var root = bt.CreateNode<SelectorNode>();
        root.children = new List<BehaviourNode>
        {
            bt.CreateNode<OnlyOnce>(),
            bt.CreateNode<SetTarget>(),
            bt.CreateNode<SetSquadDestination>().Initialize(reinforcementGroup, reinforcementTarget),
        };
        return root;
    }
}
