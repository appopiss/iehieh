using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class FanSwing : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return Math.Min(1e305d, main.ally.Atk() * (1600.0 + BuffedLevel() * 25 + Math.Pow(1.055, BuffedLevel())));
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(4.975 - ((BuffedLevel() - 1) * 0.025)), 0.25f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 1000 * Math.Pow(1.25, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 7;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Sword", 1f, 300000000000000000000d);
    }

    public int temp()
    {
        if (P_level < 50)
        {
            return 1;
        }
        else if (P_level >= 50 && P_level < 100)
        {
            return 2;
        }
        else if (P_level >=100)
        {
            return 4;
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
            windowSkillIcon.sprite = main.Sprites[7];
            SkillLocal.fanswing(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ATK + 100%") + "\n" + Color(50, "攻撃回数 + 1") + "\n" + Color(100, "攻撃回数 + 2") + "\n" + Color(150, "ATK + 500%") + "\n" + Color(200, "ファンスイング消費MP * 3/4");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 100%") + "\n" + Color(50, "攻击次数 + 1") + "\n" + Color(100, "攻击次数 + 2") + "\n" + Color(150, "物理攻击 + 500%") + "\n" + Color(200, "剑刃风暴耗蓝 * 3/4");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 100%") + "\n" + Color(50, "Hit counts + 1") + "\n" + Color(100, "Hit counts + 2") + "\n" + Color(150, "ATK + 500%") + "\n" + Color(200, "Fan Swing Lost MP * 3/4");
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
                        requiredSkillString = "<color=red>- ソニックスラッシュ < Lv 90 >\n- チャージスイング < Lv 24 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 音速斩击 < Lv 90 >\n- 会心重击 < Lv 24 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Sonic Slash < Lv 90 >\n- Charge Swing < Lv 24 ></color>";
                        break;
                }
            }

        }


        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[7];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.fanswing(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        //MP
        if(BuffedLevel() < 200)
            mpFactor = BuffedLevel() * 9.5;
        else
            mpFactor = BuffedLevel() * 9.5d*0.75d;
        //PassiveEffect
        if (P_level < 30)
        {
            pas1 = 0;
        }
        else if (P_level<150)
        {
            pas1 = 1;
        }
        else
        {
            pas1 = 6;
        }



        //スキル開放条件
        if (main.warriorSkillAry[3].P_level >= 90 && main.warriorSkillAry[6].P_level >= 24)
        {
            canGetExp = true;
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

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#00C8FF>";
        if (P_level < 50)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2);
        }
        else if (P_level >= 50 && P_level < 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 2";
        }
        else if (P_level >= 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * 4";
        }

    }


    public void DoesSkill()
    {
        if (P_level < 50)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[24], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
        }
        else if (P_level >= 50 && P_level < 100)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[24], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[38], main.ally1.GetComponent<RectTransform>(), Damage(), 0, damageKind));
        }
        else if (P_level >= 100)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[24], main.ally1.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[38], main.ally1.GetComponent<RectTransform>(), Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[39], main.ally1.GetComponent<RectTransform>(), Damage(), 0, damageKind));
            StartCoroutine(main.InstantiateAnimation(main.animationObject[40], main.ally1.GetComponent<RectTransform>(), Damage(), 0, damageKind));
        }
    }

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            DoesSkill();
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
            DoesSkill();
            GetProf();
        }
        else
        {
            GameObject EmptyObject = Instantiate(main.EmptyObject, main.Transforms[1]);
            EmptyObject.GetComponent<RectTransform>().anchoredPosition = main.ally.GetComponent<RectTransform>().anchoredPosition + InitialManualVector;
            DoesSkill();
        }
    }


}
