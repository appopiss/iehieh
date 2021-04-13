using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class GodBless : ANGEL_SKILL
{
    public override double Damage()//ここではUP量！
    {
        return (20 + BuffedLevel() * 0.45)*(1+main.skillprogress.buffFactor);
    }

    public override float AttackInterval()
    {
        return 30f;
    }

    public override double P_requiredExp()
    {
        return 100 * Math.Pow(1.14, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.35, P_level);
    }
    public override double DebuffResistance()
    {
        return Math.Min(100 + BuffedLevel() * 15,5000);
    }
    public override double RegenePoint()
    {
        return Math.Min(0.01 + BuffedLevel() * 0.00025, 0.05);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#32ff32>HP : + " + tDigit(Damage(), 2) + "%";
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 23;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Enhance", 1f, 0, 0, 3000, DamageKind.nothing);

        stanceButton.onClick.AddListener(() => InstantiateStance(7, main.SR.P_GodBless));
        if (main.SR.P_GodBless)
            Instantiate(main.StanceIcons[7], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[23];
            SkillLocal.godbless(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "リジェネ効果を追加") + "\n" + Color(40, "リザレクションスタンスが利用可能になる") + "\n" + Color(50, "HP + 50%, MP + 50%") + "\n" + Color(100, "HP + 100%, SPD + 50%") + "\n" + Color(150, "HP + 200%, MP + 100%") + "\n" + Color(200, "HP + 300%, SPD + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "激活技能时可以逐渐回复血量") + "\n" + Color(40, "可激活复苏模式") + "\n" + Color(50, "血量 + 50%, 蓝量 + 50%") + "\n" + Color(100, "血量 + 100%, 速度 + 50%") + "\n" + Color(150, "血量 + 200%, 蓝量 + 100%") + "\n" + Color(200, "血量 + 300%, 速度 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(30, "Regenerate while God Bless is active") + "\n" + Color(40, "Resurrection Stance is available") + "\n" + Color(50, "HP + 50%, MP + 50%") + "\n" + Color(100, "HP + 100%, SPD + 50%") + "\n" + Color(150, "HP + 200%, MP + 100%") + "\n" + Color(200, "HP + 300%, SPD + 100%");
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
                        requiredSkillString = "<color=red>- ウィングアタック < Lv 18 >\n- ウィングシュート < Lv 18 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 翅膀攻击 < Lv 18 >\n- 风刃 < Lv 18 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Wing Attack < Lv 18 >\n- Wing Shoot < Lv 18 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[23];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.godbless(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 1.5;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0;
        }
        else
        {
            pas1 = 0;
        }

        if (P_level < 50)
        {
            pas2 = 0;
            pas3 = 0;
        }
        else if (P_level<150)
        {
            pas2 = 0.5;
            pas3 = 0.5;
        }
        else
        {
            pas2 = 2.5;
            pas3 = 1.5;
        }

        if (P_level < 100)
        {
            pas4 = 0;
            pas5 = 0;
        }
        else if (P_level < 200)
        {
            pas4 = 1;
            pas5 = 0.5;
        }
        else
        {
            pas4 = 4;
            pas5 = 1.5;
        }



        //スキル開放条件
        if (main.angelSkillAry[0].P_level >= 18 && main.angelSkillAry[1].P_level >= 18)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.angelSkillAry[4].skillCanvas);
            setActive(main.angelSkillAry[5].skillCanvas);
            setActive(main.angelSkillAry[6].skillCanvas);
        }
        else
        {
            setFalse(main.angelSkillAry[4].skillCanvas);
            setFalse(main.angelSkillAry[5].skillCanvas);
            setFalse(main.angelSkillAry[6].skillCanvas);
        }
        //Passive
        if (P_level >= 40)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_GodBless)
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
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[30], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (!updateDuration(Main.Buff.maxHp))
            {
                Instantiate(main.StatusIcons[1], main.StatusIconCanvas);
            }
            yield return new WaitForSeconds(0.02f);
            GetProf();
            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[30], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.maxHp)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[1], main.StatusIconCanvas);

        yield return new WaitForSeconds(0.02f);
        if (P_level >= 30)
        {
            main.ally1.GetComponent<ALLY>().currentHp += main.ally1.GetComponent<ALLY>().HP();
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
