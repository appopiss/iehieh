using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class ThunderBall : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (0.5 + BuffedLevel() * 0.1);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(0.95 - BuffedLevel() * 0.0025), 0.5f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 100 * Math.Pow(1.2, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }
    public override double CostCristal()
    {
        return initialCostCristal * Math.Pow(1.55, P_level);
    }
    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.55, P_level);
    }

    public double probability()
    {
        return Math.Min(500 + BuffedLevel() * 25, 5000);
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 17;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Thunder", 1f,0,1500,0,DamageKind.magical);

        stanceButton.onClick.AddListener(() => InstantiateStance(6, main.SR.P_thunder));
        if (main.SR.P_thunder)
            Instantiate(main.StanceIcons[6], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[17];
            SkillLocal.thunderball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MP + 30%, SPD + 30%") + "\n" + Color(50, "MP + 50%, SPD + 50%") + "\n" + Color(100, "サンダースタンスが利用可能になる") + "\n" + Color(150, "MATK + 100%") + "\n" + Color(200, "MP + 100%, SPD + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "蓝量 + 30%, 速度 + 30%") + "\n" + Color(50, "蓝量 + 50%, 速度 + 50%") + "\n" + Color(100, "可激活闪电模式") + "\n" + Color(150, "魔法攻击 + 100%") + "\n" + Color(200, "蓝量 + 100%, 速度 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MP + 30%, SPD + 30%") + "\n" + Color(50, "MP + 50%, SPD + 50%") + "\n" + Color(100, "Thunder Stance is available") + "\n" + Color(150, "MATK + 100%") + "\n" + Color(200, "MP + 100%, SPD + 200%");
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
                        requiredSkillString = "<color=red>- スタッフアタック < Lv 18 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 法杖攻击 < Lv 18 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Staff Attack < Lv 18 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[17];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.thunderball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //MP
        mpFactor = BuffedLevel() * (-0.9);

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.3;
            pas2 = 0.3;
        }
        else
        {
            pas1 = 0;
            pas2 = 0;
        }
        if (P_level < 50)
        {
            pas4 = 0;
            pas5 = 0;
        }
        else if (P_level<200)
        {
            pas4 = 0.5;
            pas5 = 0.5;

        }
        else
        {
            pas4 = 1.5;
            pas5 = 2.5;

        }

        if (P_level >= 150)
        {
            pas7 = 1;
        }
        else
        {
            pas7 = 0;
        }




        //スキル開放条件
        if (main.wizardSkillAry[0].P_level >= 18)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.wizardSkillAry[8].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[8].skillCanvas);
        }

        //Passive
        if (P_level >= 100)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_thunder)
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
        return Mathf.Min(1 + (float)main.wizardSkillAry[7].P_level / 50f, 5);
    }
    double chance()
    {
        return Math.Min(0.05 + (double)main.wizardSkillAry[7].P_level / 2000d, 0.2);
    }

    int rand;
    public void DoesSkill(RectTransform rect)
    {

        if (main.SR.P_thunder)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand <= chance() * 10000)
                StartCoroutine(InstantiateAnimation(main.animationObject[13], searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind, Main.Debuff.knockback, null, rand));
            else
            {
                if (UnityEngine.Random.Range(0, 10000) < probability())
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.electricalShock));
                }
                else
                {
                    StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind));
                }
            }
        }
        else
        {

            if (UnityEngine.Random.Range(0, 10000) < probability())
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind, Main.Debuff.electricalShock));
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[13], rect, Damage(), ConsumeMp(), damageKind));
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

    public override IEnumerator Attacking()
    {
        ENEMY targetEnemy;
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
