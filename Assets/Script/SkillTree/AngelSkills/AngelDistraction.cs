using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class AngelDistraction : ANGEL_SKILL
{
    public override double Damage()//ここではUP量！
    {
        return (2 + BuffedLevel() * 0.025)*(10+BuffedLevel()*0.1) * (1 + main.skillprogress.buffFactor); 
    }

    public override float AttackInterval()
    {
        return 180f;
    }

    public override double P_requiredExp()
    {
        return 600 * Math.Pow(1.25, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.55, P_level);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffffff>Gold : + " + tDigit(Damage(), 2) + "%";
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 28;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Ambition", 1f, 0, 0, 1000000000000000000, DamageKind.nothing);

        stanceButton.onClick.AddListener(() => InstantiateStance(8, main.SR.P_AngelDistruction));
        if (main.SR.P_AngelDistruction)
            Instantiate(main.StanceIcons[8], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[28];
            SkillLocal.distact(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ゴールド獲得量 + 20%") + "\n" + Color(50, "ゴールド獲得量 + 30%") + "\n" + Color(100, "ラッキースタンスが利用可能になる") + "\n" + Color(150, "ゴールド獲得量 + 50%") + "\n" + Color(200, "ゴールド獲得量 + 100%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "金币获取 + 20%") + "\n" + Color(50, "金币获取 + 30%") + "\n" + Color(100, "可激活幸运模式") + "\n" + Color(150, "金币获取 + 50%") + "\n" + Color(200, "金币获取 + 100%");
                        break;
                    default:
                        requiredSkillString = Color(30, "Gain Gold + 20%") + "\n" + Color(50, "Gain Gold + 30%") + "\n" + Color(100, "Lucky Stance is available") + "\n" + Color(150, "Gain Gold + 50%") + "\n" + Color(200, "Gain Gold + 100%");
                        break;
                }
                window2Text5.gameObject.SetActive(false);
                window2Text6.gameObject.SetActive(false);
            }
            else
            {
                requiredAndPassiveString = SkillLocal.RequiredSkill();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = "<color=red>- ウィングアタック < Lv 54 >\n- ウィングシュート < Lv 54 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 翅膀攻击 < Lv 54 >\n- 风刃 < Lv 54 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Wing Attack < Lv 54 >\n- Wing Shoot < Lv 54 ></color>";
                        break;
                }
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[28];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.distact(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 15;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.2;
        }
        else
        {
            pas1 = 0;
        }
        if (P_level >= 50)
        {
            pas2 = 0.3;
        }
        else
        {
            pas2 = 0;
        }
        if (P_level < 150)
        {
            pas3 = 0;
        }
        else if (P_level < 200)
        {
            pas3 = 0.5;
        }
        else
            pas3 = 1.5;



        //スキル開放条件
        if (main.angelSkillAry[0].P_level >= 54 && main.angelSkillAry[1].P_level >= 54)
        {
            canGetExp = true;
        }
        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.angelSkillAry[9].skillCanvas);
        }
        else
        {
            setFalse(main.angelSkillAry[9].skillCanvas);
        }

        //Passive
        if (P_level >= 100)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_AngelDistruction)
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
                    skill.GetProExp(180);
                }
                else if (skill.skillLineage == "Enhance")
                {
                    skill.GetProExp(180);
                }
                else
                {
                    skill.GetProExp(18);
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
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[35], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (!updateDuration(Main.Buff.gold))
                Instantiate(main.StatusIcons[6], main.StatusIconCanvas);
            GetProf();
            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[35], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.magicImpact)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[6], main.StatusIconCanvas);
        GetProf();
    }

    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualBuff());
    }


}
