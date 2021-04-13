using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class MuscleInflation : ANGEL_SKILL
{

    public override double Damage()//ここではUP量！
    {
        if(P_level>=200)
            return (20 + Math.Pow(BuffedLevel(), 1.55) )*2 * (1 + main.skillprogress.buffFactor);
        else
            return (20 + Math.Pow(BuffedLevel(), 1.55)) * (1 + main.skillprogress.buffFactor);
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
        DpsText.text = "<color=#00C8FF>ATK : + " + tDigit(Damage(), 2);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 24;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Enhance", 1f, 0, 0, 1000000, DamageKind.nothing);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[24];
            SkillLocal.muscle(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);


            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "物理攻撃効果を追加") +
                            "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "ATK + 100%") + "\n" + Color(150, "ATK + 200%") + "\n" + Color(200, "マッスルインフレーション効果2倍");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "使用该技能的时候会造成物理伤害") +
                            "\n" + Color(50, "物理攻击 + 50%") + "\n" + Color(100, "物理攻击 + 100%") + "\n" + Color(150, "物理攻击 + 200%") + "\n" + Color(200, "肌肉强化效果 * 2");
                        break;
                    default:
                        requiredSkillString = Color(30, "Physical attack when Muscle Inflation is triggered") +
                            "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "ATK + 100%") + "\n" + Color(150, "ATK + 200%") + "\n" + Color(200, "Muscle Inflation Effect * 2");
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
                        requiredSkillString = "<color=red>- ゴッドブレス < Lv 24 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 上帝的保佑 < Lv 24 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- God Bless < Lv 24 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[24];
            SkillLocal.muscle(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            
        }

        //MP
        mpFactor = BuffedLevel() * 4.5;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0;
        }
        else
        {
            pas1 = 0;
        }
        if (P_level >= 50)
        {
            pas2 = 0.50;
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
            pas4 = 1;
        }
        else
            pas4 = 3;



        //スキル開放条件
        if (main.angelSkillAry[3].P_level >= 24)
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
            if (!updateDuration(Main.Buff.muscleInflation))
                Instantiate(main.StatusIcons[2], main.StatusIconCanvas);

            if (P_level < 30)
            {
                StartCoroutine(main.InstantiateSubAnimation(main.animationObject[31], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            }
            else if (P_level >= 30)
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[46], main.ally1.GetComponent<RectTransform>(), Damage() * P_level, ConsumeMp(), DamageKind.physical));
            }
            GetProf();
            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.muscleInflation)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[2], main.StatusIconCanvas);

        if (P_level < 30)
        {
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[31], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        }
        else if (P_level >= 30)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[46], main.ally1.GetComponent<RectTransform>(), Damage() * P_level, ConsumeMp(), DamageKind.physical));
        }
        GetProf();
    }
    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualBuff());
    }



}
