using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Blizzard : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (100.0 + BuffedLevel() + Math.Pow(1.045, BuffedLevel())) ;
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        if (main.skillprogress.isWizNoMp)
            return BaseAttackInterval() * Mathf.Max((float)(12 - BuffedLevel() * 0.15), 5f) * 0.5f;
        else
            return BaseAttackInterval() * Mathf.Max((float)(12 - BuffedLevel() * 0.15), 5f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.25, P_level);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.55, P_level);
    }
    public double probability()
    {
        if(P_level<200)
            return Math.Min(1000 + P_level * 5, 5000);
        else
            return Math.Min((1000 + P_level * 5)*2, 5000);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 16;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 1000f, "Ice", 1f,0, 10000000000000000000d, 0,DamageKind.magical);

        //MP
        mpFactor = P_level * 15.5 + Math.Pow(P_level, 1.75);

    }

    public float attackRadius()
    {
        if (P_level < 10)
        {
            return 90;
        }
        else if (P_level >= 10 && P_level < 20)
        {
            return 120;
        }
        else if (P_level >= 20 && P_level < 30)
        {
            return 150;
        }
        else if (P_level >= 30 && P_level < 50)
        {
            return 180;
        }
        else if (P_level >= 50)
        {
            return 240;
        }
        else
        {
            return 90;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[16];
            SkillLocal.blizzard(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(25, "有効攻撃範囲 : + 30") +
                            "\n" + Color(50, "有効攻撃範囲 : + 30") + "\n" + Color(75, "有効攻撃範囲 : + 30") + "\n" + Color(100, "有効攻撃範囲 : + 60") + "\n" + Color(200, "コールド確率 * 2");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(25, "技能伤害范围 : + 30") +
                            "\n" + Color(50, "技能伤害范围 : + 30") + "\n" + Color(75, "技能伤害范围 : + 30") + "\n" + Color(100, "技能伤害范围 : + 60") + "\n" + Color(200, "冰冻概率 * 2");
                        break;
                    default:
                        requiredSkillString = Color(25, "Attack Radius : + 30") +
                            "\n" + Color(50, "Attack Radius : + 30") + "\n" + Color(75, "Attack Radius : + 30") + "\n" + Color(100, "Attack Radius : + 60") + "\n" + Color(200, "Cold Chance * 2");
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
                        requiredSkillString = "<color=red>- チリングタッチ < Lv 60> </color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 极寒之触 < Lv 60> </color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Chilling Touch < Lv 60> </color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[16];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.blizzard(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        //MP
        mpFactor = P_level * 15.5 + Math.Pow(BuffedLevel(), 1.75);


        //スキル開放条件
        if (main.wizardSkillAry[5].P_level >= 60)
        {
            canGetExp = true;
        }
    }

    public void DoesSkill(RectTransform rect)
    {
        if (P_level < 25)
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[12], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[12], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
        else if (P_level >= 25 && P_level < 50)
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[26], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[26], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
        else if (P_level >= 50 && P_level < 75)
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[27], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[27], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
        else if (P_level >= 75 && P_level < 100)
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[28], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[28], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
        else if (P_level >= 100)
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[29], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[29], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Ice")
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

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if(searchEnemy() != null)
            DoesSkill(searchEnemy().GetComponent<RectTransform>());
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

}
