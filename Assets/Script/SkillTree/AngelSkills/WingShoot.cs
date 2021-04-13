using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class WingShoot : ANGEL_SKILL
{
    public override double Damage()
    {
        return main.ally.MAtk() * (1 + BuffedLevel() * 0.25 + Math.Pow(1.0125, BuffedLevel()) /10);
    }
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(0.8 - (BuffedLevel() * 0.0125)), 0.1f);
    }

    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.12, P_level);
    }
    public override double CostLeaf()
    {
        if (P_level == 0)
        {
            return 1;
        }
        else
        {
            return initialCostLeaf * Math.Pow(1.35, P_level);
        }
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 21;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 100f, "Wing", 1f, 0, 0, 25, DamageKind.magical);
    }

    public int temp()
    {
        if (P_level < 10)
        {
            return 1;
        }
        else if (P_level >= 10 && P_level < 25)
        {
            return 2;
        }
        else if (P_level >= 25 && P_level < 50)
        {
            return 3;
        }
        else if (P_level >= 50 && P_level < 75)
        {
            return 4;
        }
        else if (P_level >= 75 && P_level < 150)
        {
            return 6;
        }
        else if (P_level >= 150)
        {
            return 7;
        }
        return 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[21];
            SkillLocal.wingshots(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(10, "攻撃回数 + 1") +
                            "\n" + Color(25, "攻撃回数 + 1") + "\n" + Color(50, "攻撃回数 + 1") + "\n" + Color(75, "攻撃回数 + 1") + "\n" + Color(100, "SPD + 50%") + "\n" + Color(150, "攻撃回数 + 2") + "\n" + Color(200, "SPD + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(10, "攻击次数 + 1") +
                            "\n" + Color(25, "攻击次数 + 1") + "\n" + Color(50, "攻击次数 + 1") + "\n" + Color(75, "攻击次数 + 1") + "\n" + Color(100, "速度 + 50%") + "\n" + Color(150, "攻击次数 + 2") + "\n" + Color(200, "速度 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(10, "Hit counts + 1") +
                            "\n" + Color(25, "Hit counts + 1") + "\n" + Color(50, "Hit counts + 1") + "\n" + Color(75, "Hit counts + 1") + "\n" + Color(100, "SPD + 50%") + "\n" + Color(150, "Hit counts + 2") + "\n" + Color(200, "SPD + 100%");
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
                        requiredSkillString = "<color=red>- ウィングアタック < Lv 1 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 翅膀攻击 < Lv 1 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Wing Attack < Lv 1 ></color>";
                        break;
                }
            }

        }


        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[21];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.wingshots(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        //MP
        mpFactor = BuffedLevel() * (-0.05);

        //PassiveEffect
        if (P_level >= 30)
        {
            pas4 = 0;
        }
        else
        {
            pas4 = 0;
        }
        if (P_level >= 50)
        {
            pas5 = 0;
        }
        else
        {
            pas5 = 0;
        }
        if (P_level < 100)
        {
            pas6 = 0;
        }
        else if (P_level < 200)
        {
            pas6 = 0.5;
        }
        else
        {
            pas6 = 1.5;
        }




        //スキル開放条件
        if (main.angelSkillAry[0].P_level >= 1)
        {
            canGetExp = true;
        }

    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        if (P_level < 10)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2);
        }
        else if (P_level >= 10 && P_level < 25)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 2";
        }
        else if (P_level >= 25 && P_level < 50)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 3";
        }
        else if (P_level >= 50 && P_level < 75)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 4";
        }
        else if (P_level >= 75 && P_level < 150)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 5";
        }
        else if (P_level >= 150)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 7";
        }

    }


    public void DoesSkill(RectTransform rect)
    {

        if (P_level < 10)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 10 && P_level < 25)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
        }
        else if (P_level >= 25 && P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
        }
        else if (P_level >= 50 && P_level < 75)                                               
        {                                                                     
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
        }
        else if (P_level >= 75 && P_level < 150)                                               
        {                                                                     
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
        }
        else if (P_level >= 150)                                               
        {                                                                     
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[15], rect, Damage(), 0, damageKind));
        }
    }

    public override void GetProf()
    {

        foreach (SKILL skill in main.angelSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Wing")
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
