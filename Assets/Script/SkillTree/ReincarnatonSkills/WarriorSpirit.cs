using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class WarriorSpirit : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return BuffedLevel();
    }
    //HP*10
    //ATK*1

    //スキル固有のSPD
    public override float AttackInterval()
    {
        return 1e38f;
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 10 * (P_level + 1) + 2 * Math.Pow(P_level, 4);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return Math.Pow(100, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s";//"<color=#00C8FF>Stats : + " + tDigit(Damage(), 2);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 30;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 1f,0f,0f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWarrior].GetCurrentValue() >= 1)
        {
            canGetExp = true;
        }
        else
            canGetExp = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[30];
            skillNameString = "Warrior Spirit < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            effectString = "- HP :  <color=green>+ " + tDigit(main.SR.spiritWar*10) + " </color>  ( + " + tDigit(Damage()*10) + " for each level up )\n- ATK :  <color=green>+ " + tDigit(main.SR.spiritWar) + " </color>  ( + " + tDigit(Damage()) + " for each level up )";
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Gain additional stats for every time hero level up.\n- Only gains stats per level up when equipped.";

                if (canGetExp)
                {
                    requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Gains 25% of stats effect even when not equipped") + "\n" + Color(100, "Increase Spirit Essence Gain + 50%") + "\n" + Color(150, "Gains 50% of stats effect even when not equipped") + "\n" + Color(200, "Increase Spirit Essence Gain + 100%") + "\n" + Color(250, "Gains 75% of stats effect even when not equipped") + "\n" + Color(300, "Increase Spirit Essence Gain + 200%");
                setFalse(window2Text5.gameObject);
                    setFalse(window2Text6.gameObject);
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
            windowSkillIcon.sprite = main.Sprites[30];
            skillNameString = "Warrior Spirit < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
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
            pas1 = 0.25;
        else if (P_level < 250)
            pas1 = 0.5;
        else
            pas1 = 0.75;
        //SEBonus
        if (P_level < 100)
            pas2 = 0;
        else if (P_level < 200)
            pas2 = 0.5;
        else if (P_level < 300)
            pas2 = 1.5;
        else
            pas2 = 3.5;


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
