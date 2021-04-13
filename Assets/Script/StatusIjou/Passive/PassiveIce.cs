using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveIce : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_ice = true;
            //StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[14];
            skillNameString = "Ice Stance < <color=\"green\">Lv " + main.wizardSkillAry[4].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_ice)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- MATK Down with " + percent(chance()) + " chance\n- Ice Ball Size * " + tDigit(effect(),2) + "</color>";
            explainString = "- Have a chance to trigger Greater Ice Ball.\n- Only works while Ice Ball is equipped";
        }
    }

    //IEnumerator Activate()
    //{
    //    while (true)
    //    {
    //        ResetEffect();
    //        yield return new WaitUntil(() => main.wizardSkillAry[0].attackNum >= 25);
    //        main.wizardSkillAry[0].attackNum = 0;
    //        setActive(gameObject.transform.GetChild(1).gameObject);
    //        setActive(main.ally.gameObject.transform.GetChild(2).gameObject);
    //        main.ally.wizardPassiveStaffFactor = effect();
    //        yield return new WaitForSeconds(5f);
    //    }
    //}

    public void ResetEffect()
    {
        //main.ally.wizardPassiveStaffFactor = 0;
        //setFalse(gameObject.transform.GetChild(1).gameObject);
        //setFalse(main.ally.gameObject.transform.GetChild(2).gameObject);
    }


    double effect()
    {
        return Mathf.Min(1 + (float)main.wizardSkillAry[4].BuffedLevel() / 50f, 5);
    }
    double chance()
    {
        return Math.Min(0.05 + (double)main.wizardSkillAry[4].BuffedLevel() / 2000d, 0.2);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
        }
            //main.SR.P_SwordAttack = false;
    }
}
