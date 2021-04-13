using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class spicy : ABNORMAL
{

    // Use this for initialization
    void Awake()
    {
        AwakeCor();
    }

    // Use this for initialization
    void Start()
    {
        StartCor();
        skillNameString = "Spicy Potion";
        effectString = "<color=green>- SPD + 100000";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCor();
    }

    public override IEnumerator Effect()
    {
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.spicy] = true;
        main.ally.buffSpdFactor2 = 100000;
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.buffSpdFactor2 = 0;
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.spicy] = false;
    }
}
