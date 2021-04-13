using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class goldUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Angel Distraction";
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- Gained Gold + " + percent(main.angelSkillAry[8].Damage() / 100);
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.gold] = true;
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.gold] = false;
    }
}
