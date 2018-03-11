using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    public BehaviourNode root;

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
            yield return new WaitForFixedUpdate();
        }
    }
}
