using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class DoubleSlash : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally1.GetComponent<ALLY>().Atk() * (1.0 + BuffedLevel() * 0.50);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        if (BuffedLevel() < 100)
        {
            return BaseAttackInterval() * Mathf.Max((float)(1.0 - ((BuffedLevel() - 1) * 0.015)), 0.1f);
        }
        else
        {
            return BaseAttackInterval() * Mathf.Max((float)(1.0 - ((BuffedLevel() - 1) * 0.015))*0.5f, 0.05f);
        }
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 100 * Math.Pow(1.14, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.35, P_level);
    }

    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Sword", 1f, 300);
        skillIndex = 2;
        thisAnimationObject = main.animationObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[2];
            SkillLocal.doubleslash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[2];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.doubleslash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 0.85;

        //PassiveEffect
        if (P_level >= 30)
        {
            if(P_level >= 150)
            {
                pas1 = 1.05;
                pas2 = 0.55;
            }
            else
            {
                pas1 = 0.05;
                pas2 = 0.05;
            }
        }
        else
        {
            pas1 = 0;
            pas2 = 0;
        }

        if (P_level >= 50)
        {
            pas3 = 0.1;
            if (P_level >= 200)
                pas4 = 1.1;
            else
                pas4 = 0.1;
        }
        else
        {
            pas3 = 0;
            pas4 = 0;
        }

        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MP + 5%, SPD + 5%") + "\n" + Color(50, "ATK + 10%, SPD + 10%") + "\n" + Color(100, "ダブルスラッシュの攻撃間隔 * 1/2") + "\n" + Color(150, "MP + 100%, SPD + 50%") + "\n" + Color(200, "SPD + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "蓝量 + 5%, 速度 + 5%") + "\n" + Color(50, "物理攻击 + 10%, 速度 + 10%") + "\n" + Color(100, "技能冷却 * 1/2") + "\n" + Color(150, "蓝量 + 100%, 速度 + 50%") + "\n" + Color(200, "速度 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MP + 5%, SPD + 5%") + "\n" + Color(50, "ATK + 10%, SPD + 10%") + "\n" + Color(100, "Double Slash Interval * 1/2") + "\n" + Color(150, "MP + 100%, SPD + 50%") + "\n" + Color(200, "SPD + 100%");
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
                        requiredSkillString = "<color=red>- スラッシュ < Lv 12 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 砍击 < Lv 12 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Slash < Lv 12 ></color>";
                        break;
                }
            }
        }
        //スキル開放条件
        if (main.warriorSkillAry[1].P_level >= 12)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[3].skillCanvas);
            setActive(main.warriorSkillAry[4].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[3].skillCanvas);
            setFalse(main.warriorSkillAry[4].skillCanvas);
        }
    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#00C8FF>";
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 2";
    }


    public override void GetProf()
    {
        main.sound.PlaySound(main.sound.doubleSlash);
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
