using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class S_Wizard : WIZARD_SKILL
{

    public override double Damage()
    {
        return main.ally.MAtk() * (1.0 + BuffedLevel() * 0.12);
    }
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(1.5 - (BuffedLevel() * 0.02)), 0.65f);
    }

    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.12, P_level);
    }

    public override double CostCristal()
    {
        //if (main.warriorSkillAry[1].P_level == 0 && main.wizardSkillAry[1].P_level == 0 && main.angelSkillAry[1].P_level == 0)
        //{
        //    return 10000;
        //}
        //else
        //{
            return initialCostCristal * Math.Pow(1.35, P_level);
        //}
    }

    public override IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if (thisAnimationObject == null)
                continue;
            if (searchEnemy() == null)
                continue;
            if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWizardRein].isEquipped)
            {
                AllAttack(main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWizardRein].level);
            }
            else
            {
                StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            }
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10)
                GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 10;
        thisAnimationObject = main.animationObject[0];
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 50f, "Base", 1f, 0, 25, 0, DamageKind.magical);
        thisAnimationObject = main.animationObject[0];

        stanceButton.onClick.AddListener(() => InstantiateStance(3, main.SR.P_StaffAttack));
        if (main.SR.P_StaffAttack)
            Instantiate(main.StanceIcons[3], main.StanceIconCanvas);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[10];
            SkillLocal.swizard(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MATK + 5%") + "\n" + Color(40, "アタックスタンスが利用可能になる") + "\n" + Color(50, "MP + 20%") + "\n" + Color(100, "全てのスキルの熟練度獲得量 + 100%") + "\n" + Color(150, "MATK + 30%") + "\n" + Color(200, "全てのスキルの熟練度獲得量 + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "魔法攻击 + 5%") + "\n" + Color(40, "可切换攻击状态") + "\n" + Color(50, "蓝量 + 20%") + "\n" + Color(100, "所有技能熟练获取 + 100%") + "\n" + Color(150, "魔法攻击 + 30%") + "\n" + Color(200, "所有技能熟练获取 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MATK + 5%") + "\n" + Color(40, "Attack Stance is available") + "\n" + Color(50, "MP + 20%") + "\n" + Color(100, "Skill Proficiency + 100% in all skills") + "\n" + Color(150, "MATK + 30%") + "\n" + Color(200, "Skill Proficiency + 200% in all skills");
                        break;
                }
                setFalse(window2Text5.gameObject);
                setFalse(window2Text6.gameObject);
            }
            else
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "MATK + 5%") + "\n" + Color(40, "アタックスタンスが利用可能になる") + "\n" + Color(50, "MP + 20%") + "\n" + Color(100, "全てのスキルの熟練度獲得量 + 100%") + "\n" + Color(150, "MATK + 30%") + "\n" + Color(200, "全てのスキルの熟練度獲得量 + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "魔法攻击 + 5%") + "\n" + Color(40, "可切换攻击状态") + "\n" + Color(50, "蓝量 + 20%") + "\n" + Color(100, "所有技能熟练获取 + 100%") + "\n" + Color(150, "魔法攻击 + 30%") + "\n" + Color(200, "所有技能熟练获取 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "MATK + 5%") + "\n" + Color(40, "Attack Stance is available") + "\n" + Color(50, "MP + 20%") + "\n" + Color(100, "Skill Proficiency + 100% in all skills") + "\n" + Color(150, "MATK + 30%") + "\n" + Color(200, "Skill Proficiency + 200% in all skills");
                        break;
                }
                setFalse(window2Text5.gameObject);
                setFalse(window2Text6.gameObject);
            }

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[10];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.swizard(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }
        //MP
        mpFactor = BuffedLevel() * (-1.5);

        //PassiveEffect
        if (P_level < 30)
        {
            pas4 = 0;
        }
        else if (P_level<150)
        {
            pas4 = 0.05;
        }
        else
        {
            pas4 = 0.35;
        }

        if (P_level >= 50)
        {
            pas5 = 0.20;
        }
        else
        {
            pas5 = 0;
        }

        if (P_level < 100)
        {
            wizardFactor = 0;
        }
        else if (P_level<200)
        {
            wizardFactor = 1;
        }
        else
        {
            wizardFactor = 3;
        }


        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.wizardSkillAry[1].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[1].skillCanvas);
        }
        if (P_level >= 3)
        {
            setActive(main.wizardSkillAry[4].skillCanvas);
            setActive(main.wizardSkillAry[7].skillCanvas);
        }
        else
        {
            setFalse(main.wizardSkillAry[4].skillCanvas);
            setFalse(main.wizardSkillAry[7].skillCanvas);
        }


        //Passive
        if (P_level >= 40)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_StaffAttack)
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
        if (main.SR.P_StaffAttack)
            attackNum += 1;

        foreach (SKILL skill in main.wizardSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Base")
                {
                    skill.GetProExp(1);
                }
                else
                {
                    skill.GetProExp(0.5);
                }
            }
        }
    }


}
