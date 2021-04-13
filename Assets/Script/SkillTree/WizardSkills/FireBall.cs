using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class FireBall : WIZARD_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return main.ally.MAtk() * (5 + BuffedLevel() * 0.55) * (1+(int)BuffedLevel() / 5);
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(2.0 - BuffedLevel() * 0.025), 0.7f);
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.13, P_level);
    }
    //必要コストの計算

    public override double CostCristal()
    {
        if (P_level == 0)
        {
            return 1;
        }
        else
        {
            return initialCostCristal * Math.Pow(1.36, P_level);
        }
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 11;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 150f, "Fire", 1f, 0, 25, 0, DamageKind.magical);
        thisAnimationObject = main.animationObject[9];

        stanceButton.onClick.AddListener(() => InstantiateStance(4, main.SR.P_fire));
        if (main.SR.P_fire)
            Instantiate(main.StanceIcons[4], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[11];
            SkillLocal.fireball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MATK + 10%") + "\n" + Color(50, "MATK + 20%") + "\n" + Color(100, "ファイアスタンスが利用可能になる") + "\n" + Color(150, "MATK + 100%") + "\n" + Color(200, "ファイアボール獲得MP + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "魔法攻击 + 10%") + "\n" + Color(50, "魔法攻击 + 20%") + "\n" + Color(100, "可激活火焰模式") + "\n" + Color(150, "魔法攻击 + 100%") + "\n" + Color(200, "火球术吸蓝 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MATK + 10%") + "\n" + Color(50, "MATK + 20%") + "\n" + Color(100, "Fire Stance is available") + "\n" + Color(150, "MATK + 100%") + "\n" + Color(200, "Fire Ball MP Gain + 100%");
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
                        requiredSkillString = "<color=red>- スタッフアタック < Lv 1 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 法杖攻击 < Lv 1 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Staff Attack < Lv 1 ></color>";
                        break;
                }
            }


        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[11];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.fireball(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }
        //MP
        if(BuffedLevel() < 200)
            mpFactor = BuffedLevel() * (-0.85);
        else
            mpFactor = BuffedLevel() * (-0.85) * 2;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.1;
        }
        else
        {
            pas1 = 0;
        }
        if (P_level >= 50)
        {
            pas2 = 0.20;
        }
        else
        {
            pas2 = 0;
        }

        if (P_level >= 150)
        {
            pas3 = 1.00;
        }
        else
        {
            pas3 = 0.00;
        }


        //スキル開放条件
        if (main.wizardSkillAry[0].P_level >= 1)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            main.wizardSkillAry[2].skillCanvas.SetActive(true);
        }
        else
        {
            main.wizardSkillAry[2].skillCanvas.SetActive(false);
        }

        //Passive
        if (P_level >= 100)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_fire)
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
        return Mathf.Min(1 + (float)main.wizardSkillAry[1].P_level / 50f, 5);
    }
    double chance()
    {
        return Math.Min(0.05 + (double)main.wizardSkillAry[1].P_level / 2000d, 0.2);
    }
    int rand;
    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if (main.SR.P_fire)
            {
                rand = UnityEngine.Random.Range(0, 10000);
                if (rand <= chance() * 10000)
                    StartCoroutine(InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind,Main.Debuff.defDown,null,rand));
                else
                    StartCoroutine(InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            }
            else
                StartCoroutine(InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10)
                GetProf();
            yield return new WaitForSeconds(AttackInterval());
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
                if (skill.skillLineage == "Fire")
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
