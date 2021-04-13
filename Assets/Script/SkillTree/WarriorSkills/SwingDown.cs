using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class SwingDown : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (200.0 + BuffedLevel() * 5) * 3;
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(2.975 - ((BuffedLevel() - 1) * 0.025)), 1.0f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 300 * Math.Pow(1.2, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }



    private void Awake()
    {
        StartBASE();
        skillIndex = 4;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 100f, "Sword", 1f, 50000);
        thisAnimationObject = main.animationObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[4];
            SkillLocal.swingdown(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[4];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.swingdown(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //MP
        mpFactor = BuffedLevel() * 5;

        //PassiveEffect

        if (P_level >= 30)
        {
            pas9 = 0.20;
        }
        else
        {
            pas9 = 0;
        }
        if (P_level >= 50 && P_level < 100)
        {
            pas10 = 0.50;
        }
        else if (P_level >= 100 && P_level < 200)
        {
            pas10 = 1.5;
        }
        else if (P_level >= 200)
        {
            pas10 = 3.5;
        }
        else
            pas10 = 0;

        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ATK + 20%") + "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "ATK + 100%") + "\n" + Color(150, "10%の確率でターゲットの攻撃力を低下させる") + "\n" + Color(200, "ATK + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 20%") + "\n" + Color(50, "物理攻击 + 50%") + "\n" + Color(100, "物理攻击 + 100%") + "\n" + Color(150, "10%给予敌人减物理攻击减益状态") + "\n" + Color(200, "物理攻击 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 20%") + "\n" + Color(50, "ATK + 50%") + "\n" + Color(100, "ATK + 100%") + "\n" + Color(150, "ATK Down onto the target with 10% chance") + "\n" + Color(200, "ATK + 200%");
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
                        requiredSkillString = "<color=red>- ダブルスラッシュ < Lv 18 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 二连击 < Lv 18 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Double Slash < Lv 18 ></color>";
                        break;
                }
            }
        }
        //スキル開放条件
        if (main.warriorSkillAry[2].P_level >= 18)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[5].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[5].skillCanvas);
        }




    }
    int rand;
    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if (P_level < 150) 
                StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            else
            {
                rand = UnityEngine.Random.Range(0, 10000);
                if (rand<=1000)
                    StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind, Main.Debuff.atkDown));
                else
                    StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            }
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10)
                GetProf();
            yield return new WaitForSeconds(AttackInterval());
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
