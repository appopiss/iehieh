using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ComboAttack: WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.combo * BuffedLevel() * pas1 / 1000;
    }    
    long maxCombo()
    {
        return (long)pas2 * BuffedLevel() * 1000;
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
    public override double CostCristal()
    {
        return Math.Pow(200, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        DpsText.text += "MDMG : + " + percent(BuffedLevel() * pas1 / 1000, 1) + " / C";
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 41;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 0f,1f,0f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWizard].GetCurrentValue() >= 2)
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
            windowSkillIcon.sprite = main.Sprites[41];
            skillNameString = "Magical Combo < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Wizard <color=#ffe400>Spirit</color>";
            effectString = "- Magical Damage : <color=green> + " + percent(Damage()) + "  </color>( + " + percent(P_level * pas1 / 1000, 1) + " per combo )"
                + "\n- Max Combo : " + maxCombo();
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Increases Magical Damage according to combos with each hit.\n- Combo resets when you receive damage.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Increase the effect per combo + 100%") + "\n" + Color(100, "Only lose 50% of combo when receiving damage") + "\n" + Color(150, "Increase Max Combo * 100") + "\n" + Color(200, "Increase the effect per combo + 300%");
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
            windowSkillIcon.sprite = main.Sprites[41];
            skillNameString = "Magical Combo < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Wizard <color=#ffe400>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostCristal(), 2) + " crystals";
        }

        //MP
        mpFactor = BuffedLevel() * (-10);

        //Passive
        if (P_level < 50)
            pas1 = 1;
        else if (P_level < 200)
            pas1 = 2;
        else
            pas1 = 5;

        if (P_level < 150)
            pas2 = 1;
        else
            pas2 = 100;

        if (IsEquipped())
        {
            if (main.ally.combo >= maxCombo())
                main.ally.combo = maxCombo();
        }
        else
            main.ally.combo = 0;

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
