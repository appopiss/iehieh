using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class HoldWings : ANGEL_SKILL
{
    public override double Damage()//ここではUP量！
    {
        return (100 + BuffedLevel()) * (1 + BuffedLevel()) * (1 + main.skillprogress.buffFactor) / 10;
    }

    public override float AttackInterval()
    {
        return 180f;
    }

    public override double P_requiredExp()
    {
        return 1000 * Math.Pow(1.25, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.65, P_level);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffffff>Prof : + " + tDigit(Damage(), 2) + "%";
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 29;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Ambition", 1f, 0, 0, 10000000000000000000, DamageKind.nothing);

        stanceButton.onClick.AddListener(() => InstantiateStance(9, main.SR.P_HoldWing));
        if (main.SR.P_HoldWing)
            Instantiate(main.StanceIcons[9], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[29];
            SkillLocal.holdwing(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        if (window2.activeSelf)
        {
            //window2
            windowSkillIcon.sprite = main.Sprites[29];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.holdwing(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * 20;

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 2.5;
        }
        else
        {
            pas1 = 0;
        }
        if (P_level >= 100)
        {
            pas2 = 5;
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
            pas3 = 10;
        }
        else
            pas3 = 40;


        if (canGetExp)
        {
            requiredAndPassiveString = SkillLocal.PassiveEffect();
            switch (LocalizeInitialize.language)
            {
                case Language.jp:
                    requiredSkillString = Color(30, "全てのスキルの熟練度獲得量 + 250%") + "\n" + Color(50, "ディヴァインスタンスが利用可能になる") + "\n" + Color(100, "全てのスキルの熟練度獲得量 + 500%") + "\n" + Color(150, "全てのスキルの熟練度獲得量 + 1000%") + "\n" + Color(200, "全てのスキルの熟練度獲得量 + 3000%");
                    break;
                case Language.chi:
                    requiredSkillString = Color(30, "所有技能熟练获取 + 250%") + "\n" + Color(50, "可激活神圣模式") + "\n" + Color(100, "所有技能熟练获取 + 500%") + "\n" + Color(150, "所有技能熟练获取 + 1000%") + "\n" + Color(200, "所有技能熟练获取 + 3000%");
                    break;
                default:
                    requiredSkillString = Color(30, "Skill Proficiency + 250% in all skills") + "\n" + Color(50, "Divine Stance is available") + "\n" + Color(100, "Skill Proficiency + 500% in all skills") + "\n" + Color(150, "Skill Proficiency + 1000% in all skills") + "\n" + Color(200, "Skill Proficiency + 3000% in all skills");
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
                    requiredSkillString = "<color=red>- エンジェルディストラクション < Lv 6 ></color>";
                    break;
                case Language.chi:
                    requiredSkillString = "<color=red>- 天使的祝福 < Lv 6 ></color>";
                    break;
                default:
                    requiredSkillString = "<color=red>- Angel Distraction < Lv 6 ></color>";
                    break;
            }
        }

        //スキル開放条件
        if (main.angelSkillAry[8].P_level >= 6)
        {
            canGetExp = true;
        }

        //Passive
        if (P_level >= 50)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_HoldWing)
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
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[48], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (!updateDuration(Main.Buff.prof))
                Instantiate(main.StatusIcons[7], main.StatusIconCanvas);
            GetProf();
            yield return new WaitForSeconds(AttackInterval()-1);
        }
    }

    public IEnumerator ManualBuff()
    {
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[48], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == Main.Buff.prof)
                yield return new WaitUntil(() => child.gameObject == null);
        }
        Instantiate(main.StatusIcons[7], main.StatusIconCanvas);
        GetProf();
    }
    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        StartCoroutine(ManualBuff());
    }

}
