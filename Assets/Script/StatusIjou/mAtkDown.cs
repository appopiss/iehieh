using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class mAtkDown : ABNORMAL {

    // Use this for initialization
    void Awake()
    {
        AwakeCor();
    }

    // Use this for initialization
    void Start()
    {
        StartCor();
        main.ally.isDebuff[(int)Main.Debuff.mAtkDown] = true;
        skillNameString = "MATK Down";
        effectString = "<color=red>- MATK : " + percent(abnormalDamage);
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

        main.ally.tempMatkFactor = abnormalDamage;
        yield return null;

    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.tempMatkFactor = 1;
        main.ally.isDebuff[(int)Main.Debuff.mAtkDown] = false;
    }
}
