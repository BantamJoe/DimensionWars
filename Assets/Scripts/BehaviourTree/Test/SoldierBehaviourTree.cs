using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
public class SoldierBehaviourTree : MonoBehaviour {
    public bool testCondition;
    public BehaviourTree bt;

	void Awake () {
		bt = GetComponent<BehaviourTree>();
        var root = ScriptableObject.CreateInstance<SequenceNode>();
        var a = ScriptableObject.CreateInstance<PrintNode>();
        a.message = "Node A";
        var b = ScriptableObject.CreateInstance<PrintNode>();
        b.message = "Node B";
        root.children = new List<BehaviourNode>
        {
            a,
            b
        };
        bt.root = root;
    }

}
