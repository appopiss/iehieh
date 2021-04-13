using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveAngelDistruction : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_AngelDistruction = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[28];
            skillNameString = "Lucky Stance < <color=\"green\">Lv " + main.angelSkillAry[8].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_AngelDistruction)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- Double Drop Chance\n- Drop slot + 1</color>\n<color=red>- ATK : - " + percent(effect()) + "\n- MATK : - " + percent(effect());
            explainString = "- Increases chance to double drop.\n- Upgrades reduce the limitation on atk/ matk.\n- Only works while Angel Distraction is equipped";
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(()=>main.SR.P_AngelDistruction&&isEquipped());
            main.ally.angelPassiveFactor = effect();
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(5).gameObject);
            yield return new WaitUntil(()=>!main.SR.P_AngelDistruction||!isEquipped());
        }
    }

    bool isEquipped()
    {
        foreach (var skillSlot in main.skillSlotCanvasAry)
        {
            if (skillSlot.currentSkill == main.angelSkillAry[8])
                return true;
        }
        return false;
    }

    double effect()
    {
        return Math.Max(0.90 - (double)main.angelSkillAry[8].BuffedLevel() / 500d, 0.1);
    }


    public void ResetEffect()
    {
        main.ally.angelPassiveFactor = 0;

        if (gameObject.transform.GetChild(1).gameObject != null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
        if (main.ally.gameObject.transform.GetChild(5).gameObject != null)
            setFalse(main.ally.gameObject.transform.GetChild(5).gameObject);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
        }
    }
}
