using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class U_random1 : M_UPGRADE
{
    public override int level { get => main.SR.L_random1; set => main.SR.L_random1 = value; }

    private void Awake()
    {
        awakeText();
        isLottery = true;
        //MaxLevel = 10;
    }

    public override double[] calcurateCurrentCost()//100,200,300,400,500,600,700,800,900,1000,2000,3000,....,9000,10000,20000,30000,...
    {
        return new double[] { (100 * (1 + level%10 ) * Mathf.Pow(10, (int)((level)/10))) * main.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.LoyalBargain].GetCurrentValue(), 0, 0, 0 };
    }
    //50% statup //HP, MP, ATK, MATK, DEF,MDEF
    //30% resource
    //15% commonResources
    //3% Exp
    //2% Gold
    public override void AdditionalEffect()
    {
        int randomNum = UnityEngine.Random.Range(0, 10000);
        //ステータス用
        int randomStatusUp = Random.Range(1, 10) * (1 + (int)main.SR.level / 10);
        //HP,MP用
        int randomStatusUp2 = Random.Range(1, 10)* 5 * (1 + (int)main.SR.level / 10);
        //ゴールド用
        int randomStatusUp3 = Random.Range(1, 2);
        //EXP用
        int randomStatusUp4 = Random.Range(1, 2)*5;
        //リソース
        float randomStatusUpR = Random.Range(0.5f, 5f);
        //drop
        float randomStatusUpD = Random.Range(0.01f, 0.02f);
        if (randomNum <= 5000)
        {
            //StatusUp  
            if(randomNum <= 1000)
            {
                main.SR.R_HP += randomStatusUp2;
                main.Log("<color=orange>Gain HP + " + tDigit(randomStatusUp2) + " bonus!",5f);
            }else if(randomNum <= 2000)
            {
                main.SR.R_MP += randomStatusUp2;
                main.Log("<color=orange>Gain MP + " + tDigit(randomStatusUp2) + " bonus!", 5f);
            }
            else if (randomNum <= 2600)
            {
                main.SR.R_ATK += randomStatusUp;
                main.Log("<color=orange>Gain ATK + " + tDigit(randomStatusUp) + " bonus!", 5f);
            }
            else if (randomNum <= 3200)
            {
                main.SR.R_DEF += randomStatusUp;
                main.Log("<color=orange>Gain DEF + " + tDigit(randomStatusUp) + " bonus!", 5f);
            }
            else if (randomNum <= 3800)
            {
                main.SR.R_MATK += randomStatusUp;
                main.Log("<color=orange>Gain MATK + " + tDigit(randomStatusUp) + " bonus!", 5f);
            }
            else if (randomNum <= 4400)
            {
                main.SR.R_MDEF += randomStatusUp;
                main.Log("<color=orange>Gain MDEF + " + tDigit(randomStatusUp) + " bonus!", 5f);
            }
            else if (randomNum <= 5000)
            {
                main.SR.R_SPD += randomStatusUp;
                main.Log("<color=orange>Gain SPD + " + tDigit(randomStatusUp) + " bonus!", 5f);
            }
        }//resourceUpgrade
        else if (randomNum <= 6500)
        {
            if (randomNum <= 5500)
            {
                main.SR.R_stone += randomStatusUpR;
                main.Log("<color=orange>Gain Stone Production + " + percent(randomStatusUpR + 1) + " bonus!", 5f);
            }else if(randomNum <= 6000)
            {
                main.SR.R_crystal += randomStatusUpR;
                main.Log("<color=orange>Gain Crystal Production + " + percent(randomStatusUpR + 1) + " bonus!", 5f);
            }
            else if (randomNum <= 6500)
            {
                main.SR.R_leaf += randomStatusUpR;
                main.Log("<color=orange>Gain Leaf Production + " + percent(randomStatusUpR + 1) + " bonus!", 5f);
            }
        }
        //else if(randomNum <= 9500)
        //{
        //    if(randomNum <= 9000)
        //    {
        //        main.dropInfo.DropByTable(DropInfo.DropTable.CommonGeneral);
        //    }else if(randomNum <= 9500)
        //    {
        //        main.dropInfo.DropByTable(DropInfo.DropTable.UncommonGeneral);
        //    }
        //}
        else if(randomNum <= 9500)
        {
            if(randomNum <= 8000)
            {
                main.SR.R_EXP += randomStatusUp4;
                main.Log("<color=orange>Gain Extra EXP + " + tDigit(randomStatusUp4) + " bonus!", 5f);
            }
            else if(randomNum <= 9500){
                main.SR.R_GOLD += randomStatusUp3;
                main.Log("<color=orange>Gain Extra Gold + " + tDigit(randomStatusUp3) + " bonus!", 5f);
            }
        }
        else
        {
            main.SR.R_drop += randomStatusUpD;
            main.Log("<color=orange>Gain Drop Chance + " + UsefulMethod.percent(randomStatusUpD,2) + " bonus!", 5f);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(buyby1);
    }

    void buyby1()//このアップグレードだけは一個ずつ買うようにする
    {
        UPGRADE.buyMode tempBuyMode = main.SR.buyMode;
        main.SR.buyMode = UPGRADE.buyMode.mode1;
        calculate();
        main.SR.buyMode = tempBuyMode;
    }

    public string Discription()
    {
        string tempText = "";

        tempText = "Stats Upgrade : 50%\n- Resource Production Upgrade : 15%\n- EXP Bonus : 15%\n- Gold Bonus : 15%\n- Drop Chance : 5%";
        return tempText;
    }
    public string CurrentEffect()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                string tempText = "";
                if (main.SR.R_HP > 0)
                    tempText += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText += "- EXP Gain + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText += "- Gold Gain + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText += "- Stone Production + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText += "- Crystal Production + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText += "- Leaf Production  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText += "- Drop Chance  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText;
            case Language.jp:
                string tempText2 = "";
                if (main.SR.R_HP > 0)
                    tempText2 += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText2 += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText2 += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText2 += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText2 += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText2 += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText2 += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText2 += "- 経験値 + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText2 += "- ゴールド + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText2 += "- ストーンの生産量 + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText2 += "- クリスタルの生産量 + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText2 += "- リーフの生産量  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText2 += "- ドロップ率  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText2;
            default:
                string tempText3 = "";
                if (main.SR.R_HP > 0)
                    tempText3 += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText3 += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText3 += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText3 += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText3 += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText3 += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText3 += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText3 += "- EXP Gain + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText3 += "- Gold Gain + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText3 += "- Stone Production + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText3 += "- Crystal Production + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText3 += "- Leaf Production  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText3 += "- Drop Chance  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText3;

        }
        //string tempText = "";
        //if (main.SR.R_HP > 0) 
        //    tempText += "- HP + " + tDigit(main.SR.R_HP) + "\n";
        //if (main.SR.R_MP > 0)
        //    tempText += "- MP + " + tDigit(main.SR.R_MP) + "\n";
        //if (main.SR.R_ATK > 0)
        //    tempText += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
        //if (main.SR.R_MATK > 0)
        //    tempText += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
        //if (main.SR.R_DEF > 0)
        //    tempText += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
        //if (main.SR.R_MDEF > 0)
        //    tempText += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
        //if (main.SR.R_SPD > 0)
        //    tempText += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
        //if (main.SR.R_EXP > 0)
        //    tempText += "- EXP Gain + " + tDigit(main.SR.R_EXP) + "\n";
        //if (main.SR.R_GOLD > 0)
        //    tempText += "- Gold Gain + " + tDigit(main.SR.R_GOLD) + "\n";
        //if (main.SR.R_stone > 0)
        //    tempText += "- Stone Production + " + UsefulMethod.percent(main.SR.R_stone,1) + "\n";
        //if (main.SR.R_crystal > 0)
        //    tempText += "- Crystal Production + " + UsefulMethod.percent(main.SR.R_crystal,1) + "\n";
        //if (main.SR.R_leaf > 0)
        //    tempText += "- Leaf Production  + " + UsefulMethod.percent(main.SR.R_leaf,1) + "\n";
        //if (main.SR.R_drop > 0)
        //    tempText += "- Drop Chance  + " + UsefulMethod.percent(main.SR.R_drop,2) + "\n";
        //return tempText;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        upgradeIcon.sprite = gameObject.GetComponent<Image>().sprite;
        Name = L_Upgrades.lottaryName();
        effectExplain = CurrentEffect();
        currentValue = "Get 1 random effect.";
        nextValue = "Get 1 random effect.";
        explain = L_Upgrades.lottaryDescription();
    }
}
