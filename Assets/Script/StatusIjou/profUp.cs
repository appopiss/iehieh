using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class profUp : ABNORMAL {

	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        skillNameString = "Hold Wings";

    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        effectString = "<color=green>- Skill Proficiency + " + percent(main.angelSkillAry[9].Damage() / 100);
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.prof] = true;
        yield return null;
    }

    private void OnDestroy()
    {
        Destroy(window);
        main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.prof] = false;
    }
}
