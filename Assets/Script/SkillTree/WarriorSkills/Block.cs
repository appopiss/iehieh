using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;

public class Block : WARRIOR_SKILL
{
    //スキル固有のダメージ
    public override double Damage()
    {
        return 0;
    }
    //スキル固有のSPD
    public override float AttackInterval()
    {
        return 1f;
    }
    //必要熟練度
    public override double P_requiredExp()
    {
        return 100 * Math.Pow(1.12, P_level);
    }
    //必要コストの計算
    public override double CostStone()
    {
        return initialCostStone * Math.Pow(1.55, P_level);
    }
    public double Prob()
    {
        return Math.Min(100 + BuffedLevel() * 10, 3000);
    }
    public override void ShowDpsText()
    {
        DpsText.text = "<color=#ffffff>" + tDigit(Prob() / 100, 2) + "%";
    }


    private void Awake()
    {
        StartBASE();
        skillIndex = 9;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill(1, 0f, "Shield", 1f, 50000000);
        stanceButton.onClick.AddListener(() => InstantiateStance(2, main.SR.P_Block));
        if (main.SR.P_Block)
            Instantiate(main.StanceIcons[2], main.StanceIconCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();

        //window1
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[9];
            SkillLocal.block(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //window2
        if (window2.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[9];
            proficiencyString = tDigit((P_exp / P_requiredExp()) * 100, 2) + "%";
            SkillLocal.block(this, ref skillNameString, ref linageString, ref effectString, ref explainString, ref costString);

        }

        //MP
        if (BuffedLevel() <= 100)
        {
            mpFactor = 9 + BuffedLevel() * 6.5;
        }
        else if (BuffedLevel() >= 100 && BuffedLevel() <= 290)
        {
            mpFactor = 9 + BuffedLevel() * 6.5 * 0.5;
        }
        else if (BuffedLevel() > 290)
        {
            mpFactor = 9 + 290 * 6.5 * 0.5 - (BuffedLevel() - 290) * 0.55;
        }

        //PassiveEffect
        if (P_level >= 30)
        {
            pas1 = 0.20;
            pas2 = 0.1;
            pas3 = 0.1;
            pas4 = 0.1;
        }
        else
        {
            pas1 = 0;
            pas2 = 0;
            pas3 = 0;
            pas4 = 0;
        }
        if (P_level < 50)
        {
            pas5 = 0;
            pas6 = 0;
            pas7 = 0;
        }
        else if (P_level<150)
        {
            pas5 = 0.50;
            pas6 = 0.10;
            pas7 = 0.10;
        }
        else
        {
            pas5 = 2.50;
            pas6 = 1.60;
            pas7 = 1.60;

        }

        if (window.activeSelf)
        {
            if (canGetExp)
            {
                requiredAndPassiveString = SkillLocal.PassiveEffect();
                switch (LocalizeInitialize.language)
                {
                    case Language.jp:
                        requiredSkillString = Color(30, "HP + 20%, MP + 10%, DEF + 10%, MDEF + 10%") + "\n" + Color(50, "HP + 50% , DEF + 10%, MDEF + 10%") + "\n" + Color(100, "プロテクションスタンスが利用可能になる") + "\n" + Color(150, "HP + 200%, DEF + 150%, MDEF + 150%") + "\n" + Color(200, "Block Lost MP * 1/2");
                        break;
                    case Language.chi:
                        requiredSkillString = Color(30, "血量 + 20%, 蓝量 + 10%, 物理防御 + 10%, 魔法防御 + 10%") + "\n" + Color(50, "血量 + 50% , 物理防御 + 10%, 魔法防御 + 10%") + "\n" + Color(100, "可激活防御模式") + "\n" + Color(150, "血量 + 200%, 物理防御 + 150%, 魔法防御 + 150%") + "\n" + Color(200, "格挡耗蓝 * 1/2");
                        break;
                    default:
                        requiredSkillString = Color(30, "HP + 20%, MP + 10%, DEF + 10%, MDEF + 10%") + "\n" + Color(50, "HP + 50% , DEF + 10%, MDEF + 10%") + "\n" + Color(100, "Protection Stance is available") + "\n" + Color(150, "HP + 200%, DEF + 150%, MDEF + 150%") + "\n" + Color(200, "Block Lost MP * 1/2");
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
                        requiredSkillString = "<color=red>- シールドアタック < Lv 48 ></color>";
                        break;
                    case Language.chi:
                        requiredSkillString = "<color=red>- 盾击 < Lv 48 ></color>";
                        break;
                    default:
                        requiredSkillString = "<color=red>- Shield Attack < Lv 48 ></color>";
                        break;
                }
            }

        }

        //スキル開放条件
        if (main.warriorSkillAry[8].P_level >= 48)
        {
            canGetExp = true;
        }

        if (!IsEquipped())
        {
            main.isBlock = false;
        }

        //Passive
        if (P_level >= 100)
        {
            setActive(stanceButton.gameObject);
            if (!main.SR.P_Block)
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



    public override void DoSkill()
    {
       
    }

    int random;

    public override IEnumerator Attacking()
    {
        //ENEMY targetEnemy;
        while (true)
        {
            main.isBlock = false;
            yield return new WaitUntil(CanBuff);

            main.ally.currentMp -= ConsumeMp();
                random = UnityEngine.Random.Range(0, 10000);
                if (random <= Prob())
                {
                    main.isBlock = true;
                }
                else
                {
                    main.isBlock = false;
                }
            foreach (SKILL skill in main.warriorSkillAry)
            {
                if (skill.canGetExp)
                {
                    if (skill.skillLineage == "Shield")
                    {
                        skill.GetProExp(1);
                    }
                    else
                    {
                        skill.GetProExp(0.1);

                    }
                }
            }

            //targetEnemy = searchEnemy();
            //StartCoroutine(main.InstantiateAnimation(main.animationObject[2], targetEnemy.GetComponent<RectTransform>(), Damage()));


            yield return new WaitForSeconds(AttackInterval());
        }
    }


}
