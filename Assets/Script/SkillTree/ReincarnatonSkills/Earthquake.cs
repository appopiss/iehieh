using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Earthquake: WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.skillSetController.DPS() * BuffedLevel()/100d;
    }
    public override float CooltimeFactor()
    {
        return (float)pas1;
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
        return 20 * (P_level + 1) + 4 * Math.Pow(P_level, 4.5);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return Math.Pow(200, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#00C8FF>";
        if (P_level < 100)
        {
            DpsText.text += "DMG : " + tDigit(Damage()*25,2) + " * 2";
        }
        else if (P_level < 200)
        {
            DpsText.text += "DMG : " + tDigit(Damage() * 25,2) + " * 3";
        }
        else
        {
            DpsText.text += "DMG : " + tDigit(Damage() * 25,2) + " * 5";
        }
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 31;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 1f,0f,0f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWarrior].GetCurrentValue() >= 2)
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
            windowSkillIcon.sprite = main.Sprites[31];
            skillNameString = "Earthquake < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            effectString = "- Physical Damage : " + percent(25 * BuffedLevel() / 100d, 0) + " of sum of DPS of equipped\n  skills ( " + tDigit(main.skillSetController.DPS(), 2) + " ) * " + attackNum;
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Enable the special active skill.\n- Stab the sword into the ground strongly, causing giant\n  cracks in the ground.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Reduce cooldown by 45 s") + "\n" + Color(100, "Increase the number of attacks by 1") + "\n" + Color(150, "Reduce cooldown by 45 s") + "\n" + Color(200, "Increase the number of attacks by 2");
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
            windowSkillIcon.sprite = main.Sprites[31];
            skillNameString = "Earthquake < <color=\"green\">Lv " + BuffedLevelString()+ " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostStone(), 2) + " stones";
        }

        //MP
        mpFactor = BuffedLevel() * (-10);

        //Passive
        if (P_level < 50)
            pas1 = 0;
        else if (P_level < 150)
            pas1 = 45;
        else 
            pas1 = 90;
        if (P_level < 100)
            attackNum = 2;
        else if (P_level < 200)
            attackNum = 3;
        else
            attackNum = 5;

        if (IsEquipped())
            setActive(main.activeSkills[3].gameObject);
        else
            setFalse(main.activeSkills[3].gameObject);
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
