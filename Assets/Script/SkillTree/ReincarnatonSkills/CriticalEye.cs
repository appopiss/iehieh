using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class CriticalEye : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        if (P_level > 0)
            return 1.500d + 0.001d * BuffedLevel();
        else
            return 1.000d;
    }
    public override double Chance()//Chanceとしているが、実際はStatsの増加倍率
    {
        return Math.Pow(Damage(), main.skillSetController.JobSkillSetNum(ALLY.Job.Warrior));
    }

    //スキル固有のSPD
    public override float AttackInterval()
    {
        return 1e38f;
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 50 * (P_level + 1) + 16 * Math.Pow(P_level, 6);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return Math.Pow(1000, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=white>Stats : * " + tDigit(Chance(), 3);//"<color=#00C8FF>Stats : + " + tDigit(Damage(), 2);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 33;
        isReinSkill = true;
        P_level = main.S.P_levelWarR4;
        canGetExp = main.S.canGetExtWarR4;
        P_exp = main.S.P_expWarR4;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 1f, 0f, 0f, DamageKind.nothing);

        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWarrior].GetCurrentValue() >= 4)
        {
            canGetExp = true;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            canGetExp = false;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[33];
            skillNameString = "Critical Eye < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            effectString = optStr + "- Ignores monsters' DEF (Passive)" + "\n- Multiplies Stats by <color=green>" + tDigit(Damage(), 3) + " ^ X </color> (Passive)"
                + "\n<color=orange><size=12>X is the # of Warrior's skills you set.\nThese effects are active even while not equipped and\nthe level never resets even through Reincarnation.</size></color>";
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Detects the weaknesses of monsters and\n  makes all attacks ignore monsters' DEF.\n- The effect is passive but you should\n  equip this to gain proficiency.";

                if (canGetExp)
                {
                    requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Worker Power + 5000% in Dark Ritual") + "\n" + Color(100, "Enable Auto-Rebirth while you are Warrior\n<color=orange><size=12>Hit R key on any area after 1-5. You automatically rebirth to\nWarrior just when you clear the area.</size></color>")
                    + "\n" + Color(150, "Worker Power + 15000% in Dark Ritual") + "\n" + Color(200, "Enable Auto-Reincarnation while you are Warrior\n<color=orange><size=12>Hit R key on this skill to activate Auto-Reincarnation.\nYou automatically reincarnate to Warrior just when you clear\narea 5-4 with 1e20 or more DPS.</size></color>");
                //setFalse(window2Text5.gameObject);
                //setFalse(window2Text6.gameObject);
            }
                else
                {
                    requiredAndPassiveString = "Required Skill";
                    requiredSkillString = "";
                }
            if (P_level>=200 && Input.GetKeyDown(KeyCode.R))
            {
                main.S.canAutoReinWarrior = !main.S.canAutoReinWarrior;                    
            }
            if (main.S.canAutoReinWarrior)
                requiredSkillString += "\n<color=green>Auto-Reincarnation is activated.</color>";
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[33];
            skillNameString = "Critical Eye < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostStone(), 2) + " stones";
        }

        //MP
        mpFactor = BuffedLevel() * (-10);


        //PassiveEffect
        //StatsGain
        if (P_level < 50)
            pas1 = 0;
        else if (P_level < 150)
            pas1 = 50;
        else
            pas1 = 200;

        if (P_level >= 100)
        {
            main.S.canAutoRebirth = true;
            main.S.canAutoRebirthWarrior = true;
        }
        if (P_level >= 200)
        {
            main.S.canAutoRein = true;
        }

        main.S.P_levelWarR4 = P_level;
        main.S.canGetExtWarR4 = canGetExp;
        main.S.P_expWarR4 = P_exp;
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
