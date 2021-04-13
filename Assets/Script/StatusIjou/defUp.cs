using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class defUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Protect Wall";
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- DEF + " + tDigit(main.angelSkillAry[6].Damage()) + "\n- MDEF + " + tDigit(main.angelSkillAry[6].Damage());
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.def] = true;
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.mDef] = true;
        main.ally.buffDefFactor = (main.angelSkillAry[6].Damage());
        main.ally.buffMDefFactor = (main.angelSkillAry[6].Damage());
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.def] = false;
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.mDef] = false;
        main.ally.buffDefFactor = 0;
        main.ally.buffMDefFactor = 0;
    }
}
