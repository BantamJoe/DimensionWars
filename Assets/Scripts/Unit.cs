using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitWeapon))]
public class Unit : MonoBehaviour
{
    public UnitMover mover;
    public Unit target;
    public float gunCooldown;
    public Squad squad;
    public UnitWeapon weapon;

    public enum Class { Rifleman, HeavyAssault, Sniper, MG, Commander }
    public Class unitClass = Class.Rifleman;

    public Image imgClass1;
    public Image imgClass2;
    public Image imgClass3;
    public Image imgClass4;

    public Sprite class1;
    public Sprite class2;
    public Sprite class3;
    public Sprite class4;

    void Awake()
    {
        mover = GetComponent<UnitMover>();
        squad = transform.parent.GetComponent<Squad>();
        weapon = GetComponent<UnitWeapon>();
    }

    void Start()
    {
        ChangeImg();
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

    public void ChangeImg()
    {
        if (unitClass == Unit.Class.MG)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;

            if (squad.team == 1)
            {
                imgClass1.color = Color.red;
                imgClass2.color = Color.red;
            }

            imgClass1.rectTransform.sizeDelta = new Vector2(200, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(500, 200);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
        }

        if (unitClass == Unit.Class.Sniper)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;

            if (squad.team == 1)
            {
                imgClass1.color = Color.red;
                imgClass2.color = Color.red;
            }

            imgClass1.rectTransform.sizeDelta = new Vector2(500, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(350, 350);
            imgClass3.rectTransform.sizeDelta = new Vector2(250, 250);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;

        }

        if (unitClass == Unit.Class.Rifleman)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;

            if (squad.team == 1)
            {
                imgClass1.color = Color.red;
                imgClass2.color = Color.red;
            }

            imgClass1.rectTransform.sizeDelta = new Vector2(100, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(100, 500);

            imgClass1.rectTransform.rotation = Quaternion.Euler(0, 0, 45);
            imgClass2.rectTransform.rotation = Quaternion.Euler(0, 0, -45);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
        }

        if (unitClass == Unit.Class.HeavyAssault)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;
            imgClass4.enabled = true;

            if (squad.team == 1)
            {
                imgClass1.color = Color.red;
                imgClass2.color = Color.red;
            }

            imgClass1.rectTransform.sizeDelta = new Vector2(150, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(150, 500);
            imgClass3.rectTransform.sizeDelta = new Vector2(150, 500);
            imgClass4.rectTransform.sizeDelta = new Vector2(150, 500);

            imgClass1.rectTransform.localPosition = new Vector3(75, 0, 0);
            imgClass2.rectTransform.localPosition = new Vector3(-375, 0, 0);
            imgClass3.rectTransform.localPosition = new Vector3(-75, 0, 0);
            imgClass4.rectTransform.localPosition = new Vector3(-225, 0, 0);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;
            imgClass4.overrideSprite = class4;
        }

        if (unitClass == Unit.Class.Commander)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;
            imgClass4.enabled = true;

            if (squad.team == 1)
            {
                imgClass1.color = Color.red;
                imgClass2.color = Color.red;
            }

            imgClass1.rectTransform.sizeDelta = new Vector2(200, 200);
            imgClass2.rectTransform.sizeDelta = new Vector2(200, 200);
            imgClass3.rectTransform.sizeDelta = new Vector2(200, 200);
            imgClass4.rectTransform.sizeDelta = new Vector2(200, 200);

            imgClass1.rectTransform.localPosition = new Vector3(150, 150, 0);
            imgClass2.rectTransform.localPosition = new Vector3(-150, -150, 0);
            imgClass3.rectTransform.localPosition = new Vector3(-150, 150, 0);
            imgClass4.rectTransform.localPosition = new Vector3(150, -150, 0);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;
            imgClass4.overrideSprite = class4;
        }
    }
}
