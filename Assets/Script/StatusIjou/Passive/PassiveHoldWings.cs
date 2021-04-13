using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveHoldWings : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_HoldWing = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[29];
            skillNameString = "Divine Stance < <color=\"green\">Lv " + main.angelSkillAry[9].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_HoldWing)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "- Trigger Chance : " + percent(chance()) + "\n- Divine damage : " + tDigit(Damage(),2) + " * 5\n- Cure and disperse the debuff";
            explainString = "- Every 5 seconds has a chance to call forth a divine attack.\n- Divine damage is defined by the average of ATK & MATK\n- Only works while Hold Wings is equipped.";
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.SR.P_HoldWing && isEquipped());
            yield return new WaitForSeconds(5f);
            if (!main.isDevine && UnityEngine.Random.Range(0, 10000) <= chance()*10000)
            {
                main.isDevine = true;
                debuff = Main.Debuff.nothing;
                Cure();
                StartCoroutine(main.InstantiateAnimation(main.animationObject[57], main.ally1.GetComponent<RectTransform>(), Damage(), 0, SKILL.DamageKind.divine, debuff));
                setActive(gameObject.transform.GetChild(1).gameObject);
                main.isDevine = false;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    bool isEquipped()
    {
        foreach (var skillSlot in main.skillSlotCanvasAry)
        {
            if (skillSlot.currentSkill == main.angelSkillAry[9])
                return true;
        }
        return false;
    }
    
    double Damage()
    {
        if (main.angelSkillAry[9].BuffedLevel() < 1500)
            return (100 * main.angelSkillAry[9].BuffedLevel() + Math.Pow(1.0675, main.angelSkillAry[9].BuffedLevel())) * (main.ally.Atk() + main.ally.MAtk()) / 2;
        else
            return (100 * main.angelSkillAry[9].BuffedLevel() + Math.Pow(1.0675, 1500 + (main.angelSkillAry[9].BuffedLevel() - 1500) / 2)) * (main.ally.Atk() + main.ally.MAtk()) / 2;
    }

    double chance()
    {
        return Math.Min(0.05 + (double)main.angelSkillAry[9].BuffedLevel() / 1000d, 0.5);
    }

    Main.Debuff debuff;

    public void Cure()
    {
            foreach (Transform child in main.StatusIconCanvas)
            {
                if (child.GetComponent<ABNORMAL>().debuff != Main.Debuff.nothing)
                {
                    debuff = child.GetComponent<ABNORMAL>().debuff;
                    Destroy(child.gameObject);
                }
            }
    }

    public void ResetEffect()
    {
        if (gameObject.transform.GetChild(1).gameObject != null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
        }
    }
}
