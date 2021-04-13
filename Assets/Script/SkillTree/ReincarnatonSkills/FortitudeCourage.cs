using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class FortitudeCourage: WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        if (main.ally.stayTime > 0)
            return main.ally.stayTime * DamagePerStaytime() + pas1;
        else
            return 0;
    }
    public double DamagePerStaytime()
    {
        return pas2 * BuffedLevel() / 100;
    }

    double maxTime()
    {
        return BuffedLevel() * 60d;
    }


    IEnumerator CountStayTime()
    {
        while (true)
        {
            yield return new WaitUntil(() => !main.ally.isMoving);
            yield return new WaitForSeconds(1f);
            if(!main.ally.isMoving && IsEquipped())
                main.ally.stayTime += 1;
        }
    }
    IEnumerator DecreaseStayTime()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.ally.isMoving);
            main.ally.stayTime -= 0.5;//10倍の速さで減ってく
            if (main.ally.stayTime < 0)
                main.ally.stayTime = 0;
            yield return new WaitForSeconds(0.05f);
        }
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
    public override double CostStone()
    {
        return Math.Pow(300, P_level);
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#00C8FF>";
        DpsText.text += "PDMG : + " + percent(DamagePerStaytime(), 1) + " / s";
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 32;
        isReinSkill = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Spirit", 1f, 1f,0f,0f,DamageKind.nothing);
        //スキル開放条件
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWarrior].GetCurrentValue() >= 3)
        {
            canGetExp = true;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            canGetExp = false;
            gameObject.transform.parent.GetComponent<Canvas>().enabled = false;
        }
        StartCoroutine(CountStayTime());
        StartCoroutine(DecreaseStayTime());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[32];
            skillNameString = "Fortitude Courage < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            if (pas1 == 0)
                effectString = "- Physical Damage : <color=green> + " + percent(Damage(),1) + "  </color>( + " + percent(DamagePerStaytime(),1) + " / s )";
            else
                effectString = "- Physical Damage : <color=green> + " + percent(Damage(),1) + "  </color>( " + percent(pas1,1) + " + " + percent(DamagePerStaytime(),1) + " / s )";
            effectString += "\n- Max Standing-still Time : " + DoubleTimeToDate(maxTime());
            explainString = "- Gain " + tDigit(-1 * ConsumeMp(), 2) + " MP / s\n- Stand with your arms crossed meditating for the fight \n  and Physical Damage increases while not moving.";
            if (canGetExp)
            {
                requiredAndPassiveString = "Passive Effect";
                requiredSkillString = Color(50, "Initial Physical Damage + 2000%") + "\n" + Color(100, "Incerease the effect + 400%") + "\n" + Color(150, "Dodge Chance + 50% while not moving") + "\n" + Color(200, "Incerease the effect + 1500%");
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
            windowSkillIcon.sprite = main.Sprites[32];
            skillNameString = "Fortitude Courage < <color=\"green\">Lv " + BuffedLevelString() + " </color>>";
            linageString = "Warrior <color=#00C8FF>Spirit</color>";
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            costString = "- Gain 1.0% / " + tDigit(P_requiredExp() / (culGetExp() * 100), 2) + " seconds\n- Gain 1.0% / " + tDigit(CostStone(), 2) + " stones";
        }

        //MP
        mpFactor = BuffedLevel() * (-10);

        //Passive
        if (P_level < 50)
            pas1 = 0;
        else 
            pas1 = 20;

        if (P_level < 100)
            pas2 = 1;
        else if (P_level < 200)
            pas2 = 5;
        else
            pas2 = 20;

        if (P_level >= 150 && !main.ally.isMoving)
        {
            if (main.S.job == ALLY.Job.Warrior || main.MissionMileStone.IsSkillPassiveEffect())
                pas3 = 0.5;
            else
                pas3 = 0;
        }
        else
            pas3 = 0;

        if (!IsEquipped())
            main.ally.stayTime = 0;
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
