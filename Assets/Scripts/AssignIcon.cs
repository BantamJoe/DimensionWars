using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignIcon : MonoBehaviour {

    public enum Class { Rifleman, HeavyAssault, Sniper, MG }
    public Class unitClass;
   
    //public Image imgMedic1;
    //public Image imgMedic2;

    //public Sprite medic1;
    //public Sprite medic2;

    //public Image imgSniper1;
    //public Image imgSniper2;
    //public Image imgSniper3;

    //public Sprite sniper1;
    //public Sprite sniper2;
    //public Sprite sniper3;

    public Image imgClass1;
    public Image imgClass2;
    public Image imgClass3;
    public Image imgClass4;

    public Sprite class1;
    public Sprite class2;
    public Sprite class3;
    public Sprite class4;

    void Start()
    {
        ChangeImg();
    }

    void ChangeImg()
    {
        if(unitClass == Class.MG)
        {
            //imgMedic1.enabled = true;
            //imgMedic2.enabled = true;

            //imgMedic1.rectTransform.sizeDelta = new Vector2(50, 100);
            //imgMedic2.rectTransform.sizeDelta = new Vector2(100, 50);

            //imgMedic1.overrideSprite = medic1;
            //imgMedic2.overrideSprite = medic2;

            imgClass1.enabled = true;
            imgClass2.enabled = true;

            imgClass1.rectTransform.sizeDelta = new Vector2(50, 100);
            imgClass2.rectTransform.sizeDelta = new Vector2(100, 50);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
        }

        if(unitClass == Class.Sniper)
        {
            //imgSniper1.enabled = true;
            //imgSniper2.enabled = true;
            //imgSniper3.enabled = true;

            //imgSniper1.rectTransform.sizeDelta = new Vector2(100, 100);
            //imgSniper2.rectTransform.sizeDelta = new Vector2(70, 70);
            //imgSniper3.rectTransform.sizeDelta = new Vector2(40, 40);

            //imgSniper1.overrideSprite = sniper1;
            //imgSniper2.overrideSprite = sniper2;
            //imgSniper3.overrideSprite = sniper3;

            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;

            imgClass1.rectTransform.sizeDelta = new Vector2(100, 100);
            imgClass2.rectTransform.sizeDelta = new Vector2(70, 70);
            imgClass3.rectTransform.sizeDelta = new Vector2(40, 40);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;

        }

        if (unitClass == Class.Rifleman)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;

            imgClass1.rectTransform.sizeDelta = new Vector2(30, 100);
            imgClass2.rectTransform.sizeDelta = new Vector2(30, 100);

            imgClass1.rectTransform.rotation = Quaternion.Euler(0,0,45);
            imgClass2.rectTransform.rotation = Quaternion.Euler(0,0,-45);          

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;          
        }

        if (unitClass == Class.HeavyAssault)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;
            imgClass4.enabled = true;

            imgClass1.rectTransform.sizeDelta = new Vector2(20, 100);
            imgClass2.rectTransform.sizeDelta = new Vector2(20, 100);
            imgClass3.rectTransform.sizeDelta = new Vector2(20, 100);
            imgClass4.rectTransform.sizeDelta = new Vector2(20, 100);

            imgClass1.rectTransform.localPosition = new Vector3(30, 0, 0);
            imgClass2.rectTransform.localPosition = new Vector3(-30, 0, 0);
            imgClass3.rectTransform.localPosition = new Vector3(10, 0, 0);
            imgClass4.rectTransform.localPosition = new Vector3(-10, 0, 0);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;
            imgClass4.overrideSprite = class4;
        }
    }
}
