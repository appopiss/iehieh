using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class MeteoStrike : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (650.0 + BuffedLevel() * 5 + Math.Pow(1.055, BuffedLevel()));
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        if(main.skillprogress.isWizNoMp)
            return BaseAttackInterval() * Mathf.Max((float)(10 - BuffedLevel() * 0.01), 5f) *0.5f;
        else
            return BaseAttackInterval() * Mathf.Max((float)(10 - BuffedLevel() * 0.01), 5f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.125, P_level);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.65, P_level);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 13;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Fire", 1f, 0, 100000000000, 0,DamageKind.magical);

        //MP
        mpFactor = P_level * 9.15 + Math.Pow(BuffedLevel(), 2);

    }

    public int temp()
    {
        if (P_level < 100)
        {
            return 1;
        }
        else if (P_level >= 100)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[13];
            SkillLocal.meteo(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(10, "MATK + 50%") + "\n" + Color(30, "有効攻撃範囲 + 30") + "\n" + Color(50, "有効攻撃範囲 + 30") + "\n" + Color(100, "攻撃回数 + 1") + "\n" + Color(150, "MATK + 200%") + "\n" + Color(200, "MATK + 300%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(10, "魔法攻击 + 50%") + "\n" + Color(30, "技能伤害范围 + 30") + "\n" + Color(50, "技能伤害范围 + 30") + "\n" + Color(100, "攻击次数 + 1") + "\n" + Color(150, "魔法攻击 + 200%") + "\n" + Color(200, "魔法攻击 + 300%");
                        break;
                    default:
                        requiredSkillString = Color(10, "MATK + 50%") + "\n" + Color(30, "Attack Radius + 30") + "\n" + Color(50, "Attack Radius + 30") + "\n" + Color(100, "Hit counts + 1") + "\n" + Color(150, "MATK + 200%") + "\n" + Color(200, "MATK + 300%");
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
                        requiredSkillString = "<color=red>- ファイアストーム < Lv 60 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 火焰风暴 < Lv 60 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Fire Storm < Lv 60 ></color>";
                        break;
                }
            }


        }


        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[13];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.meteo(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        //MP
        mpFactor = BuffedLevel() * 9.15 + Math.Pow(BuffedLevel(), 2);



        //PassiveEffect
        if (P_level < 10)
        {
            pas1 = 0;
        }
        else if (P_level < 150)
        {
            pas1 = 0.5;
        }
        else if (P_level < 200)
        {
            pas1 = 2.5;
        }
        else
        {
            pas1 = 5.5;
        }


        //スキル開放条件
        if (main.wizardSkillAry[2].P_level >= 60)
        {
            canGetExp = true;
        }


    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        if (P_level < 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2);
        }
        else if (P_level >= 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 2";
        }

    }


    public void DoesSkill(RectTransform rect)
    {
        if (P_level < 30)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[7], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 30 && P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[43], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 50 && P_level < 100)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[44], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 100)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[45], rect, Damage(), ConsumeMp(), damageKind));
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

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            DoesSkill(searchEnemy().GetComponent<RectTransform>());
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        if (searchEnemy() != null)
        {
            DoesSkill(searchEnemy().GetComponent<RectTransform>());
            GetProf();
        }
        else
        {
            GameObject EmptyObject = Instantiate(main.EmptyObject, main.Transforms[1]);
            EmptyObject.GetComponent<RectTransform>().anchoredPosition = main.ally.GetComponent<RectTransform>().anchoredPosition + InitialManualVector;
            DoesSkill(EmptyObject.GetComponent<RectTransform>());
        }
    }

}
