using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class defDown : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        main.ally.isDebuff[(int)Main.Debuff.defDown] = true;
        main.ally.isDebuff[(int)Main.Debuff.mDefDown] = true;
        skillNameString = "DEF & MDEF Down";
        effectString = "<color=red>- DEF : " + percent(abnormalDamage) + "\n- MDEF : " + percent(abnormalDamage);
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        if (abnormalDamage == 0)
            yield break;

        main.ally.tempDefFactor = abnormalDamage;
        main.ally.tempMdefFactor = abnormalDamage;
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally.tempDefFactor = 1;
        main.ally.tempMdefFactor = 1;
        main.ally.isDebuff[(int)Main.Debuff.defDown] = false;
        main.ally.isDebuff[(int)Main.Debuff.mDefDown] = false;
    }
}
