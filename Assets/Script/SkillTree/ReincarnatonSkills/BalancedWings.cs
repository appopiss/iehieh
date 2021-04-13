using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class BalancedWings: ANGEL_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return (calculateFactor() / Math.Max((calculateFactor() - 0.9), 0.1) - 1) * (1 + BuffedLevel() / 50d);// x/(x-0.95)-1
    }
    double calculateFactor()
    {
        if (Math.Min(main.ally.Atk(), main.ally.MAtk()) <= 0)
            return 2;
        return Math.Max(main.ally.Atk(), main.ally.MAtk()) / Math.Min(main.ally.Atk(), main.ally.MAtk());
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return 1e38f;
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 20 * (P_level + 1) + 4 * Math.Pow(P_level, 4.5);
    }
    //必要コストの計算
    public override double CostLeaf()
    {
        return Math.Pow(200, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#32ff32>DMG : + " + percent(Damage());
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 51;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 0f,0f,1f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewAngel].GetCurrentValue() >= 2)
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
            windowSkillIcon.sprite = main.Sprites[51];
            skillNameString = "Balanced Wings < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Angel <color=#32ff32>Spirit</color>";
            effectString = "- Physical Damage : <color=green> + " + percent(Damage()) + "</color>";
            if (pas1 > 0)
                effectString += "  ( Passive : <color=green> + " + percent(Damage() * pas1) + " </color>)";
            effectString += "\n- Magical Damage : <color=green> + " + percent(Damage()) + "</color>";
            if (pas1 > 0)
                effectString += "  ( Passive : <color=green> + " + percent(Damage() * pas1) + " </color>)";
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- The more balanced ATK and MATK, the more Physical\n  and Magical Damage Increase when equipped.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Activates 25% of effect even when not equipped") + "\n" + Color(100, "Activates 50% of effect even when not equipped") + "\n" + Color(150, "Activates 75% of effect even when not equipped") + "\n" + Color(200, "Activates 100% of effect even when not equipped");
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
            windowSkillIcon.sprite = main.Sprites[51];
            skillNameString = "Balanced Wings < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Angel <color=#32ff32>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostLeaf(), 2) + " leaves";
        }

        //MP
        mpFactor = BuffedLevel() * (-10);

        //Passive
        if (P_level < 50)
            pas1 = 0;
        else if (P_level < 100)
            pas1 = 0.25;
        else if (P_level < 150)
            pas1 = 0.5;
        else if (P_level < 200)
            pas1 = 0.75;
        else
            pas1 = 1;


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
