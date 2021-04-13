using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Heal : ANGEL_SKILL
{
    public override double Damage()//ここでは回復量！
    {
        if (BuffedLevel() >= 200)
        {
            return (10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * UnityEngine.Random.Range(0.8f, 1.0f)) * 2;
        }
        else if (BuffedLevel() >= 25)
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * UnityEngine.Random.Range(0.8f, 1.0f);
        }
        else if (BuffedLevel() >= 10 && BuffedLevel() < 25)
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * UnityEngine.Random.Range(0.4f, 1.0f);
        }
        else if (BuffedLevel() < 10)
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * UnityEngine.Random.Range(0.2f, 1.0f);
        }
        else
        {
            return 10 + Math.Pow(1.025,BuffedLevel())*2 + BuffedLevel() * 5 * UnityEngine.Random.Range(0.2f, 1.0f);
        }

    }
    public double damageMin() {
        if (BuffedLevel() >= 25)
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * 0.8;
        }
        else if (BuffedLevel() >= 10 && BuffedLevel() < 25)
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * 0.4;
        }
        else if (BuffedLevel() < 10) 
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * 0.2;
        }
        else
        {
            return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * 0.2;
        }
         }
    public double damageMax() { return 10 + Math.Pow(1.025, BuffedLevel())*2 + BuffedLevel() * 5 * 1.0; }

    public override float AttackInterval()
    {
        return BaseAttackInterval() * Mathf.Max((float)(3 - (BuffedLevel() * 0.0125)), 0.5f);
    }

    public override double P_requiredExp()
    {
        return 50 * Math.Pow(1.13, P_level);
    }

    public override double CostLeaf()
    {
        return initialCostLeaf * Math.Pow(1.55, P_level);
    }

    public double cureChance()
    {
        return Math.Min(100 + P_level * 10,2500);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#32ff32>HPS : " + tDigit(damageMin() / AttackInterval()) + " ~ " + tDigit(damageMax() / AttackInterval());
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 22;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0, "Heal", 1f, 0, 0, 300, DamageKind.nothing);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[22];
            SkillLocal.heal(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[22];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 1) + "%";
            SkillLocal.heal(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);
        }

        //MP
        if(main.skillprogress.isHealInterval)
            mpFactor = BuffedLevel() * 2.5 * 0.75;
        else
            mpFactor = BuffedLevel() * 2.5;

        //PassiveEffect
        if (P_level >= 25)
        {
            pas4 = 0;
        }
        else
        {
            pas4 = 0;
        }
        if (P_level >= 50)
        {
            pas5 = 0;
        }
        else
        {
            pas5 = 0;
        }
        if (P_level < 100)
        {
            pas6 = 0;
        }
        else if (P_level < 150)
        {
            pas6 = 1;
        }
        else
            pas6 = 3;



        if (canGetExp)
        {
            requiredAndPassiveString = SkillLocal.PassiveEffect();
            switch (LocalizeInitialize.language)
            {
                case Language.jp:
                    requiredSkillString = Color(10, "最低ヒール量 + 100%") +
                        "\n" + Color(25, "最低ヒール量 + 100%") + "\n" + Color(50, "状態異常回復の効果を追加") +
                        "\n" + Color(100, "HP + 100%") + "\n" + Color(150, "HP + 200%") + "\n" + Color(200, "回復量 + 100%");
                    break;
                case Language.chi:
                    requiredSkillString = Color(10, "最低回复血量 + 100%") +
                        "\n" + Color(25, "最低回复血量 + 100%") + "\n" + Color(50, "概率解除减益状态") +
                        "\n" + Color(100, "血量 + 100%") + "\n" + Color(150, "血量 + 200%") + "\n" + Color(200, "回复血量 + 100%");
                    break;
                default:
                    requiredSkillString = Color(10, "Minimum Heal Point + 100%") +
                        "\n" + Color(25, "Minimum Heal Point + 100%") + "\n" + Color(50, "Cure your debuffs sometimes") +
                        "\n" + Color(100, "HP + 100%") + "\n" + Color(150, "HP + 200%") + "\n" + Color(200, "Heal Point + 100%");
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
                    requiredSkillString = "<color=red>- ウィングアタック < Lv 6 >\n- ウィングシュート < Lv 6 ></color>";
                    break;
                case Language.chi:
                    requiredSkillString = "<color=red>- 翅膀攻击 < Lv 6 >\n- 风刃 < Lv 6 ></color>";
                    break;
                default:
                    requiredSkillString = "<color=red>- Wing Attack < Lv 6 >\n- Wing Shoot < Lv 6 ></color>";
                    break;
            }
        }

        //スキル開放条件
        if (main.angelSkillAry[0].P_level >= 6 && main.angelSkillAry[1].P_level >= 6)
        {
            canGetExp = true;
        }


    }

    public override void GetProf()
    {
        foreach (SKILL skill in main.angelSkillAry)
        {
            if (skill.canGetExp)
            {
                if (skill.skillLineage == "Heal")
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
        //ENEMY targetEnemy;
        while (true)
        {
            yield return new WaitUntil(CanBuff);
            main.ally1.GetComponent<ALLY>().currentHp += Damage();
            StartCoroutine(main.InstantiateSubAnimation(main.animationObject[16], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
            if (UnityEngine.Random.Range(0, 10000) <= cureChance())
            {
                foreach (Transform child in main.StatusIconCanvas)
                {
                    if (child.GetComponent<ABNORMAL>().debuff != Main.Debuff.nothing)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }           
            InstantiateHealText(Damage());
            GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

    public void ManualBuff()
    {
        main.ally1.GetComponent<ALLY>().currentHp += Damage();
        StartCoroutine(main.InstantiateSubAnimation(main.animationObject[16], main.ally1.gameObject.GetComponent<RectTransform>(), ConsumeMp()));
        if (UnityEngine.Random.Range(0, 10000) <= cureChance())
        {
            foreach (Transform child in main.StatusIconCanvas)
            {
                if (child.GetComponent<ABNORMAL>().debuff != Main.Debuff.nothing)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        InstantiateHealText(Damage());
        GetProf();
    }

    public void InstantiateHealText(double healPoint)
    {
        GameObject healTextElect;
        healTextElect = Instantiate(main.prefabAry_H[0], main.Transforms[1]);
        healTextElect.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 255, 0);
        healTextElect.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        healTextElect.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        healTextElect.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + tDigit(healPoint, 1);
    }

    public override void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        ManualBuff();
    }



}
