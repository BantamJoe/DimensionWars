using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitWeapon))]
public class Unit : MonoBehaviour
{
    public bool isSelected;
    public UnitMover mover;
    public Unit target;
    public float waypointTargetDistance;
    public float gunCooldown;
    public Squad squad;
    public UnitWeapon weapon;

    List<Vector3> waypointList = new List<Vector3>();

    public enum Class { Rifleman, HeavyAssault, Sniper, MG }
    public Class unitClass = Class.Rifleman;

    void Awake()
    {
        mover = GetComponent<UnitMover>();
        squad = transform.parent.GetComponent<Squad>();
        weapon = GetComponent<UnitWeapon>();

		//Set unit muzzle color
		switch (unitClass) {
		case Class.Rifleman:
			{
				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = Color.red;

				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(3).gameObject.GetComponent<ParticleSystem>().startColor = Color.red;
				break;
			}
		case Class.HeavyAssault:
			{
				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = Color.cyan;

				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(3).gameObject.GetComponent<ParticleSystem>().startColor = Color.cyan;
				break;
			}
		case Class.Sniper:
			{
				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = Color.magenta;

				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(3).gameObject.GetComponent<ParticleSystem>().startColor = Color.magenta;
				break;
			}
		case Class.MG:
			{
				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = Color.green;

				this.transform.GetChild(1) // hips
					.GetChild(2) // spine
					.GetChild(0) //spine 1
					.GetChild(0) //spine 2
					.GetChild(2) //right should
					.GetChild(0) // right arm
					.GetChild(0) // rightfore arm
					.GetChild(0) //right hand
					.GetChild(5) //riflen
					.GetChild(3).gameObject.GetComponent<ParticleSystem>().startColor = Color.green;
				break;
			}
		}


		//Turn off particle effect
		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(2).gameObject.SetActive(false); // tracer

		this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5) //riflen
			.GetChild(3).gameObject.SetActive(false); // muzzke
    }

    void Update()
    {
        gunCooldown -= Time.deltaTime;
        gunCooldown = Mathf.Max(gunCooldown, 0);

        if (waypointList.Count != 0)
        {
            var pos = waypointList[0];
            var distance = Vector3.Distance(transform.position, pos);
            if (distance < waypointTargetDistance)
            {
                waypointList.RemoveAt(0);
                if (waypointList.Count != 0)
                {
                    mover.SetTarget(waypointList[0]);
                }
            }
        }
    }

    public void SetSelected()
    {
        isSelected = true;
    }

    public void SetUnselected()
    {
        isSelected = false;
    }

    public void SetTarget(Unit target)
    {
        this.target = target;
    }

    public void SetImmediateMoveTarget(Vector3 target)
    {
        waypointList.Clear();
        AddWaypoint(target);
    }

    public void AddWaypoint(Vector3 pos)
    {
        var isEmpty = waypointList.Count == 0;
        waypointList.Add(pos);
        if (isEmpty)
        {
            mover.SetTarget(waypointList[0]);
        }
    }
}
