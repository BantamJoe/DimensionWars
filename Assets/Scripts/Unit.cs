using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitWeapon))]
[RequireComponent(typeof(UnitHealth))]
public class Unit : MonoBehaviour
{
    public UnitMover mover;
    public Unit target;
    public float gunCooldown;
    public Squad squad;
    public UnitWeapon weapon;

	public GameObject muzzleEffect_prefab;
	public GameObject tracerEffect_prefab;

	public GameObject muzzleEffect;
	public GameObject tracerEffect;

    public enum Class { Rifleman, HeavyAssault, Sniper, MG, Commander }
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
		case Class.Commander:
			{
				tracerEffect.GetComponent<ParticleSystem> ().startColor = Color.yellow;
				muzzleEffect.GetComponent<ParticleSystem>().startColor = Color.yellow;

				break;
			}
		}
    }

    void Update()
    {
        gunCooldown -= Time.deltaTime;
        gunCooldown = Mathf.Max(gunCooldown, 0);
    }

    public void SetTarget(Unit target)
    {
        this.target = target;
    }

    public void SetImmediateMoveTarget(Vector3 target)
    {
        mover.SetTarget(target);
    }
}
