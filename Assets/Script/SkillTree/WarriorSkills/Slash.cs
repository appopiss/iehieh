using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Slash : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (1.0 + BuffedLevel() * 0.35);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(1.0 - ((BuffedLevel() - 1) * 0.01)), 0.6f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.12, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        if (P_level == 0)
        {
            return 1;
        }
        else
        {
            return initialCostStone * Math.Pow(1.35, P_level);
        }
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Sword", 1f, 25);
        thisAnimationObject = main.animationObject[1];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[1];
            SkillLocal.slash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[1];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.slash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * (-0.35);


        //PassiveEffect
        if (P_level >= 30)
        {
            if (P_level >= 200)
                pas7 = 0.85;
            else if (P_level >= 150)
                pas7 = 0.35;
            else
                pas7 = 0.05;
        }
        else
        {
            pas7 = 0;
        }
        if (P_level >= 50)
        {
            pas8 = 0.1;
        }
        else
        {
            pas8 = 0;
        }
        if (P_level >= 100)
        {
            if (P_level >= 200)
                pas9 = 1;
            else if (P_level >= 150)
                pas9 = 0.5;
            else
                pas9 = 0.2;

        }
        else
        {
            pas9 = 0;
        }

        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "SPD + 20%") + "\n" + Color(150, "ATK + 30%, SPD + 30%") + "\n" + Color(200, "ATK + 50%, SPD + 50%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 5%") + "\n" + Color(50, "物理攻击 + 10%") + "\n" + Color(100, "速度 + 20%") + "\n" + Color(150, "物理攻击 + 30%, 速度 + 30%") + "\n" + Color(200, "物理攻击 + 50%, 速度 + 50%");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "SPD + 20%") + "\n" + Color(150, "ATK + 30%, SPD + 30%") + "\n" + Color(200, "ATK + 50%, SPD + 50%");
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
                        requiredSkillString = "<color=red>- ソードアタック < Lv 1 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 剑击 < Lv 1 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Sword Attack < Lv 1 ></color>";
                        break;
                }
            }

        }
        //スキル開放条件
        if (main.warriorSkillAry[0].P_level >= 1)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[2].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[2].skillCanvas);
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

}
