using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class maxHp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "God Bless";

    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- HP + " + percent(main.angelSkillAry[3].Damage() / 100);
        if (main.angelSkillAry[3].P_level >= 30)
            effectString += "\n- Regenerate HP : " + tDigit(main.ally.HP() * main.angelSkillAry[3].RegenePoint() * 0.01) + " / s";
        main.ally.isBuff[(int)Main.Buff.maxHp] = true;
        main.ally.buffHpFactor = (main.angelSkillAry[3].Damage() / 100);
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.buffHpFactor = 0;
        main.ally.isBuff[(int)Main.Buff.maxHp] = false;
    }
}
