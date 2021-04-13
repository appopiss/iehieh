using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class AtkDown : ABNORMAL
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
        main.ally.isDebuff[(int)Main.Debuff.atkDown] = true;
        skillNameString = "ATK Down";
        effectString = "<color=red>- ATK : " + percent(abnormalDamage);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCor();
    }

    public override IEnumerator Effect()
    {
        if (abnormalDamage == 0)
            yield break;

        main.ally.tempAtkFactor = abnormalDamage;
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.tempAtkFactor = 1;
        main.ally.isDebuff[(int)Main.Debuff.atkDown] = false;
    }
}
