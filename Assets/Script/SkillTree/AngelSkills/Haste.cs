using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Haste : ANGEL_SKILL
{
    public override double Damage()//ここではUP量！
    {
        return (30 + BuffedLevel() * 3.5 )* (1 + main.skillprogress.buffFactor);
    }

    public override float AttackInterval()
    {
        return 30f;
    }

    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.25, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.65, P_level);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffffff>SPD : + " + tDigit(Damage(), 2) + "%";
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 27;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Enhance", 1f, 0, 0, 300000000000000000, DamageKind.nothing);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[27];
            SkillLocal.haste(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "SPD + 50%") + "\n" + Color(50, "SPD + 100%") + "\n" + Color(100, "SPD + 200%") + "\n" + Color(150, "SPD + 500%") + "\n" + Color(200, "SPD + 1000%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "速度 + 50%") + "\n" + Color(50, "速度 + 100%") + "\n" + Color(100, "速度 + 200%") + "\n" + Color(150, "速度 + 500%") + "\n" + Color(200, "速度 + 1000%");
                        break;
                    default:
                        requiredSkillString = Color(30, "SPD + 50%") + "\n" + Color(50, "SPD + 100%") + "\n" + Color(100, "SPD + 200%") + "\n" + Color(150, "SPD + 500%") + "\n" + Color(200, "SPD + 1000%");
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
                        requiredSkillString = "<color=red>- マッスルインフレーション < Lv 60 >\n- マジックインパクト < Lv 60 >\n- プロテクトウォール < Lv 30 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 肌肉强化 < Lv 60 >\n- 魔法强化 < Lv 60 >\n- 防御墙 < Lv 30 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Muscle Inflation < Lv 60 >\n- Magic Impact < Lv 60 >\n- Protect Wall < Lv 30 ></color>";
                        break;
                }
            }


        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[27];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.haste(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 6.5;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.5;
        }
        else
        {
            pas1 = 0;
        }
        if (P_level >= 50)
        {
            pas2 = 1;
        }
        else
        {
            pas2 = 0;
        }
        if (P_level < 100)
        {
            pas4 = 0;
        }
        else if (P_level < 150)
        {
            pas4 = 2;
        }
        else if (P_level < 200)
        {
            pas4 = 7;
        }
        else
            pas4 = 17;


        //スキル開放条件
        if (main.angelSkillAry[4].P_level >= 60 && main.angelSkillAry[5].P_level >= 60 && main.angelSkillAry[6].P_level >= 30)
        {
            canGetExp = true;
        }
    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.angelSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Ambition")
                {
                    skill.GetProExp(30);
                }
                else if (skill.skillLineage == "Enhance")
                {
                    skill.GetProExp(30);
                }
                else
                {
                    skill.GetProExp(3);
                }
            }
        }
    }

    public override IEnumerator Attacking()
    {
        //ENEMY targetEnemy;
        while (true)
        {

            yield return new WaitUntil(CanBuff);
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[34], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (!updateDuration(Main.Buff.spd))
                Instantiate(main.StatusIcons[5], main.StatusIconCanvas);
            GetProf();
            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[34], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.spd)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[5], main.StatusIconCanvas);
        GetProf();
    }

    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualBuff());
    }


}
