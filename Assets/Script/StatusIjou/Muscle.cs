using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Muscle : ABNORMAL
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
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.muscleInflation] = true;
        yield return null;
    }

    private void OnDestroy()
    {
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.muscleInflation] = false;
    }
}
