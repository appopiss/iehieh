using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class SwingAround : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (400.0 + BuffedLevel() * 10);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(3.5 - ((BuffedLevel() - 1) * 0.04)), 1.0f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 500 * Math.Pow(1.2, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 100f, "Sword", 1f, 100000000000);
        if (P_level >= 200)
            attackRange = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[5];
            SkillLocal.swingaround(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ATK + 50%") + "\n" + Color(50, "有効攻撃範囲 * 1.5") + "\n" + Color(100, "10%の確率でターゲットをノックバックする") + "\n" + Color(150, "有効攻撃範囲 * 1.5") + "\n" + Color(200, "攻撃範囲 + 50");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 50%") + "\n" + Color(50, "伤害范围 * 1.5") + "\n" + Color(100, "10%击退概率") + "\n" + Color(150, "伤害范围 * 1.5") + "\n" + Color(200, "攻击距离 + 50");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 50%") + "\n" + Color(50, "Attack Effect Size * 1.5") + "\n" + Color(100, "Knockback Effect with 10% chance") + "\n" + Color(150, "Attack Effect Size * 1.5") + "\n" + Color(200, "Attack Range + 50");
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
                        requiredSkillString = "<color=red>- 振り下ろし < Lv 36 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 重击 < Lv 36 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Swing Down < Lv 36 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[5];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.swingaround(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //MP
        mpFactor = BuffedLevel() * 8.5;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.5;
        }
        else
            pas1 = 0;
        if (P_level >= 200)
            attackRange = 150f;


        //スキル開放条件
        if (main.warriorSkillAry[4].P_level >= 36)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[6].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[6].skillCanvas);
        }
    }

    int rand;

    public void DoesSkill(RectTransform rect)
    {
        if (P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[5], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 50 && P_level < 150)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if(P_level>=100&&rand<=1000)
                StartCoroutine(main.InstantiateAnimation(main.animationObject[36], rect, Damage(), ConsumeMp(), damageKind,Main.Debuff.knockback));
            else
                StartCoroutine(main.InstantiateAnimation(main.animationObject[36], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 150)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand <= 1000)
                StartCoroutine(main.InstantiateAnimation(main.animationObject[37], rect, Damage(), ConsumeMp(), damageKind,Main.Debuff.knockback));
            else
                StartCoroutine(main.InstantiateAnimation(main.animationObject[37], rect, Damage(), ConsumeMp(), damageKind));
        }
        else
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[5], rect, Damage(), ConsumeMp(), damageKind));
        }
    }

    public override void GetProf()
    {

        foreach (SKILL skill in main.warriorSkillAry)
        {
            if (skill.canGetExp)
            {

                if (skill.skillLineage == "Sword")
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
            if(searchEnemy()!=null)
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
