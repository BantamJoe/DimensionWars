using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class UnitAnimationController : MonoBehaviour
{
    Animator anim;
    NavMeshAgent ag;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ag = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (ag.velocity != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void Shoot()
    {
        StartCoroutine(InternalShoot());
    }

    IEnumerator InternalShoot()
    {
        if (anim.GetBool("isFiring"))
        {
            yield break;
        }
        anim.SetBool("isFiring", true);

		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(2).gameObject.SetActive(true); // Muzzle effect

		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(3).gameObject.SetActive(true); // Tracer
		
        yield return new WaitForSeconds(1);

        anim.SetBool("isFiring", false);

		//Turn off particle f
		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(2).gameObject.SetActive(false); // Muzzle effect

		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(3).gameObject.SetActive(false); // Tracer
    }
}
