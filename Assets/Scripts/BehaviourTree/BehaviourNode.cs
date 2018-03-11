using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BehaviourNode : ScriptableObject, IEnumerable<BehaviourStatus> {
    public List<BehaviourNode> children;

    public abstract IEnumerator<BehaviourStatus> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}
