using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
[RequireComponent(typeof(Unit))]
public class StrategicAISpotterBehaviourTree : MonoBehaviour
{
    [SerializeField]
    private BehaviourTree bt;
    public Unit unit;

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
        var root = bt.CreateNode<SequenceNode>();
        root.children = new List<BehaviourNode>
        {
            bt.CreateNode<SetTarget>(),
            bt.CreateNode<OnlyOnce>(),
            bt.CreateNode<Announce>().Initialize("Commander 2: There he is! Charge!"),
        };
        return root;
    }
}
