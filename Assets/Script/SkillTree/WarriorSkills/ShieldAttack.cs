using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ShieldAttack : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (0.5 + BuffedLevel() * 0.05);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(2 - ((BuffedLevel() - 1) * 0.015)), 0.3f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.13, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.35, P_level);
    }
    

    private void Awake()
    {
        StartBASE();
        skillIndex = 8;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Shield", 1f, 50);
        thisAnimationObject = main.animationObject[0];
        stanceButton.onClick.AddListener(() => InstantiateStance(1, main.SR.P_ShieldAttack));
        if (main.SR.P_ShieldAttack)
            Instantiate(main.StanceIcons[1], main.StanceIconCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[8];
            SkillLocal.sheildAttack(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(10, "HP + 10%, MP + 5%, DEF + 5%") + "\n" + Color(25, "HP + 20% , DEF + 10%, MDEF + 10%") + "\n" + Color(50, "HP + 50%, DEF + 10%, MDEF + 10%") + "\n" + Color(75, "シールドスタンスが利用可能になる") + "\n" + Color(100, "シールドアタックの獲得MP + 100%") + "\n" + Color(200, "HP + 300%, DEF + 200%, MDEF + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(10, "血量 + 10%, 蓝量 + 5%, 物理防御 + 5%") + "\n" + Color(25, "血量 + 20% , 物理防御 + 10%, 魔法防御 + 10%") + "\n" + Color(50, "血量 + 50%, 物理防御 + 10%, 魔法防御 + 10%") + "\n" + Color(75, "可激活举盾模式") + "\n" + Color(100, "盾击吸蓝 + 100%") + "\n" + Color(200, "血量 + 300%, 物理防御 + 200%, 魔法防御 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(10, "HP + 10%, MP + 5%, DEF + 5%") + "\n" + Color(25, "HP + 20% , DEF + 10%, MDEF + 10%") + "\n" + Color(50, "HP + 50%, DEF + 10%, MDEF + 10%") + "\n" + Color(75, "Shield Stance is available") + "\n" + Color(100, "Shield Attack MP Gain + 100%") + "\n" + Color(200, "HP + 300%, DEF + 200%, MDEF + 200%");
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
                        requiredSkillString = "<color=red>- ソードアタック < Lv 6 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 剑击 < Lv 6 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Sword Attack < Lv 6 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[8];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.sheildAttack(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        if (BuffedLevel() < 100)
        {
            mpFactor = -BuffedLevel() * 0.8 - Math.Pow(BuffedLevel(), 0.8);
        }
        else
        {
            mpFactor = (-3 - BuffedLevel() * 0.8 - Math.Pow(BuffedLevel(), 0.8))*2 + 3;
        }


        //PassiveEffect
        if (P_level >= 10)
        {
            pas1 = 0.10;
            pas2 = 0.05;
            pas3 = 0.05;
        }
        else
        {
            pas1 = 0;
            pas2 = 0;
            pas3 = 0;
        }
        if (P_level >= 25)
        {
            pas4 = 0.20;
            pas5 = 0.10;
            pas6 = 0.10;
        }
        else
        {
            pas4 = 0;
            pas5 = 0;
            pas6 = 0;
        }
        if (P_level < 50)
        {
            pas7 = 0;
            pas8 = 0;
            pas9 = 0;
        }
        else if (P_level <200)
        {
            pas7 = 0.5;
            pas8 = 0.1;
            pas9 = 0.1;
        }
        else
        {
            pas7 = 3.5;
            pas8 = 2.1;
            pas9 = 2.1;
        }


            //スキル開放条件
            if (main.warriorSkillAry[0].P_level >= 6)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[9].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[9].skillCanvas);
        }
        //Passive
        if (P_level >= 75)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_ShieldAttack)
                stanceButtonText.text = "OFF";
            else
                stanceButtonText.text = "ON";
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10)
                stanceButton.interactable = true;
            else
                stanceButton.interactable = false;
        }
        else
        {
            setFalse(stanceButton.gameObject);
        }
    }
    public Button stanceButton;
    public TextMeshProUGUI stanceButtonText;

    public override void GetProf()
    {
        if (main.SR.P_ShieldAttack)
            main.warriorSkillAry[8].attackNum += 1;
        foreach (SKILL skill in main.warriorSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Shield")
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
