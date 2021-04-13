using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class atkUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Muscle Inflation";
    }
	
	// Update is called once per frame
	void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- ATK + " + tDigit(main.angelSkillAry[4].Damage());
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.muscleInflation] = true;
        main.ally.buffAtkFactor = (main.angelSkillAry[4].Damage());
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.buffAtkFactor = 0;
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.muscleInflation] = false;
    }
}
