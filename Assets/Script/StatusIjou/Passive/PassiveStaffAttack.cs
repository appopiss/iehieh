using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveStaffAttack : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_StaffAttack = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[10];
            skillNameString = "Attack Stance < <color=\"green\">Lv " + main.wizardSkillAry[0].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_StaffAttack)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- MATK + " + percent(effect()) + "</color>\n<color=red>- MDEF - " + percent(effect()) + "</color>";
            explainString = "- Activate Attack Stance for 5 seconds every 25 hits.\n- Hit counts : " + tDigit(main.wizardSkillAry[0].attackNum);
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.wizardSkillAry[0].attackNum >= 25);
            main.wizardSkillAry[0].attackNum = 0;
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(2).gameObject);
            main.ally.wizardPassiveStaffFactor = effect();
            yield return new WaitForSeconds(5f);
        }
    }

    public void ResetEffect()
    {
        main.ally.wizardPassiveStaffFactor = 0;
        setFalse(gameObject.transform.GetChild(1).gameObject);
        setFalse(main.ally.gameObject.transform.GetChild(2).gameObject);
    }


    double effect()
    {
        return Math.Min(0.2 + (double)main.wizardSkillAry[0].BuffedLevel() / 1000d, 1);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
            main.ally.wizardPassiveStaffFactor = 0;
        }
            //main.SR.P_SwordAttack = false;
    }
}
