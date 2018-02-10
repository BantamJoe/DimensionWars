using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankAI : MonoBehaviour {

    public Transform followTarget;

    public NavMeshAgent agent;

    public bool isLeft;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        var mul = isLeft ? -1 : 1;
        agent.destination = followTarget.position + followTarget.forward * 25 + followTarget.right * 15 * mul;
	}
}
