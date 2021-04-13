using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ChillingTouch : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.Atk() * (1.0 + BuffedLevel() * 0.5);
    }
    public double magDamage()
    {
        return main.ally.MAtk();
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(2 - ((BuffedLevel()- 1) * 0.035)), 1f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 300 * Math.Pow(1.2, P_level);
    }
    //必要コストの計算

    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.5, P_level);
    }


    public double probability()
    {
        return Math.Min(100 + BuffedLevel() * 5, 1500);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 15;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Ice", 1f,0, 1000000000);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[15];
            SkillLocal.chillingtouch(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[15];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.chillingtouch(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * (4.5);

        //PassiveEffect
        if (P_level < 30)
        {
            pas1 = 0;
            pas2 = 0;
        }
        else if (P_level<200)
        {
            pas1 = 0.5;
            pas2 = 0.5;
        }
        else
        {
            pas1 = 2.5;
            pas2 = 2.5;
        }

        if (P_level >= 50)
        {
            pas4 = 0.5;
            pas5 = 0.5;
        }
        else
        {
            pas4 = 0;
            pas5 = 0;
        }

        if (P_level < 150)
        {
            pas7 = 0;
            pas8 = 0;
        }
        else if (P_level<200)
        {
            pas7 = 1;
            pas8 = 1;
        }
        else
        {
            pas7 = 3;
            pas8 = 1;
        }

        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "DEF + 30%, MDEF + 30%") + "\n"
                            + Color(50, "DEF + 50%, MDEF + 50%") + "\n" + Color(100, "10%の確率で有効攻撃範囲5倍") + "\n" + Color(150, "HP + 100%, MATK + 100%") + "\n" + Color(200, "HP + 200%, DEF + 200%, MDEF + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理防御 + 30%, 魔法防御 + 30%") + "\n"
                            + Color(50, "物理防御 + 50%, 魔法防御 + 50%") + "\n" + Color(100, "10%技能伤害范围 * 5") + "\n" + Color(150, "血量 + 100%, 魔法攻击 + 100%") + "\n" + Color(200, "血量 + 200%, 物理防御 + 200%, 魔法防御 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "DEF + 30%, MDEF + 30%") + "\n"
                            + Color(50, "DEF + 50%, MDEF + 50%") + "\n" + Color(100, "Attack Effect Size * 5 with 10% chance") + "\n" + Color(150, "HP + 100%, MATK + 100%") + "\n" + Color(200, "HP + 200%, DEF + 200%, MDEF + 200%");
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
                        requiredSkillString = "<color=red>- アイスボール < Lv 48 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 冰球术 < Lv 48 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Ice Ball < Lv 48 ></color>";
                        break;
                }
            }

        }
        //スキル開放条件
        if (main.wizardSkillAry[4].P_level >= 48)
        {
            canGetExp = true;
        }

        //NEXTSKILL
        if (P_level >= 1)
        {
            main.wizardSkillAry[6].skillCanvas.SetActive(true);
        }
        else
        {
            main.wizardSkillAry[6].skillCanvas.SetActive(false);
        }

    }


    int rand;
    public void DoesSkill(RectTransform rect)
    {
        StartCoroutine(main.InstantiateAnimation(main.animationObject[0], rect, Damage(), ConsumeMp(), damageKind));
        if (P_level >= 100)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand <= 1000)
            {
                if (UnityEngine.Random.Range(0, 10000) < probability())
                {
                    StartCoroutine(InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.freeze,null,rand));
                }
                else
                {
                    StartCoroutine(InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.cold,null,rand));
                }
            }
            else
            {
                if (UnityEngine.Random.Range(0, 10000) < probability())
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.freeze));
                }
                else
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.cold));
                }
            }
        }
        else
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.freeze));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[25], rect, magDamage(), ConsumeMp(), DamageKind.magical, Main.Debuff.cold));
            }
        }
    }

    public IEnumerator InstantiateAnimation(GameObject animatedObj, RectTransform transform, double damage = 0, double consumeMp = 0,
SKILL.DamageKind damageKind = SKILL.DamageKind.physical, Main.Debuff debuff = Main.Debuff.nothing, SKILL skill = null, int rand = 10000)
    {
        GameObject game;
        game = Instantiate(animatedObj, main.Transforms[1]);
        if (rand <= 1000)
        {
            game.GetComponent<RectTransform>().sizeDelta *= 5;
            game.GetComponent<BoxCollider2D>().size *= 5;
        }

        switch (damageKind)
        {
            case SKILL.DamageKind.physical:
                game.GetComponent<Attack>().damage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                break;
            case SKILL.DamageKind.magical:
                game.GetComponent<Attack>().mDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                break;
            default:
                break;
        }
        game.GetComponent<Attack>().thisDebuff = debuff;
        game.GetComponent<RectTransform>().anchoredPosition = transform.anchoredPosition;
        if (consumeMp > 0)
        {
            main.ally.currentMp -= consumeMp;
        }
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
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

    public override void GetProf()
    {
        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Ice")
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

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            DoesSkill(searchEnemy().GetComponent<RectTransform>());
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }


}
