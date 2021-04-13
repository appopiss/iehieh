using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class spdUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Haste";
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- SPD + " + percent(main.angelSkillAry[7].Damage() / 100);
        main.ally.isBuff[(int)Main.Buff.spd] = true;
        main.ally.buffSpdFactor = (main.angelSkillAry[7].Damage() / 100);
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.buffSpdFactor = (main.angelSkillAry[7].Damage() / 100);
        main.ally.isBuff[(int)Main.Buff.spd] = false;
    }
}
