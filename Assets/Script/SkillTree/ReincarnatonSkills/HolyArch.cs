using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class HolyArch: ANGEL_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return 1 + (long)(P_level * pas2 / 5d);
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
    public override double CostLeaf()
    {
        return Math.Pow(300, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#32ff32>Lv : + " + tDigit(Damage());
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 52;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 0f,0f,1f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewAngel].GetCurrentValue() >= 3)
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
            windowSkillIcon.sprite = main.Sprites[52];
            skillNameString = "Holy Arch < <color=\"green\">Lv " + P_level + " </color>>";
            linageString = "Angel <color=#32ff32>Spirit</color>";
            effectString = "- Normal Skill Level : <color=green> + " + tDigit(Damage()) + "</color>";
            if (P_level>=100)
                effectString += "  ( Passive : <color=green> + " + tDigit((long)(Damage()*0.5d)) + " </color>)";
            if (pas1 > 0)
                effectString += "\n- Reincarnation Skill Level : <color=green> + " + (long)(Damage()*pas1) + "</color>";
            if (P_level >= 100)
                effectString += "  ( Passive : <color=green> + " + tDigit((long)(Damage() * pas1 * 0.5d)) + " </color>)";
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Summon a holy arch in the sky, which gives a bonus \n  to Normal Skill Level.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "20% of effect applies to Reincarnation Skill") + "\n" + Color(100, "Activates 50% of effect even when not equipped") + "\n" + Color(150, "50% of effect applies to Reincarnation Skill") + "\n" + Color(200, "Increase the effect + 100%");
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
            windowSkillIcon.sprite = main.Sprites[52];
            skillNameString = "Holy Arch < <color=\"green\">Lv " + P_level + " </color>>";
            linageString = "Angel <color=#32ff32>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostLeaf(), 2) + " leaves";
        }

        //MP
        mpFactor = P_level * (-10);

        //Passive
        if (P_level < 50)
            pas1 = 0;
        else if (P_level < 150)
            pas1 = 0.2;
        else
            pas1 = 0.5;
        if (P_level < 200)
            pas2 = 1;
        else
            pas2 = 2;


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
