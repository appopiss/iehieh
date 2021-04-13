using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ChargeSwing : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        if(BuffedLevel() < 400)
            return main.ally1.GetComponent<ALLY>().Atk() * (10000.0 + BuffedLevel() * 100 + Math.Pow(1.085, Math.Min(BuffedLevel(), 400)));
        else
            return Math.Min(1e305d, main.ally1.GetComponent<ALLY>().Atk() * (10000.0 + BuffedLevel() * 100 + Math.Pow(1.085, 400) + Math.Pow(1.085, 400 + Math.Max((BuffedLevel() - 400) / 2, 0))));//Math.Max((P_level - 400), 0) * Math.Pow(1.085, 400)
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        if (P_level < 100)
        {
            return BaseAttackInterval() * Mathf.Max((float)(9.95 - ((BuffedLevel() - 1) * 0.05)), 5.0f);
        }
        else
        {
            return BaseAttackInterval() * Mathf.Max((float)((9.95 - (BuffedLevel() - 1) * 0.05)) * 0.5f, 2.5f);
        }

    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.25, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 6;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 100f, "Sword", 1f, 1000000000000000000000d);
        thisAnimationObject = main.animationObject[6];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[6];
            SkillLocal.chargeswings(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MP + 20%, ATK + 30%") + "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "チャージスイング攻撃間隔 * 1/2") + "\n" + Color(150, "MP + 50%, ATK + 100%") + "\n" + Color(200, "MP + 100%, ATK + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "蓝量 + 20%, 物理攻击 + 30%") + "\n" + Color(50, "物理攻击 + 50%") + "\n" + Color(100, "技能冷却 * 1/2") + "\n" + Color(150, "蓝量 + 50%, 物理攻击 + 100%") + "\n" + Color(200, "蓝量 + 100%, 物理攻击 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MP + 20%, ATK + 30%") + "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "Charge Swing Interval * 1/2") + "\n" + Color(150, "MP + 50%, ATK + 100%") + "\n" + Color(200, "MP + 100%, ATK + 200%");
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
                        requiredSkillString = "<color=red>- なぎはらい < Lv 54 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 横扫 < Lv 54 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Swing Around < Lv 54 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[6];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.chargeswings(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 50;

        //PassiveEffect
        if (P_level < 30)
        {
            pas1 = 0;
            pas2 = 0;
        }
        else if (P_level <150)
        {
            pas1 = 0.2;
            pas2 = 0.3;
        }
        else if (P_level < 200)
        {
            pas1 = 0.7;
            pas2 = 1.3;
        }
        else
        {
            pas1 = 1.7;
            pas2 = 3.3;
        }
        if (P_level >= 50)
        {
            pas3 = 0.5;
        }
        else
        {
            pas3 = 0;
        }


        //スキル開放条件
        if (main.warriorSkillAry[5].P_level >= 54)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[7].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[7].skillCanvas);
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
