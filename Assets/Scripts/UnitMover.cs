using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMover : MonoBehaviour
{
    
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void setTarget(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
}
