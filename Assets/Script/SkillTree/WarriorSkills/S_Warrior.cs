using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class S_Warrior : WARRIOR_SKILL
{

    public override double Damage()
    {
        return main.ally.Atk() * (1.0 + BuffedLevel() * 0.2);
    }
    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(1.1 - (BuffedLevel() * 0.01)), 0.65f) * (1-main.skillprogress.isSordAttackInterval);
    }

    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.12, P_level);
    }
    public override double CostStone()
    {
        //if (main.warriorSkillAry[1].P_level == 0&& main.wizardSkillAry[1].P_level == 0&& main.angelSkillAry[1].P_level == 0)
        //{
        //    return 10000;
        //}
        //else
        //{
            return initialCostStone * Math.Pow(1.35, P_level);
        //}
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 0;
        thisAnimationObject = main.animationObject[0];
    }
    // Start is called before the first frame update
    void Start()    
    {
        StartSkill(1,50f,"Base",1f,25);
        stanceButton.onClick.AddListener(()=>InstantiateStance(0, main.SR.P_SwordAttack));
        if (main.SR.P_SwordAttack)
            Instantiate(main.StanceIcons[0], main.StanceIconCanvas);
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
            if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarriorRein].isEquipped)
            {
                AllAttack(main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarriorRein].level);
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

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[0];
            SkillLocal.S_warrior(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[0];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.S_warrior(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        mpFactor = BuffedLevel() * (-0.25);

        //PassiveEffect
        if (P_level >= 30)
        {
            pas4 = 0.05;
        }
        else
        {
            pas4 = 0;
        }

        if (P_level >= 50)
        {
            if (P_level >= 150)
                pas5 = 0.40;
            else
                pas5 = 0.1;
        }
        else
        {
            pas5 = 0;
        }

        if (P_level >= 100)
        {
            if (P_level >= 200)
            {
                warriorFactor = 3;
            }
            else
            {
                warriorFactor = 1;
            }
        }
        else
        {
            warriorFactor = 0;
        }


        if (window.activeSelf)
        {
            if (P_level > 0)
            {
                LocalizeInitialize.SetFont();

                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(40, "アタックスタンスが利用可能になる") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "全てのスキルに熟練度獲得量 + 100%") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "全てのスキルに熟練度獲得量 + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 5%") + "\n" + Color(40, "可激活进攻模式") + "\n" + Color(50, "物理攻击 + 10%") + "\n" + Color(100, "所有技能熟练获取 + 100%") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "全てのスキルに熟練度獲得量 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(40, "Attack Stance is available") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "Skill Proficiency + 100% in all skills") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "Skill Proficiency + 200% in all skills");
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
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(40, "アタックスタンスが利用可能になる") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "全てのスキルに熟練度獲得量 + 100%") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "全てのスキルに熟練度獲得量 + 200%");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "物理攻击 + 5%") + "\n" + Color(40, "可激活进攻模式") + "\n" + Color(50, "物理攻击 + 10%") + "\n" + Color(100, "所有技能熟练获取 + 100%") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "全てのスキルに熟練度獲得量 + 200%");
                        break;
                    default:
                        requiredSkillString = Color(30, "ATK + 5%") + "\n" + Color(40, "Attack Stance is available") + "\n" + Color(50, "ATK + 10%") + "\n" + Color(100, "Skill Proficiency + 100% in all skills") + "\n" + Color(150, "ATK + 30%") + "\n" + Color(200, "Skill Proficiency + 200% in all skills");
                        break;
                }
                setFalse(window2Text5.gameObject);
                setFalse(window2Text6.gameObject);
            }
        }

        //NEXTSKILL
        if (P_level >= 1)
        {
            setActive(main.warriorSkillAry[1].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[1].skillCanvas);
        }
        if (P_level >= 3)
        {
            setActive(main.warriorSkillAry[8].skillCanvas);
        }
        else
        {
            setFalse(main.warriorSkillAry[8].skillCanvas);
        }

        //Passive
        if (P_level >= 40)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_SwordAttack)
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
        if(main.SR.P_SwordAttack)
            attackNum += 1;
        foreach (SKILL skill in main.warriorSkillAry)
        {
            if (skill.canGetExp)
            {
                switch (skill.skillLineage)
                {
                    case "Base":
                        skill.GetProExp(1);
                        break;

                    default:
                        skill.GetProExp(0.5);
                        break;
                }
            }
        }
    }


}
