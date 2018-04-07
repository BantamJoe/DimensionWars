using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    public BehaviourNode root;

    public BehaviourNode.Context context;

    void Start()
    {
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        while (true)
        {
            yield return StartCoroutine(ExecuteRoot());
        }
    }

    IEnumerator ExecuteRoot()
    {
        foreach (var status in root)
        {
            if (status == BehaviourStatus.Running && context.waitFor != 0)
            {
                var waitFor = context.waitFor;
                context.waitFor = 0;
                yield return new WaitForSeconds(waitFor);
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }

    public T CreateNode<T>() where T : BehaviourNode
    {
        var instance = ScriptableObject.CreateInstance<T>();
        instance.context = context;
        return instance;
    }
}
