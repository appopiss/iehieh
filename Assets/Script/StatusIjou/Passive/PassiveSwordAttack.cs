using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveSwordAttack : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

	// Use this for initialization
	void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_SwordAttack = true;
            StartCoroutine(Activate());
        }
    }
	
	// Update is called once per frame
	void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[0];
            skillNameString = "Attack Stance < <color=\"green\">Lv " + main.warriorSkillAry[0].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_SwordAttack)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- ATK + " + percent(effect()) + "</color>\n<color=red>- DEF - " + percent(effect()) + "</color>";
            explainString = "- Activate Attack Stance for 5 seconds every 25 hits.\n- Hit counts : " + tDigit(main.warriorSkillAry[0].attackNum);
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.warriorSkillAry[0].attackNum >= 25);
            main.warriorSkillAry[0].attackNum = 0;
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(2).gameObject);
            main.ally.warriorPassiveSwordFactor = effect();
            yield return new WaitForSeconds(5f);
        }

    }

    public void ResetEffect()
    {
        main.ally.warriorPassiveSwordFactor = 0;
        if(gameObject.transform.GetChild(1).gameObject!=null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
        if(main.ally.gameObject.transform.GetChild(2).gameObject!=null)
            setFalse(main.ally.gameObject.transform.GetChild(2).gameObject);
    }


    double effect()
    {
        return Math.Min(0.2 + (double)main.warriorSkillAry[0].BuffedLevel() / 500d, 1);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
            main.ally.warriorPassiveSwordFactor = 0;
        }
        //main.SR.P_SwordAttack = false;
    }
}
