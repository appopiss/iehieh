using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class LightningThunder : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return (main.ally.MAtk() * (3.0 + BuffedLevel() * 0.15 + Math.Pow(1.0425, BuffedLevel())) * ( 1 + BuffedLevel() / 5d ));
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        if (main.skillprogress.isWizNoMp)
            return BaseAttackInterval() * Mathf.Max((float)(10 - BuffedLevel() * 0.115), 5f) * 0.5f;
        else
            return BaseAttackInterval() * Mathf.Max((float)(10 - BuffedLevel() * 0.115), 5f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.25, P_level);
    }
    //必要コストの計算
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.65, P_level);
    }

    public int attackNum() {
        if (P_level >= 100)
        {
            return (10 + Math.Min((int)(P_level / 2), 40)) * 4;
        }
        else
        {
            return 10 + Math.Min((int)(P_level / 2), 40) * 2;
        }


        //if (P_level >= 100)
        //{
        //    return (10 + Math.Min((int)(P_level / 2), 40)) * 2;
        //}
        //else
        //{
        //    return 10 + Math.Min((int)(P_level / 2),40);
        //}
    }

    public double probability()
    {
        return Math.Min(2500 + P_level * 50, 5000);
    }

    private void Awake()
    {
        StartBASE();
        skillIndex = 19;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Thunder", 1f,0, 300000000000000000000d, 0,DamageKind.magical);

        //MP
        mpFactor = P_level * 15.5 + Math.Pow(P_level, 1.85);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[19];
            SkillLocal.LightningTHunder(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "SPD + 100%") + "\n" + Color(50, "MATK + 100%") + "\n" + Color(100, "攻撃回数 * 2") + "\n" + Color(150, "MATK + 200%, SPD + 300%") + "\n" + Color(200, "MATK + 500%, SPD + 500%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "速度 + 100%") + "\n" + Color(50, "魔法攻击 + 100%") + "\n" + Color(100, "攻击次数 * 2") + "\n" + Color(150, "魔法攻击 + 200%, 速度 + 300%") + "\n" + Color(200, "魔法攻击 + 500%, 速度 + 500%");
                        break;
                    default:
                        requiredSkillString = Color(30, "SPD + 100%") + "\n" + Color(50, "MATK + 100%") + "\n" + Color(100, "Hit counts * 2") + "\n" + Color(150, "MATK + 200%, SPD + 300%") + "\n" + Color(200, "MATK + 500%, SPD + 500%");
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
                        requiredSkillString = "<color=red>- ダブルサンダーボール < Lv 42> </color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 双雷球术 < Lv 42> </color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Double Thunder Ball < Lv 42> </color>";
                        break;
                }
            }

        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[19];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.LightningTHunder(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }
        //MP
        mpFactor = BuffedLevel() * 15.5 + Math.Pow(BuffedLevel(), 1.85);



        //PassiveEffect
        if (P_level < 30)
        {
            pas1 = 0;
        }
        else if (P_level < 150)
        {
            pas1 = 1;
        }
        else if (P_level<200)
        {
            pas1 = 4;
        }
        else
        {
            pas1 = 9;
        }

        if (P_level < 50)
        {
            pas3 = 0;
        }
        else if (P_level < 150)
        {
            pas3 = 1;
        }
        else if (P_level < 200)
        {
            pas3 = 3;
        }
        else
        {
            pas3 = 8;
        }


        //スキル開放条件
        if (main.wizardSkillAry[8].P_level >= 42)
        {
            canGetExp = true;
        }

    }

    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffe400>";
        if (P_level < 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * " + attackNum();
        }
        else if (P_level >= 100)
        {
            DpsText.text += "DPS : " + tDigit(Damage() / AttackInterval(), 2) + " * " + attackNum();
        }

    }


    Vector2 targetPosition;
    public override IEnumerator Attacking()
    {
        ENEMY targetEnemy;
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            targetEnemy = searchEnemy();
            if (targetEnemy != null)
            {
                targetPosition = targetEnemy.GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
                targetPosition = new Vector2(0, 0);
            }
            main.ally.currentMp -= ConsumeMp();
            for (int i = 0; i < attackNum()/5d; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CallThunder(targetPosition);
                }
                yield return new WaitForSeconds(0.01666f);
            }
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

    void CallThunder(Vector2 targetPosition)
    {
        GameObject game;
        game = Instantiate(main.animationObject[14], main.Transforms[1]);
        game.GetComponent<Attack>().mDamage = Damage();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
        if (UnityEngine.Random.Range(0, 10000) < probability())
        {
            game.GetComponent<Attack>().thisDebuff = Main.Debuff.electricalShock;
        }
        else
        {
            game.GetComponent<Attack>().thisDebuff = Main.Debuff.nothing;
        }
        game.GetComponent<RectTransform>().anchoredPosition = targetPosition + new Vector2(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160));

    }

    public IEnumerator ManualAttack()
    {
        if (searchEnemy() != null)
        {
            targetPosition = searchEnemy().GetComponent<RectTransform>().anchoredPosition;
        }
        else
        {
            targetPosition = new Vector2(0, 0);
        }
        main.ally.currentMp -= ConsumeMp();
        for (int i = 0; i < attackNum() / 5d; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                CallThunder(targetPosition);
            }
            yield return new WaitForSeconds(0.01666f);
        }
        GetProf();
    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Thunder")
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
    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualAttack());
    }

}
