using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(UnitHealth))]
public class UnitMover : MonoBehaviour
{
    public NavMeshAgent agent;

    [SerializeField]
    UnitHealth health;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<UnitHealth>();
    }

    private void Update()
    {
        if (health.isDead)
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }
    }

    public void SetTarget(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    public void StopMovement()
    {
        agent.isStopped = true;
    }

    public void ResumeMovement()
    {
        agent.isStopped = false;
    }

    public bool IsMoving()
    {
        return agent.velocity != Vector3.zero;
    }
}
