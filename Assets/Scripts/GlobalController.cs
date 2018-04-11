using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    public Squad c1;
    public Squad c2;
    public Squad c3;

    public bool c2Active;
    public bool c3Active;

    public GameObject c2Root;
    public GameObject c3Root;

    private void Update()
    {
        if (c1.IsDead() && !c2Active)
        {
            c2Active = true;
            c2Root.SetActive(true);
        }

        if (c2.IsDead() && !c3Active)
        {
            c3Active = true;
            c3Root.SetActive(true);
        }
    }
}
