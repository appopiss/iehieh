using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveShieldAttack : POPTEXT_Passive {

    // Use this for initialization
    void Awake()
    {
        awakeText();
    }

    // Use this for initialization
    void Start()
    {
        startText();
        if (!onlyDisplay)
        {

            main.SR.P_ShieldAttack = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[8];
            skillNameString = "Shield Stance < <color=\"green\">Lv " + main.warriorSkillAry[8].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_ShieldAttack)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- DEF + " + percent(effect()) + "\n- MDEF + " + percent(effect());
            explainString = "- Activate Shield Stance for 5 seconds every 30 hits.\n- Hit counts : " + tDigit(main.warriorSkillAry[8].attackNum);
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.warriorSkillAry[8].attackNum >= 30);
            main.warriorSkillAry[8].attackNum = 0;
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(3).gameObject);
            main.ally.warriorPassiveShieldFactor = effect();
            yield return new WaitForSeconds(5f);
        }
    }
    public void ResetEffect()
    {
        main.ally.warriorPassiveShieldFactor = 0;
        if (gameObject.transform.GetChild(1).gameObject!=null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
        if (main.ally.gameObject.transform.GetChild(3).gameObject!=null)
            setFalse(main.ally.gameObject.transform.GetChild(3).gameObject);
    }

    double effect()
    {
        return 10;
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
            main.ally.warriorPassiveShieldFactor = 0;
        }
            //main.SR.P_ShieldAttack = false;
    }
}
