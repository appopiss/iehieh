using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class SonicSlash : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (20.0 + BuffedLevel() * 0.5);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(0.78 - ((BuffedLevel() - 1) * 0.02)), 0.1f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 500 * Math.Pow(1.25, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);

    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Sword", 1f, 100000000d);
    }

    public int temp()
    {
        if (P_level < 10)
        {
            return 3;
        }
        else if (P_level >= 10 && P_level < 50)
        {
            return 4;
        }
        else if (P_level >= 50 && P_level < 100)
        {
            return 5;
        }
        else if (P_level >= 100 && P_level < 150)
        {
            return 6;
        }
        else if (P_level >= 150)
        {
            return 9;
        }
        return 3;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[3];
            SkillLocal.sonicslash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[3];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.sonicslash(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        if(BuffedLevel() >= 200)
            mpFactor = BuffedLevel() * 0.25 * 0.5;
        else
            mpFactor = BuffedLevel() * 0.25;
        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(10, "攻撃回数 + 1") + "\n" + Color(50, "攻撃回数 + 1") + "\n" + Color(100, "攻撃回数 + 1") + "\n" + Color(150, "攻撃回数 + 3") + "\n" + Color(200, "ソニックスラッシュ消費MP * 1/2");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(10, "攻击次数 + 1") + "\n" + Color(50, "攻击次数 + 1") + "\n" + Color(100, "攻击次数 + 1") + "\n" + Color(150, "攻击次数 + 3") + "\n" + Color(200, "耗蓝 * 1/2");
                        break;
                    default:
                        requiredSkillString = Color(10, "Hit counts + 1") + "\n" + Color(50, "Hit counts + 1") + "\n" + Color(100, "Hit counts + 1") + "\n" + Color(150, "Hit counts + 3") + "\n" + Color(200, "Sonic Slash Lost MP * 1/2");
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
                        requiredSkillString = "<color=red>- ダブルスラッシュ < Lv 48 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 二连击 < Lv 48 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Double Slash < Lv 48 ></color>";
                        break;
                }
            }
        }
        //スキル開放条件
        if (main.warriorSkillAry[2].P_level >= 48)
        {
            canGetExp = true;
        }

    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#00C8FF>";
        if (P_level < 10)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 3";
        }
        else if (P_level >= 10 && P_level < 50)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 4";
        }
        else if (P_level >= 50 && P_level < 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 5";
        }
        else if (P_level >= 100 && P_level < 150)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 6";
        }
        else if (P_level >= 150)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 9";
        }
    }


    public void DoesSkill(RectTransform rect)
    {
        if (P_level < 10)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[17], rect, Damage() ,ConsumeMp(), damageKind));
        }
        else if (P_level >= 10 && P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[18], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 50 && P_level < 100)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[20], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 100 && P_level < 150)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[21], rect, Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 150)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[22], rect, Damage(), ConsumeMp(), damageKind));
        }
        else
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[17], rect, Damage(), ConsumeMp(), damageKind));
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

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if (searchEnemy() != null)
                DoesSkill(searchEnemy().GetComponent<RectTransform>());
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }
    public override void GetProf()
    {
        main.sound.PlaySound(main.sound.sonicSlash);
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
