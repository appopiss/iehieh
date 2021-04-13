using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class mAtkUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Magic Impact";
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- MATK + " + tDigit(main.angelSkillAry[5].Damage());

        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.magicImpact] = true;
        main.ally.buffMAtkFactor = (main.angelSkillAry[5].Damage());
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.buffMAtkFactor = 0;
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.magicImpact] = false;
    }
}
