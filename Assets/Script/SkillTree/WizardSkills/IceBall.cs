using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;
using static Main.Debuff;

public class IceBall : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (1.0 + BuffedLevel() * 0.25);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(2 - BuffedLevel() * 0.02), 0.7f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.13, P_level);
    }
    //必要コストの計算

    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.45, P_level);
    }

    public double probability()
    {
        return Math.Min(500 + BuffedLevel() * 25, 5000);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 14;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Ice", 1f,0,100,0,DamageKind.magical);
        thisAnimationObject = main.animationObject[11];


        stanceButton.onClick.AddListener(() => InstantiateStance(5, main.SR.P_ice));
        if (main.SR.P_ice)
            Instantiate(main.StanceIcons[5], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[14];
            SkillLocal.iceball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MP + 10%, MATK + 5%, MDEF + 5%") + "\n" + Color(50, "MP + 20%, MATK + 10%, MDEF + 10%") + "\n" + Color(100, "アイススタンスが利用可能になる") + "\n" + Color(150, "MP + 200%") + "\n" + Color(200, "MATK + 100%, MDEF + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "蓝量 + 10%, 魔法攻击 + 5%, 魔法防御 + 5%") + "\n" + Color(50, "蓝量 + 20%, 魔法攻击 + 10%, 魔法防御 + 10%") + "\n" + Color(100, "可激活冰模式") + "\n" + Color(150, "蓝量 + 200%") + "\n" + Color(200, "魔法攻击 + 100%, 魔法防御 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MP + 10%, MATK + 5%, MDEF + 5%") + "\n" + Color(50, "MP + 20%, MATK + 10%, MDEF + 10%") + "\n" + Color(100, "Ice Stance is available") + "\n" + Color(150, "MP + 200%") + "\n" + Color(200, "MATK + 100%, MDEF + 100%");
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
                        requiredSkillString = "<color=red>- スタッフアタック < Lv 9 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 法杖攻击 < Lv 9 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Staff Attack < Lv 9 ></color>";
                        break;
                }
            }

        }
        if (window2.activeSelf)
        {   
            //window2
            windowSkillIcon.sprite = main.Sprites[14];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.iceball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        

        //MP
        mpFactor = BuffedLevel() * (-0.95);

        //PassiveEffect
        if (P_level < 30)
        {
            pas1 = 0;
            pas2 = 0;
            pas3 = 0;
        }
        else if(P_level<150)
        {
            pas1 = 0.1;
            pas2 = 0.05;
            pas3 = 0.05;
        }
        else if (P_level < 200)
        {
            pas1 = 2.1;
            pas2 = 0.05;
            pas3 = 0.05;
        }
        else
        {
            pas1 = 2.1;
            pas2 = 1.05;
            pas3 = 1.05;
        }

        if (P_level >= 50)
        {
            pas4 = 0.2;
            pas5 = 0.1;
            pas6 = 0.1;
        }
        else
        {
            pas4 = 0;
            pas5 = 0;
            pas6 = 0;
        }
        if (P_level >= 100)
        {
            pas7 = 1;
        }
        else
        {
            pas7 = 0;
        }



        //スキル開放条件
        if (main.wizardSkillAry[0].P_level >= 9)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.wizardSkillAry[5].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[5].skillCanvas);
        }

        //Passive
        if (P_level >= 100)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_ice)
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


    float effect()
    {
        return Mathf.Min(1 + (float)main.wizardSkillAry[4].P_level / 50f, 5);
    }
    double chance()
    {
        return Math.Min(0.05 + (double)main.wizardSkillAry[4].P_level / 2000d, 0.2);
    }
    int rand;

    public void DoesSkill(RectTransform rect)
    {
        if (main.SR.P_ice)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand <= chance() * 10000)
                StartCoroutine(InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind, Main.Debuff.mAtkDown, null, rand));
            else
            {
                if (UnityEngine.Random.Range(0, 10000) < probability())
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[11], rect, Damage(), ConsumeMp(), damageKind, cold));
                }
                else
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[11], rect, Damage(), ConsumeMp(), damageKind));
                }
            }
        }
        else
        {
            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[11], rect, Damage(), ConsumeMp(), damageKind, cold));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[11], rect, Damage(), ConsumeMp(), damageKind));
            }
        }
    }

    public IEnumerator InstantiateAnimation(GameObject animatedObj, RectTransform transform, double damage = 0, double consumeMp = 0,
SKILL.DamageKind damageKind = SKILL.DamageKind.physical, Main.Debuff debuff = Main.Debuff.nothing, SKILL skill = null, int rand = 10000)
    {
        GameObject game;
        game = Instantiate(animatedObj, main.Transforms[1]);
        if (rand <= chance() * 10000)
        {
            game.GetComponent<RectTransform>().sizeDelta *= effect();
            game.GetComponent<BoxCollider2D>().size *= effect();
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

}
