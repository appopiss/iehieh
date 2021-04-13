using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class DoubleThunderBall : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (0.5 + BuffedLevel() * 0.1);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(0.8 - BuffedLevel() * 0.0025), 0.1f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 500 * Math.Pow(1.2, P_level);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.55, P_level);
    }
    public double probability()
    {
        return Math.Min(2500 + BuffedLevel() * 50, 5000);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 18;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Thunder", 1f,0, 100000000000000, 0,DamageKind.magical);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[18];
            SkillLocal.doublethunder(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ダブルサンダーボール獲得MP + 50%") + "\n" + Color(50, "ダブルサンダーボール獲得MP + 50%")
                            + "\n" + Color(100, "ダブルサンダーボール獲得MP + 100%") + "\n" + Color(150, "ダブルサンダーボール獲得MP + 100%") + "\n" + Color(200, "ダブルサンダーボール獲得MP + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "双雷球术吸蓝 + 50%") + "\n" + Color(50, "双雷球术吸蓝 + 50%")
                            + "\n" + Color(100, "双雷球术吸蓝 + 100%") + "\n" + Color(150, "双雷球术吸蓝 + 100%") + "\n" + Color(200, "双雷球术吸蓝 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "Double Thunder Ball Gain MP + 50%") + "\n" + Color(50, "Double Thunder Ball Gain MP + 50%")
                            + "\n" + Color(100, "Double Thunder Ball Gain MP + 100%") + "\n" + Color(150, "Double Thunder Ball Gain MP + 100%") + "\n" + Color(200, "Double Thunder Ball Gain MP + 200%");
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
                        requiredSkillString = "<color=red>- サンダーボール < Lv 60 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 雷球术 < Lv 60 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Thunder Ball < Lv 60 ></color>";
                        break;
                }
            }

        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[18];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.doublethunder(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP

        if (BuffedLevel() < 30)
        {
            mpFactor = -BuffedLevel() * 0.2;
        }
        else if (BuffedLevel() >= 30 && BuffedLevel() < 50)
        {
            mpFactor = (-1 - BuffedLevel() * 0.2) * 1.5 + 1;
        }
        else if (BuffedLevel() >= 50 && BuffedLevel() < 100)
        {
            mpFactor = (-1 - BuffedLevel() * 0.2) * 2 + 1;
        }
        else if (BuffedLevel() >= 100 && BuffedLevel() <150)
        {
            mpFactor = (-1 - BuffedLevel() * 0.2) * 3 + 1;
        }
        else if (BuffedLevel() >= 150 && BuffedLevel()<200)
        {
            mpFactor = (-1 - BuffedLevel() * 0.2) * 4 + 1;
        }
        else if (BuffedLevel() >= 200)
        {
            mpFactor = (-1 - BuffedLevel() * 0.2) * 6 + 1;
        }
        else
        {
            mpFactor = -BuffedLevel() * 0.2;
        }
        //PassiveEffect



        //スキル開放条件
        if (main.wizardSkillAry[7].P_level >= 60)
        {
            canGetExp = true;
        }

        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.wizardSkillAry[9].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[9].skillCanvas);
        }

    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 2";

    }


    public void DoesSkill(RectTransform rect)
    {
        if (UnityEngine.Random.Range(0, 10000) < probability())
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.electricalShock));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), 0, damageKind, Main.Debuff.electricalShock));
        }
        else
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), 0, damageKind));
        }
    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Thunder")
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
