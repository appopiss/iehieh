using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class FireStorm : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {

            return main.ally.MAtk() * (0.5 + BuffedLevel() * 0.35);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(5 - BuffedLevel() * 0.085), 1.5f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 100 * Math.Pow(1.14, P_level);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.4, P_level);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 12;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 80f, "Fire", 1f, 0, 300,0,DamageKind.magical);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[12];
            SkillLocal.firestorm(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            //PassiveEffect
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "攻撃回数 + 2") + "\n" + Color(50, "攻撃範囲 + 50%") + "\n" + Color(100, "ファイアストーム消費MP 1/2") + "\n" + Color(200, "ファイアストーム消費MP 0");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "攻击次数 + 2") + "\n" + Color(50, "技能伤害范围 + 50%") + "\n" + Color(100, "火焰风暴耗蓝 1/2") + "\n" + Color(200, "火焰风暴耗蓝 0");
                        break;
                    default:
                        requiredSkillString = Color(30, "Hit counts + 2") + "\n" + Color(50, "Attack Radius + 50%") + "\n" + Color(100, "Fire Storm Lost MP 1/2") + "\n" + Color(200, "Fire Storm Lost MP 0");
                        break;
                }
                setFalse(window2Text5.gameObject);
                setFalse(window2Text6.gameObject);
            }
            else
            {
                requiredAndPassiveString = SkillLocal.RequiredSkill();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = "<color=red>- ファイアボール < Lv 12 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 火球术 < Lv 12 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Fire Ball < Lv 12 ></color>";
                        break;
                }
            }


        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[12];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.firestorm(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        if (BuffedLevel() < 100)
        {
            mpFactor = BuffedLevel() * 8.45;
        }
        else if (BuffedLevel() < 200)
        {
            mpFactor = BuffedLevel() * 8.45 * 0.5 - consumeMp * 0.5;
        }
        else
            mpFactor = -consumeMp;

        //スキル開放条件
        if (main.wizardSkillAry[1].P_level >= 12)
        {
            canGetExp = true;
        }

        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.wizardSkillAry[3].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[3].skillCanvas);
        }
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        if (P_level < 30)
        {
            DpsText.text += "DPS : " + tDigit(Damage()  / AttackInterval(), 2) + " * 4" ;
        }
        else if (P_level >= 30)
        {
            DpsText.text += "DPS : " + tDigit(Damage()  / AttackInterval(), 2) + " * 6";
        }

    }


    public void DoesSkill()
    {
        if (P_level < 30)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[10], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 30 && P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[41], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[42], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
        }
    }

    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        if (searchEnemy() != null)
        {
            DoesSkill();
            GetProf();
        }
        else
        {
            GameObject EmptyObject = Instantiate(main.EmptyObject, main.Transforms[1]);
            EmptyObject.GetComponent<RectTransform>().anchoredPosition = main.ally.GetComponent<RectTransform>().anchoredPosition + InitialManualVector;
            DoesSkill();
        }
    }

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            DoesSkill();
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Fire")
                {
                    skill.GetProExp(1);
                }
                else
                {
                    skill.GetProExp(0.1);

                }
            }
        }
    }

}
