using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitWeapon))]
public class Unit : MonoBehaviour
{
    public UnitMover mover;
    public Unit target;
    public float gunCooldown;
    public Squad squad;
    public UnitWeapon weapon;

    public enum Class { Rifleman, HeavyAssault, Sniper, MG }
    public Class unitClass = Class.Rifleman;

    void Awake()
    {
        mover = GetComponent<UnitMover>();
        squad = transform.parent.GetComponent<Squad>();
        weapon = GetComponent<UnitWeapon>();
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
