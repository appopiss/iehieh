using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using TMPro;
using static ArtiCtrl;
using static ALCHEMY;

public class CONSUMEITEM : BASE,IPointerDownHandler
{

    GameObject window;
    public string Name;
    [NonSerialized]
    public string explain;
    public ALCHEMY.MaterialName materialName;
    [NonSerialized]
    GameObject LockText;
    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }
    [NonSerialized]
    public int definedQuality;
    int factor01;
    double factor02double;
    float factor03float;
    //float random;


    // Use this for initialization
    void Start()
    {
        LockText = gameObject.transform.GetChild(0).gameObject;
        //random = UnityEngine.Random.Range(0, 10000);
        InstantiateWindow();

        DefinedEffect();
    }
    [NonSerialized]
    public bool isClicked;
    [NonSerialized]
    public bool isLock;

    public bool CanUse()
    {
        return isClicked && !isLock;
    }

    public void DefinedEffect()
    {
        switch (materialName)
        {
            case MaterialName.DPSWater:
                if (definedQuality == 95)
                {
                    explain = "Mysteryious Water + 1.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 1f;
                }
                else if (definedQuality == 96)
                {
                    explain = "Mysterious Water + 2.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 2f;
                }
                else if (definedQuality == 97)
                {
                    explain = "Mysterious Water + 3.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 3f;
                }
                else if (definedQuality == 98)
                {
                    explain = "Mysterious Water + 4.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 4f;
                }
                else if (definedQuality == 99)
                {
                    explain = "Mysterious Water + 5.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 5f;
                }
                else if (definedQuality == 100)
                {
                    explain = "Mysterious Water + 10.000 mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += 10f;
                }
                else
                {
                    explain = "Mysterious Water + " + tDigit(Mathf.Pow(definedQuality, 1.30f) / 500f, 3) + " mL / s";
                    if (CanUse())
                        main.SR.waterAddDPSByPotion += Mathf.Pow(definedQuality, 1.30f) / 500f;
                }
                break;

            case MaterialName.ReasonableMonsterEnergy:
                factor01 = (int)(1 + Math.Max((definedQuality - 1) / 7, 0));
                factor03float = definedQuality * Mathf.Pow(factor01, 3) / 100;
                explain = "Mysterious Water + " + tDigit(factor03float, 3) + " mL / s";
                if (CanUse())
                    main.SR.waterAddDPSByPotion += Mathf.Pow(definedQuality, 1.30f) / 500f;
                break;


            case MaterialName.SpicyMonsterEnergy:
                if (definedQuality <= 30)
                {
                    explain = "Mysterious Water + 100% for 30 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(1, 30f);
                }
                else if (definedQuality <= 50)
                {
                    explain = "Mysterious Water + 200% for " + definedQuality +" s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(2f, definedQuality);
                }
                else if (definedQuality <= 80)
                {
                    explain = "Mysterious Water + 300% for " + definedQuality + " s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(3f, definedQuality);
                }
                else if (definedQuality <= 90)
                {
                    explain = "Mysterious Water + 400% for " + definedQuality + " s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(4f, definedQuality);
                }
                else if (definedQuality <= 95)
                {
                    explain = "Mysterious Water + 500% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(5f, definedQuality);
                }
                else if (definedQuality == 96)
                {
                    explain = "Mysterious Water + 600% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(6, 90f);
                }
                else if (definedQuality == 97)
                {
                    explain = "Mysterious Water + 700% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(7, 90f);
                }
                else if (definedQuality == 98)
                {
                    explain = "Mysterious Water + 800% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(8, 90f);
                }
                else if (definedQuality == 99)
                {
                    explain = "Mysterious Water + 900% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(9, 90f);
                }
                else if (definedQuality == 100)
                {
                    explain = "Mysterious Water + 2000% for 90 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(20, 90f);
                }
                else
                {
                    explain = "Mysterious Water + 1000% for 300 s";
                    if (CanUse())
                        main.alchemyController.StartPureBoost(10, 300f);
                }
                break;
            case MaterialName.StoneWater:
                if (definedQuality == 100)
                {
                    explain = "Stone Production + 1000% for 180 s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(0, 10, 180);
                }
                else
                {
                    explain = "Stone Production + 300% for " + 5 * (int)(1 + definedQuality / 5) + " s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(0, 3, 5 * (int)(1 + definedQuality / 5));
                }
                break;
            case MaterialName.CrystalWater:
                if (definedQuality == 100)
                {
                    explain = "Crystal Production + 1000% for 180 s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(1, 10, 180);
                }
                else
                {
                    explain = "Crystal Production + 300% for " + 5 * (int)(1 + definedQuality / 5) + " s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(1, 3, 5 * (int)(1 + definedQuality / 5));
                }
                break;
            case MaterialName.LeafWater:
                if (definedQuality == 100)
                {
                    explain = "Leaf Production + 1000% for 180 s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(2, 10, 180);
                }
                else
                {
                    explain = "Leaf Production + 300% for " + 5 * (int)(1 + definedQuality / 5) + " s";
                    if (CanUse())
                        main.alchemyController.StartResourseBoost(2, 3, 5 * (int)(1 + definedQuality / 5));
                }
                break;
            case MaterialName.HpPortion:
                if (definedQuality == 100)
                {
                    explain = "Full Heal";
                    if (CanUse())
                        main.ally.currentHp += main.ally.HP();
                }
                else
                {
                    explain = "Heal HP + " + definedQuality * 20;
                    if (CanUse())
                        main.ally.currentHp += definedQuality * 20;
                }
                break;
            case MaterialName.MpPortion:
                if (definedQuality == 100)
                {
                    explain = "Restore Full MP";
                    if (CanUse())
                        main.ally.currentMp += main.ally.MP();
                }
                else
                {
                    explain = "Restore MP + " + definedQuality * 20;
                    if (CanUse())
                        main.ally.currentMp += definedQuality * 20;
                }
                break;
            case MaterialName.HpPotion2:
                if (definedQuality >= 95)
                {
                    explain = "Full Heal";
                    if (CanUse())
                        main.ally.currentHp += main.ally.HP();
                }
                else
                {
                    explain = "Heal HP + " + definedQuality + "%";
                    if (CanUse())
                        main.ally.currentHp += main.ally.HP() * (double)definedQuality/100d;
                }
                break;
            case MaterialName.MpPotion2:
                if (definedQuality >= 95)
                {
                    explain = "Restore Full MP";
                    if (CanUse())
                        main.ally.currentMp += main.ally.MP();
                }
                else
                {
                    explain = "Restore MP + " + definedQuality + "%";
                    if (CanUse())
                        main.ally.currentMp += main.ally.MP() * (double)definedQuality/100d;
                }
                break;
            case MaterialName.HpPotion3:
                if (definedQuality <= 20)
                {
                    factor01 = 10;
                    factor02double = 0.5;
                }
                else if(definedQuality <= 50)
                {
                    factor01 = 20;
                    factor02double = 0.5;
                }
                else if(definedQuality <= 80)
                {
                    factor01 = 30;
                    factor02double = 0.5;
                }
                else if(definedQuality <= 90)
                {
                    factor01 = 30;
                    factor02double = 1;
                }
                else if(definedQuality <= 95)
                {
                    factor01 = 45;
                    factor02double = 1;
                }
                else if(definedQuality == 96)
                {
                    factor01 = 50;
                    factor02double = 1;
                }
                else if(definedQuality == 97)
                {
                    factor01 = 55;
                    factor02double = 1;
                }
                else if(definedQuality == 98)
                {
                    factor01 = 60;
                    factor02double = 1;
                }
                else if(definedQuality == 99)
                {
                    factor01 = 60;
                    factor02double = 1.5;
                }
                else
                {
                    factor01 = 60;
                    factor02double = 2;
                }
                explain = "Heal HP + " + definedQuality + "%\n- Regenerate HP + " + tDigit(factor02double, 2) + "% / s for " + factor01 + " s";
                if (CanUse())
                {
                    main.ally.currentHp += main.ally.HP() * (double)definedQuality / 100d;
                    main.alchemyController.StartHpRegen(factor02double, factor01);
                }
                break;
            case MaterialName.MpPotion3:
                if (definedQuality <= 20)
                {
                    factor01 = 10;
                    factor02double = 2.5;
                }
                else if (definedQuality <= 50)
                {
                    factor01 = 20;
                    factor02double = 2.5;
                }
                else if (definedQuality <= 80)
                {
                    factor01 = 30;
                    factor02double = 2.5;
                }
                else if (definedQuality <= 90)
                {
                    factor01 = 30;
                    factor02double = 5;
                }
                else if (definedQuality <= 95)
                {
                    factor01 = 45;
                    factor02double = 5;
                }
                else if (definedQuality == 96)
                {
                    factor01 = 50;
                    factor02double = 5;
                }
                else if (definedQuality == 97)
                {
                    factor01 = 55;
                    factor02double = 5;
                }
                else if (definedQuality == 98)
                {
                    factor01 = 60;
                    factor02double = 5;
                }
                else if (definedQuality == 99)
                {
                    factor01 = 60;
                    factor02double = 7.5;
                }
                else
                {
                    factor01 = 60;
                    factor02double = 10;
                }
                explain = "Restore MP + " + definedQuality + "%\n- Regenerate MP + " + tDigit(factor02double, 2) + "% / s for " + factor01 + " s";
                if (CanUse())
                {
                    main.ally.currentHp += main.ally.MP() * (double)definedQuality / 100d;
                    main.alchemyController.StartMpRegen(factor02double, factor01);
                }
                break;
            case MaterialName.CurePortion:
                if (definedQuality >= 95)
                {
                    explain = "Remove all debuffs\n- Debuff resistance + 100% for " + definedQuality * 6 + " s";
                    if (CanUse())
                        main.alchemyController.StartCureCor(100, definedQuality * 6);
                }
                else
                {
                    explain = "Remove all debuffs\n- Debuff resistance + 20% for " + definedQuality * 6 + " s";
                    if (CanUse())
                        main.alchemyController.StartCureCor(20, definedQuality * 6);
                }
                break;
            case MaterialName.SpicyPortion:
                explain = "SPD + 100K for " + definedQuality * 5 + " s";
                if (CanUse())
                {
                    if (!main.ally.updateDuration(Main.Buff.spicy))
                    {
                        ABNORMAL game;
                        game = Instantiate(main.StatusIcons[11], main.StatusIconCanvas);
                        game.duration = definedQuality * 5;
                    }
                }
                break;
            case MaterialName.GoldPotion:
                if (definedQuality == 100)
                {
                    explain = "Gain 1000 Gold from all monsters for 30 s";
                    if (CanUse())
                        main.alchemyController.StartGoldBoost(1000, 30);
                }
                else
                {
                    explain = "Gold Gain + " + definedQuality + " for 30 s";
                    if (CanUse())
                        main.alchemyController.StartGoldBoost(definedQuality, 30);
                }
                break;
            case MaterialName.EXPPotion:
                if (definedQuality == 100)
                {
                    explain = "EXP Gain + 5000 for 30 s";
                    if (CanUse())
                        main.alchemyController.StartExpBoost(definedQuality * 10, 30);
                }
                else
                {
                    explain = "EXP Gain + " + definedQuality * 10 + " for 30 s";
                    if (CanUse())
                        main.alchemyController.StartExpBoost(definedQuality * 10, 30);
                }
                break;
            case MaterialName.ATKUp:
                if (definedQuality == 100)
                {
                    explain = "ATK + 100% for 300 s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(100, 300);
                }
                else if (definedQuality >= 95)
                {
                    explain = "ATK + 50% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(50, definedQuality * 3);
                }
                else if (definedQuality <= 5)
                {
                    explain = "ATK + 25% for 15 s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(25, 15);
                }
                else
                {
                    explain = "ATK + 25% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(25, definedQuality * 3);
                }
                break;
            case MaterialName.MATKUp:
                if (definedQuality == 100)
                {
                    explain = "MATK + 100% for 300 s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(100, 300);
                }
                else if (definedQuality >= 95)
                {
                    explain = "MATK + 50% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(50, definedQuality * 3);
                }
                else if (definedQuality <= 5)
                {
                    explain = "MATK + 25% for 15 s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(25, 15);
                }
                else
                {
                    explain = "MATK + 25% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(25, definedQuality * 3);
                }
                break;
            case MaterialName.DEFMDEFUp:
                if (definedQuality == 100)
                {
                    explain = "DEF + 100%, MDEF + 100% for 300 s";
                    if (CanUse())
                    {
                        main.alchemyController.StartDefBoost(25, definedQuality * 3);
                        main.alchemyController.StartMDefBoost(25, definedQuality * 3);
                    }
                }
                else if (definedQuality <= 5)
                {
                    explain = "DEF + 25%, MDEF + 25% for 15 s";
                    if (CanUse())
                    {
                        main.alchemyController.StartDefBoost(25, 15);
                        main.alchemyController.StartMDefBoost(25, 15);
                    }
                }
                else if (definedQuality >= 95)
                {
                    explain = "DEF + 50%, MDEF + 50% for " + definedQuality * 3 + " s";
                    if (CanUse())
                    {
                        main.alchemyController.StartDefBoost(50, definedQuality * 3);
                        main.alchemyController.StartMDefBoost(50, definedQuality * 3);
                    }
                }
                else
                {
                    explain = "DEF + 25%, MDEF + 25% for " + definedQuality * 3 + " s";
                    if (CanUse())
                    {
                        main.alchemyController.StartDefBoost(25, definedQuality * 3);
                        main.alchemyController.StartMDefBoost(25, definedQuality * 3);
                    }
                }
                break;
            case MaterialName.DropPotion:
                explain = "Drop Chance + 100% for " + definedQuality * 10 + " s";
                if (CanUse())
                    main.alchemyController.StartDropBoost(1, definedQuality * 10);
                break;
            case MaterialName.BankEfficiency:
                explain = "Slime Coin Efficiency + 100% for " + definedQuality * 10 + " s";
                if (CanUse())
                    main.alchemyController.StartBankBoost(1, definedQuality * 10);
                break;
            case MaterialName.PoisonBanana:
                break;
            case MaterialName.Traps:
                explain = "Right-click on a monster to capture it except Challenge Boss.\n- Capture Chance increases according to the monster's HP decrease.";
                if (!CanUse())
                    main.alchemyController.trapNum += 1;
                break;

            case MaterialName.TinctureOfBoss1:
                if (definedQuality <= 95) 
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;

                explain = "Reduce the difficulty of Slime King Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum = 0;
                }
                break;

            case MaterialName.TinctureOfBoss2:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Golem Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum = 0;
                }
                break;
            case MaterialName.TinctureOfBoss3:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Deathpider Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum = 0;
                }
                break;
            case MaterialName.TinctureOfBoss4:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Fairy Queen Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum+1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum = 0;
                }
                break;
            case MaterialName.TinctureOfBoss5:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Bananoon Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum = 0;
                }
                break;
            case MaterialName.TinctureOfBoss6:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Octobaddie Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum = 0;
                }
                break;
            case MaterialName.TinctureOfBoss7:
                if (definedQuality <= 95)
                    factor01 = (int)(1 + (double)definedQuality / 5d);
                else if (definedQuality == 96)
                    factor01 = 25;
                else if (definedQuality == 97)
                    factor01 = 30;
                else if (definedQuality == 98)
                    factor01 = 35;
                else if (definedQuality == 99)
                    factor01 = 40;
                else
                    factor01 = 50;
                explain = "Reduce the difficulty of Distortion Slime Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum + 1) + " )";
                if (CanUse())
                {
                    if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum >= (int)factor01)
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum -= (int)factor01;
                    else
                        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum = 0;
                }
                break;
            //case MaterialName.TinctureOfBoss8:
            //    requiredUnlockAP = 300000;
            //    break;
            case MaterialName.AlchemyPoint:
                if (definedQuality == 100)
                    factor01 = 25000;
                else if (definedQuality == 99)
                    factor01 = 20000;
                else if (definedQuality == 98)
                    factor01 = 15500;
                else if (definedQuality == 97)
                    factor01 = 11500;
                else if (definedQuality == 96)
                    factor01 = 8000;
                else if (definedQuality == 95)
                    factor01 = 5000;
                else
                    factor01 = definedQuality * 50;
                explain = "Alchemy Point + " + factor01;
                if (CanUse())
                {
                    main.S.gainedAlchemyPoint += factor01;
                }
                break;
            case MaterialName.ResourseElixir:
                if (definedQuality <= 10)
                    factor01 = 10;
                else if (definedQuality <= 20)
                    factor01 = definedQuality;
                else if (definedQuality <= 30)
                    factor01 = definedQuality * 2;
                else if (definedQuality <= 40)
                    factor01 = definedQuality * 3;
                else if (definedQuality <= 50)
                    factor01 = definedQuality * 4;
                else if (definedQuality <= 60)
                    factor01 = definedQuality * 5;
                else if (definedQuality <= 70)
                    factor01 = definedQuality * 6;
                else if (definedQuality <= 80)
                    factor01 = definedQuality * 7;
                else if (definedQuality <= 90)
                    factor01 = definedQuality * 8;
                else if (definedQuality <= 95)
                    factor01 = definedQuality * 9;
                else if (definedQuality == 96)
                    factor01 = 1000;
                else if (definedQuality == 97)
                    factor01 = 2000;
                else if (definedQuality == 98)
                    factor01 = 3000;
                else if (definedQuality == 99)
                    factor01 = 5000;
                else//100
                    factor01 = 10000;
                explain = "Stone Production + " + (factor01*100) + "% for 30 s\n- Crystal Production + " + (factor01 * 100) + "% for 30 s\n- Leaf Production + " + (factor01 * 100) + "% for 30 s";
                if (CanUse())
                {
                    main.alchemyController.StartResourseBoost(0, factor01, 30);
                    main.alchemyController.StartResourseBoost(1, factor01, 30);
                    main.alchemyController.StartResourseBoost(2, factor01, 30);
                }
                break;
            case MaterialName.NitroPotion:
                if (definedQuality < 90)
                    factor01 = definedQuality * 5;
                else if (definedQuality == 90)
                    factor01 = 500;
                else if (definedQuality == 91)
                    factor01 = 550;
                else if (definedQuality == 92)
                    factor01 = 600;
                else if (definedQuality == 93)
                    factor01 = 650;
                else if (definedQuality == 94)
                    factor01 = 700;
                else if (definedQuality == 95)
                    factor01 = 750;
                else if (definedQuality == 96)
                    factor01 = 800;
                else if (definedQuality == 97)
                    factor01 = 850;
                else if (definedQuality == 98)
                    factor01 = 900;
                else if (definedQuality == 99)
                    factor01 = 1000;
                else//100
                    factor01 = 2000;
                explain = "Charge Nitro + " + factor01;
                if (CanUse())
                {
                    main.S.CurrentNitro += factor01;
                }
                break;

            case MaterialName.ATKUp2:
                if (definedQuality == 100)
                {
                    explain = "ATK + 10000% for 300 s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(10000, 300);
                }
                else if (definedQuality >= 95)
                {
                    explain = "ATK + 2500% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(2500, definedQuality * 3);
                }
                else if (definedQuality >= 90)
                {
                    explain = "ATK + 1000% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(1000, definedQuality * 3);
                }
                else if (definedQuality >= 80)
                {
                    explain = "ATK + 500% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(500, definedQuality * 3);
                }
                else if (definedQuality <= 5)
                {
                    explain = "ATK + 50% for 15 s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(50, 15);
                }
                else
                {
                    explain = "ATK + 250% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartAtkBoost(250, definedQuality * 3);
                }
                break;
            case MaterialName.MATKUp2:
                if (definedQuality == 100)
                {
                    explain = "MATK + 10000% for 300 s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(10000, 300);
                }
                else if (definedQuality >= 95)
                {
                    explain = "MATK + 2500% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(2500, definedQuality * 3);
                }
                else if (definedQuality >= 90)
                {
                    explain = "MATK + 1000% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(1000, definedQuality * 3);
                }
                else if (definedQuality >= 80)
                {
                    explain = "MATK + 500% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(500, definedQuality * 3);
                }
                else if (definedQuality <= 5)
                {
                    explain = "MATK + 50% for 15 s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(50, 15);
                }
                else
                {
                    explain = "MATK + 250% for " + definedQuality * 3 + " s";
                    if (CanUse())
                        main.alchemyController.StartMAtkBoost(250, definedQuality * 3);
                }
                break;

            default:
                break;
        }
        if (CanUse() && materialName != MaterialName.Traps)
        {
            Destroy(gameObject);
        }

    }

    double alchemyPoint()
    {
        if (definedQuality < 95)
            return definedQuality;
        else if (definedQuality == 95)
            return 150;
        else if (definedQuality == 96)
            return 300;
        else if (definedQuality == 97)
            return 500;
        else if (definedQuality == 98)
            return 750;
        else if (definedQuality == 99)
            return 1000;
        else
            return 3000;
    }
    private void OnDestroy()
    {
        main.S.gainedAlchemyPoint += alchemyPoint();
        Destroy(window);
    }

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[9], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }

    // Update is called once per frame
    void Update()
    {
        updateText();

    }

    public void updateText()
    {
        LockWindow();
    }
    public void LockWindow()
    {
        if (window.activeSelf)
        {            
            if (main.S.AlchemyLock && materialName != MaterialName.Traps)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    if (Input.GetKey(KeyCode.L))
                    {
                        if (isLock)
                            isLock = false;
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.L))
                    {
                        if (!isLock)
                            isLock = true;
                    }
                }
            }
            window.transform.GetChild(0).GetComponentInChildren<Image>().sprite = gameObject.GetComponentsInChildren<Image>()[0].sprite;
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "                 " + Name;
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "                       Quality : " + definedQuality;
            if (main.S.AlchemyLock && materialName != MaterialName.Traps)
            {
                if (isLock)
                    window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "\n                       <color=green>Locked</color> ( \"Shift-L\" to unlock )\n ";
                else
                    window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "\n                       Unlocked ( \"L\" to lock )\n ";
            }
            else
                window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "\n\n ";

            //Tinctureの表示を更新
            switch (materialName)
            {
                case MaterialName.TinctureOfBoss1:
                    explain = "Reduce the difficulty of Slime King Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum + 1) + " )";
                    break;

                case MaterialName.TinctureOfBoss2:
                    explain = "Reduce the difficulty of Golem Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum + 1) + " )";
                    break;
                case MaterialName.TinctureOfBoss3:
                    explain = "Reduce the difficulty of Deathpider Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum + 1) + " )";
                    break;
                case MaterialName.TinctureOfBoss4:
                    explain = "Reduce the difficulty of Fairy Queen Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum + 1) + " )";
                    break;
                case MaterialName.TinctureOfBoss5:
                    explain = "Reduce the difficulty of Bananoon Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum + 1) + " )";
                    break;
                case MaterialName.TinctureOfBoss6:
                    explain = "Reduce the difficulty of Octobaddie Challenge Boss by " + factor01 + " levels ( Current level : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum + 1) + " )";
                    break;
                default:
                    break;
            }

            window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Effect (Click to use)";
            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + explain;
            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += "\n- Alchemy Point + " + alchemyPoint();
            //window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Alchemy Point";
            setFalse(window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().gameObject);
            setFalse(window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().gameObject);

            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
            //    }
            //}
        }
        if (main.GameController.currentCanvas==main.GameController.ArtifactCanvas)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                if (Input.GetKey(KeyCode.X))
                {
                    if (Input.GetKey(KeyCode.L))
                    {
                        if(isLock)
                            isLock = false;
                    }
                }
            }
            if (isLock)
                setActive(LockText);
            else
                setFalse(LockText);
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if ((eventData.pointerId == -1|| eventData.pointerId == -2))
        {
            isClicked = true;
            DefinedEffect();
        }
    }
}
