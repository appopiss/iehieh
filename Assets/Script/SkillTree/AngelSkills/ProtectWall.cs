using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ProtectWall : ANGEL_SKILL
{ 
    public override double Damage()//ここではUP量！
    {
        if (P_level >= 200)
            return (5 + Math.Pow(BuffedLevel(), 1.2)) * (1 + main.skillprogress.buffFactor);
        else
            return (5 + Math.Pow(BuffedLevel(), 1.2)) * (1 + main.skillprogress.buffFactor) / 2;

    }

    public override float AttackInterval()
    {
        return 30f;
    }

    public override double P_requiredExp()
    {
        return 300 * Math.Pow(1.2, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.55, P_level);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffffff>DEF : + " + tDigit(Damage(), 2);
    }



    private void Awake()
    {
        StartBASE();
        skillIndex = 26;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Enhance", 1f, 0, 0, 3000000000000, DamageKind.nothing);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[26];
            SkillLocal.protect(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "DEF + 50%, MDEF + 50%") +
                            "\n" + Color(50, "DEF + 100%, MDEF + 100%") + "\n" + Color(100, "DEF + 200%, MDEF + 200%") + "\n" + Color(150, "DEF + 300%, MDEF + 300%") + "\n" + Color(200, "プロテクトウォール効果2倍"); ;
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理防御 + 50%, 魔法防御 + 50%") +
                            "\n" + Color(50, "物理防御 + 100%, 魔法防御 + 100%") + "\n" + Color(100, "物理防御 + 200%, 魔法防御 + 200%") + "\n" + Color(150, "物理防御 + 300%, 魔法防御 + 300%") + "\n" + Color(200, "防御墙的效果 * 2"); ;
                        break;
                    default:
                        requiredSkillString = Color(30, "DEF + 50%, MDEF + 50%") +
                            "\n" + Color(50, "DEF + 100%, MDEF + 100%") + "\n" + Color(100, "DEF + 200%, MDEF + 200%") + "\n" + Color(150, "DEF + 300%, MDEF + 300%") + "\n" + Color(200, "Protect Wall Effect * 2"); ;
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
                        requiredSkillString = "<color=red>- マッスルインフレーション < Lv 36 >\n- マジックインパクト < Lv 36 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 肌肉强化 < Lv 36 >\n- 魔法强化 < Lv 36 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Muscle Inflation < Lv 36 >\n- Magic Impact < Lv 36 ></color>";
                        break;
                }
            }


        }
        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[26];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.protect(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }


        //MP
        mpFactor = BuffedLevel() * 4.5;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.5;
            pas2 = 0.5;
        }
        else
        {
            pas1 = 0;
            pas2 = 0;
        }
        if (P_level >= 50)
        {
            pas3 = 1;
            pas4 = 1;
        }
        else
        {
            pas3 = 0;
            pas4 = 0;
        }
        if (P_level < 100)
        {
            pas5 = 0;
            pas6 = 0;
        }
        else if (P_level < 150)
        {
            pas5 = 2;
            pas6 = 2;
        }
        else
        {
            pas5 = 5;
            pas6 = 5;
        }


        //スキル開放条件
        if (main.angelSkillAry[4].P_level >= 36 && main.angelSkillAry[5].P_level >= 36)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            main.angelSkillAry[7].skillCanvas.SetActive(true);
        }
        else
        {
            main.angelSkillAry[7].skillCanvas.SetActive(false);
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
                if (skill.skillLineage == "Enhance")
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
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[33], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (!updateDuration(Main.Buff.def))
                Instantiate(main.StatusIcons[4], main.StatusIconCanvas);
            GetProf();


            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[33], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.def)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[4], main.StatusIconCanvas);
        GetProf();
    }
    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualBuff());
    }
}
