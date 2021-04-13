using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveGodBless : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_GodBless = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[23];
            skillNameString = "Resurrection Stance < <color=\"green\">Lv " + main.angelSkillAry[3].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_GodBless)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- Resurrection Chance : " + percent(chance()) +"</color>";
            explainString = "- Have a chance of resurrection when you die.\n- Only works while God Bless is equipped.";
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(()=>main.ally.isResurrection&&isEquipped());
            main.ally.currentHp = main.ally.HP();
            main.ally.isResurrection = false;
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(4).gameObject);
            //main.ally.warriorPassiveSwordFactor = effect();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void ResetEffect()
    {
        main.ally.resurrectionChance=chance();
        main.ally.isResurrection = false;
        if (gameObject.transform.GetChild(1).gameObject != null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
        if (main.ally.gameObject.transform.GetChild(4).gameObject != null)
            setFalse(main.ally.gameObject.transform.GetChild(4).gameObject);
    }

    bool isEquipped()
    {
        foreach (var skillSlot in main.skillSlotCanvasAry)
        {
            if (skillSlot.currentSkill == main.angelSkillAry[3])
                return true;
        }
        return false;
    }


    double chance()
    {
        return Math.Min(0.2 + (double)main.angelSkillAry[3].BuffedLevel() / 2000d, 0.5);
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
