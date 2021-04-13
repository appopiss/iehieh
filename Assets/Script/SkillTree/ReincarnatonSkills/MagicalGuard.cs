using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class MagicalGuard: WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return BuffedLevel();
        //if (BuffedLevel() <= 80)
        //    return Math.Min(0.10d + BuffedLevel() * 0.01d,0.90d);
        //else if (BuffedLevel() <= 170)
        //    return Math.Min(0.90d + (BuffedLevel()-80) * 0.001d,0.99d);
        //else if (BuffedLevel() <= 260)
        //    return Math.Min(0.990d + (BuffedLevel()-170) * 0.0001d,0.999d);
        //else if (BuffedLevel() <= 350)
        //    return Math.Min(0.9990d + (BuffedLevel()-260) * 0.00001d,0.9999d);
        //else if (BuffedLevel() <= 440)
        //    return Math.Min(0.99990d + (BuffedLevel()-350) * 0.000001d,0.99999d);
        //else if (BuffedLevel() <= 530)
        //    return Math.Min(0.999990d + (BuffedLevel()-440) * 0.0000001d,0.999999d);
        //else
        //    return 0.999999d;

    }
    //無敵チャンス
    public override double Chance()
    {
        return Math.Min(0.2f + BuffedLevel() * 0.0005f, 0.80f);
    }
    float Time()
    {
        return (float)(2 + pas1);
    }

    //スキル固有のSPD
    public override float AttackInterval()
    {
        return 1e38f;
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 30 * (P_level + 1) + 8 * Math.Pow(P_level, 5);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return Math.Pow(300, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        DpsText.text += "DMG per MP : " + tDigit(Damage());
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 42;
        isReinSkill = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 0f,1f,0f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWizard].GetCurrentValue() >= 3)
        {
            canGetExp = true;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = true;
            StartCoroutine(Activate());
        }
        else
        {
            canGetExp = false;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = false;
        }
    }

    IEnumerator Activate()
    {
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.ally.isMagicalGuard);
            setActive(main.ally.gameObject.transform.GetChild(6).gameObject);
            yield return new WaitForSeconds(Time());
        }

    }

    public void ResetEffect()
    {
        if (main.ally.gameObject.transform.GetChild(2).gameObject != null)
            setFalse(main.ally.gameObject.transform.GetChild(6).gameObject);
        main.ally.isMagicalGuard = false;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[42];
            skillNameString = "Magical Guard < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Wizard <color=#ffe400>Spirit</color>";
            effectString = "- Cut damage per MP : " + tDigit(Damage());
            effectString += "\n- Invincible Chance : " + percent(Chance());
            if (P_level >= 200)
                effectString += "  ( 100% at Max MP )";
            effectString += "\n- Invincible Time : " + tDigit(Time()) + " s";
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Summon a magical guard which cancels received damage with MP.\n- Sometimes become invincible when get hit.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "MP Gain from this skill + 400%") + "\n" + Color(100, "Invincible Time + 3 s") + "\n" + Color(150, "Invincible Time + 5 s") + "\n" + Color(200, "100% Invincible Chance when MP is at max");
            }
            else
            {
                requiredAndPassiveString = "Required Skill";
                requiredSkillString = "";
            }
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[42];
            skillNameString = "Magical Guard < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Wizard <color=#ffe400>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostCristal(), 2) + " crystals";
        }

        //MP
        if (P_level < 50)
            mpFactor = BuffedLevel() * (-10);
        else
            mpFactor = BuffedLevel() * (-10) * 5;


        //Passive
        if (P_level < 100)
            pas1 = 0;
        else if (P_level < 150)
            pas1 = 3;
        else
            pas1 = 8;
    }

    public override void GetProf()
    {
        P_exp += culGetExp();
    }
    public override IEnumerator Attacking()
    {
        //ENEMY targetEnemy;
        while (true)
        {
            yield return new WaitUntil(CanBuff);
            GetProf();
            yield return new WaitForSeconds(1f);
        }
    }
    public override bool CanBuff()
    {
        return IsEquipped() && !main.DeathPanel.isPanel;
    }

}
