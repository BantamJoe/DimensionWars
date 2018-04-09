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

	public GameObject muzzleEffect_prefab;
	public GameObject tracerEffect_prefab;

	public GameObject muzzleEffect;
	public GameObject tracerEffect;

    List<Vector3> waypointList = new List<Vector3>();

    public enum Class { Rifleman, HeavyAssault, Sniper, MG }
    public Class unitClass = Class.Rifleman;

    void Awake()
    {
        mover = GetComponent<UnitMover>();
        squad = transform.parent.GetComponent<Squad>();
        weapon = GetComponent<UnitWeapon>();

		muzzleEffect = Instantiate(muzzleEffect_prefab, this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5));

		tracerEffect = Instantiate(tracerEffect_prefab, this.transform.GetChild(1) // hips
			.GetChild(2) // spine
			.GetChild(0) //spine 1
			.GetChild(0) //spine 2
			.GetChild(2) //right should
			.GetChild(0) // right arm
			.GetChild(0) // rightfore arm
			.GetChild(0) //right hand
			.GetChild(5));

		//Set unit muzzle color
		switch (unitClass) {
		case Class.Rifleman:
			{
				tracerEffect.GetComponent<ParticleSystem>().startColor = Color.red;
				muzzleEffect.GetComponent<ParticleSystem>().startColor = Color.red;

				break;
			}
		case Class.HeavyAssault:
			{
				tracerEffect.GetComponent<ParticleSystem>().startColor = Color.cyan;
				muzzleEffect.GetComponent<ParticleSystem>().startColor = Color.cyan;

				break;
			}
		case Class.Sniper:
			{
				tracerEffect.GetComponent<ParticleSystem>().startColor = Color.magenta;
				muzzleEffect.GetComponent<ParticleSystem>().startColor = Color.magenta;

				break;
			}
		case Class.MG:
			{
				tracerEffect.GetComponent<ParticleSystem>().startColor = Color.green;
				muzzleEffect.GetComponent<ParticleSystem>().startColor = Color.green;

				break;
			}
		}
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
