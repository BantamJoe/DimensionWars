using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignIcon : MonoBehaviour {

    //public enum Class { Rifleman, HeavyAssault, Sniper, MG, Commander }
    //public Class unitClass;

    Unit.Class unitType;
   
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

    public void ChangeImg()
    {
        if(unitType == Unit.Class.MG)
        {           
            imgClass1.enabled = true;
            imgClass2.enabled = true;

            //if(Enemy)
            //{imgClass1.color = Color.red;
            //imgClass2.color = Color.red;}

            imgClass1.rectTransform.sizeDelta = new Vector2(200, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(500, 200);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
        }

        if(unitType == Unit.Class.Sniper)
        {         
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;

            //if(gameObject.name == "Soldier")
            //{imgClass1.color = Color.red;
            //imgClass2.color = Color.red;}

            imgClass1.rectTransform.sizeDelta = new Vector2(500, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(350, 350);
            imgClass3.rectTransform.sizeDelta = new Vector2(250, 250);

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;
            imgClass3.overrideSprite = class3;

        }

        if (unitType == Unit.Class.Rifleman)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;

            //if (gameObject.name == "Soldier")
            //{
            //    imgClass1.color = Color.red;
            //    imgClass2.color = Color.red;
            //}

            imgClass1.rectTransform.sizeDelta = new Vector2(100, 500);
            imgClass2.rectTransform.sizeDelta = new Vector2(100, 500);

            imgClass1.rectTransform.rotation = Quaternion.Euler(0,0,45);
            imgClass2.rectTransform.rotation = Quaternion.Euler(0,0,-45);          

            imgClass1.overrideSprite = class1;
            imgClass2.overrideSprite = class2;          
        }

        if (unitType == Unit.Class.HeavyAssault)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;
            imgClass4.enabled = true;

            //if(Enemy)
            //{imgClass1.color = Color.red;
            //imgClass2.color = Color.red;}

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

        if (unitType == Unit.Class.Commander)
        {
            imgClass1.enabled = true;
            imgClass2.enabled = true;
            imgClass3.enabled = true;
            imgClass4.enabled = true;

            //if (gameObject.name == "Soldier")
            //{
            //    imgClass1.color = Color.red;
            //    imgClass2.color = Color.red;
            //}

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
