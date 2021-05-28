using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class BuyPremium : BASE {

    public Func<int> Cost;
    public Func<bool> LimitCondition;
    public GoodsId goodsId;
    public Button buyButton;
    public GameObject unleashed;
    public int MaxBuyNum = 9999999;


    public enum GoodsId
    {
        QueueCap1,
        QueueCap2,
        QueueCap3,
        QueueCap4,
        QueueCapInSlimeBank1,
        QueueCapInSlimeBank2,
        QueueCapInSlimeBank3,
        QueueCapInSlimeBank4,
        MonsterFluidBundle,
        AutoLoot,
        SuperRebrth,
        AdditionalDailyQuest,
        MinumumDailyQuest,
        oblivion,
        InstantRebirth,
        ResetLottery,
        ResetRebirthUpgrade,
        LegendaryPotion,
        MajorTinctureSlime,
        MajorTinctureGolem,
        MajorTinctureSpider,
        MajorTinctureFairy,
        AddDailyQuest1,
        AddDailyQuest2,
        AddDailyQuest3,
        DailyQuestRarity1,
        DailyQuestRarity2,
        ExtraSkillSlot,
        NitroMax,
        NitroCapUp,
        EquipmentSlot,
        ExtraGlobalSkillSlot,
        MonsterFluidBundle2,
        EquipmentSlot2,
        WaterALL,
        MajorTinctureBanana,
        ExtraGlobalSkillSlotFirst,
        AutoExpandAlchemy,
        AutoActiveSkill,
        CustomRange,
        FavoriteDungeon,
        AllClearEQ,
        SuperQueue,
        CustomMoveSpeed,
        SuperQueueForSB,
        MajorTinctureOctobaddie,
        AlchemyLock,
        ExpandAlchemyInventory1,
        ExpandAlchemyInventory2,
        ExpandAlchemyInventory3,
        ExpandAlchemyInventory4,
        SkillSetSave1,
        SkillSetSave2,
        SkillSetSave3,
        SkillSetSave4,
        SkillSetSaveLoad,
        AutoNitro,
        ResetSpiritUpgrade,
        InstantSpiritUpgrade,
        AutoMaxSkill,
        SuperQueueMemory,
        MajorTinctureDistortion,
        EquipmentSlot3,
        FavoriteEquip,
        RainbowFish,
        GemProduction,
        ExpMulti1,
        ExpMulti2,
        MonsterGoldCap1,
        MonsterGoldCap2,
        MonsterGoldCap3,
        MonsterGoldCap4,
        SuperQueueForAlchemy,
        PersistentSuperQueue,
        PersistentFavoriteEquip,
        TimeWarp2,
        TimeWarp4,
        TimeWarp8,
        TimeWarp24,
    }

    // Use this for initializationx
    void Awake () {
		StartBASE();
        buyButton = gameObject.transform.GetChild(3).GetComponent<Button>();
        unleashed = gameObject.transform.GetChild(4).gameObject;
        buyButton.onClick.AddListener(Buy);
        switch (goodsId)
        {
            case GoodsId.QueueCap1:
                Cost = () => 1000;
                LimitCondition = () => main.S.Queue1_buyNum == 5;
                break;
            case GoodsId.QueueCap2:
                Cost = () => 2500;
                LimitCondition = () => main.S.Queue2_buyNum == 5;
                break;
            case GoodsId.QueueCap3:
                Cost = () => 5000;
                LimitCondition = () => main.S.Queue3_buyNum == 5;
                break;
            case GoodsId.QueueCap4:
                Cost = () => 12500;
                LimitCondition = () => main.S.Queue4_buyNum == 10;
                break;
            case GoodsId.QueueCapInSlimeBank1:
                Cost = () => 7500;
                LimitCondition = () => main.S.QueueInSlimeBank_buyNum1 == 3;
                break;
            case GoodsId.QueueCapInSlimeBank2:
                Cost = () => 7500;
                LimitCondition = () => main.S.QueueInSlimeBank_buyNum2 == 3;
                break;
            case GoodsId.QueueCapInSlimeBank3:
                Cost = () => 7500;
                LimitCondition = () => main.S.QueueInSlimeBank_buyNum3 == 3;
                break;
            case GoodsId.QueueCapInSlimeBank4:
                Cost = () => 20000;
                LimitCondition = () => main.S.QueueInSlimeBank_buyNum4 == 6;
                break;

            case GoodsId.MonsterFluidBundle://500個
                Cost = () => 400;
                LimitCondition = () => false;
                break;
            case GoodsId.MonsterFluidBundle2://10,000個
                Cost = () => 4000;
                LimitCondition = () => false;
                break;

            case GoodsId.AutoLoot:
                Cost = () => 5500;
                LimitCondition = () => main.S.AutoLoot;
                break;

            case GoodsId.SuperRebrth:
                Cost = () => 3000;
                LimitCondition = () => false;
                break;
            case GoodsId.InstantRebirth:
                Cost = () => 1000;
                LimitCondition = () => false;
                break;

            //case GoodsId.AdditionalDailyQuest:
            //    Cost = () => 4700;
            //    LimitCondition = () => main.S.AdditionalDailyQuest_buyNum >=1;
            //    break;
            //case GoodsId.MinumumDailyQuest:
            //    Cost = () => 4700;
            //    LimitCondition = () => main.S.MinimumDailyQuest_buyNum >= 1;
            //    break;
            //case GoodsId.oblivion:
            //    Cost = () => 900;
            //    LimitCondition = () => false;
            //    break;
            case GoodsId.ResetLottery:
                Cost = () => 100;
                LimitCondition = () => false;
                break;
            case GoodsId.ResetRebirthUpgrade:
                Cost = () => 5500;
                LimitCondition = () => false;
                break;

            case GoodsId.ResetSpiritUpgrade:
                Cost = () => 6000;
                LimitCondition = () => false;
                break;
            case GoodsId.InstantSpiritUpgrade:
                Cost = () => 2000;
                LimitCondition = () => false;
                break;



            case GoodsId.MajorTinctureSlime:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureGolem:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureSpider:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureFairy:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureBanana:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureOctobaddie:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.MajorTinctureDistortion:
                Cost = () => 240;
                LimitCondition = () => false;
                break;
            case GoodsId.LegendaryPotion:
                Cost = () => 1000;
                LimitCondition = () => false;
                break;


            case GoodsId.AddDailyQuest1:
                Cost = () => 1500;
                LimitCondition = () => main.S.AddDQ1;
                break;
            case GoodsId.AddDailyQuest2:
                Cost = () => 3500;
                LimitCondition = () => main.S.AddDQ2;
                break;
            case GoodsId.AddDailyQuest3:
                Cost = () => 5500;
                LimitCondition = () => main.S.AddDQ3;
                break;
            case GoodsId.DailyQuestRarity1:
                Cost = () => 5000;
                LimitCondition = () => main.S.RareDQ1;
                break;
            case GoodsId.DailyQuestRarity2:
                Cost = () => 10000;
                LimitCondition = () => main.S.RareDQ2;
                break;

            case GoodsId.ExtraSkillSlot:
                Cost = () => 25000;
                LimitCondition = () => main.S.ExtraSkillSlot;
                break;
            case GoodsId.ExtraGlobalSkillSlot:
                Cost = () => 70000;
                LimitCondition = () => main.S.ExtraGlobalSkillSlot;
                break;
            case GoodsId.ExtraGlobalSkillSlotFirst:
                Cost = () => 35000;
                LimitCondition = () => main.S.ExtraGlobalSkillSlotFirst;
                break;
            case GoodsId.EquipmentSlot:
                Cost = () => 5000;
                LimitCondition = () => main.S.EquipmentSlotNum >= 1;
                break;
            case GoodsId.EquipmentSlot2:
                Cost = () => 5000;
                LimitCondition = () => main.S.EquipmentSlotNum2 >= 1;
                break;
            case GoodsId.EquipmentSlot3:
                Cost = () => 5000;
                LimitCondition = () => main.S.EquipmentSlotNum3 >= 1;
                break;
            case GoodsId.FavoriteEquip:
                Cost = () => 2000;
                LimitCondition = () => main.S.FavoriteEquip;
                break;

            case GoodsId.ExpandAlchemyInventory1:
                Cost = () => 7500;
                LimitCondition = () => main.S.ExpandAlchemyInventory1 >= 1;
                break;
            case GoodsId.ExpandAlchemyInventory2:
                Cost = () => 10000;
                LimitCondition = () => main.S.ExpandAlchemyInventory2 >= 1;
                break;
            case GoodsId.ExpandAlchemyInventory3:
                Cost = () => 12500;
                LimitCondition = () => main.S.ExpandAlchemyInventory3 >= 1;
                break;
            case GoodsId.ExpandAlchemyInventory4:
                Cost = () => 15000;
                LimitCondition = () => main.S.ExpandAlchemyInventory4 >= 1;
                break;


            case GoodsId.NitroMax:
                Cost = () => 450;
                LimitCondition = () => false;
                break;
            case GoodsId.NitroCapUp:
                Cost = () => 4800;
                LimitCondition = () => false;
                break;


            case GoodsId.WaterALL:
                Cost = () => 2500;
                LimitCondition = () => main.S.WaterALL;
                break;
            case GoodsId.AutoExpandAlchemy:
                Cost = () => 6500;
                LimitCondition = () => main.S.AutoExpandAlchemy;
                break;

            case GoodsId.AutoActiveSkill:
                Cost = () => 2000;
                LimitCondition = () => main.S.AutoActiveSkill;
                break;
            case GoodsId.CustomRange:
                Cost = () => 500;
                LimitCondition = () => main.S.CustomRange;
                break;
            case GoodsId.CustomMoveSpeed:
                Cost = () => 500;
                LimitCondition = () => main.S.CustomSpeed;
                break;
            case GoodsId.FavoriteDungeon:
                Cost = () => 500;
                LimitCondition = () => main.S.FavoriteArea;
                break;
            case GoodsId.AllClearEQ:
                Cost = () => 500;
                LimitCondition = () => main.S.AllClearEQ;
                break;
            case GoodsId.SuperQueue:
                Cost = () => 2500;
                LimitCondition = () => main.S.SuperQueue;
                break;
            case GoodsId.SuperQueueForSB:
                Cost = () => 7500;
                LimitCondition = () => main.S.SuperQueueSB;
                break;
            case GoodsId.SuperQueueForAlchemy:
                Cost = () => 7500;
                LimitCondition = () => main.S.isPurchasedSuperQueueAlchemy;
                break;


            case GoodsId.AlchemyLock:
                Cost = () => 1200;
                LimitCondition = () => main.S.AlchemyLock;
                break;

            case GoodsId.SkillSetSave1:
                Cost = () => 7500;
                LimitCondition = () => main.S.SkillSetSave1;
                break;
            case GoodsId.SkillSetSave2:
                Cost = () => 7500;
                LimitCondition = () => main.S.SkillSetSave2;
                break;
            case GoodsId.SkillSetSave3:
                Cost = () => 7500;
                LimitCondition = () => main.S.SkillSetSave3;
                break;
            case GoodsId.SkillSetSave4:
                Cost = () => 7500;
                LimitCondition = () => main.S.SkillSetSave4;
                break;
            case GoodsId.SkillSetSaveLoad:
                Cost = () => 5500;
                LimitCondition = () => main.S.SkillSetSaveLoad;
                break;
            case GoodsId.AutoNitro:
                Cost = () => 8500;
                LimitCondition = () => main.S.AutoNitro;
                break;

            case GoodsId.AutoMaxSkill:
                Cost = () => 2000;
                LimitCondition = () => main.S.AutoMaxSkill;
                break;
            case GoodsId.SuperQueueMemory:
                Cost = () => 1000;
                LimitCondition = () => main.S.SuperQueueMemory;
                break;
            case GoodsId.PersistentSuperQueue:
                Cost = () => 10000;
                LimitCondition = () => main.S.PersistentSuperQueue;
                break;
            case GoodsId.PersistentFavoriteEquip:
                Cost = () => 15000;
                LimitCondition = () => main.S.PersistentFavoriteEquip;
                break;

            case GoodsId.RainbowFish:
                Cost = () => 7500;
                LimitCondition = () => main.S.isReinbowFishPurchase;
                break;
            case GoodsId.GemProduction:
                Cost = () => 7500;
                LimitCondition = () => main.S.isDarkRitualPurchase;
                break;
            case GoodsId.ExpMulti1:
                Cost = () => 7500;
                LimitCondition = () => main.S.isEXPMulti1;
                break;
            case GoodsId.ExpMulti2:
                Cost = () => 7500;
                LimitCondition = () => main.S.isEXPMulti2;
                break;
            case GoodsId.MonsterGoldCap1:
                Cost = () => 5000;
                LimitCondition = () => main.S.isMonsterGoldCap1;
                break;
            case GoodsId.MonsterGoldCap2:
                Cost = () => 5000;
                LimitCondition = () => main.S.isMonsterGoldCap2;
                break;
            case GoodsId.MonsterGoldCap3:
                Cost = () => 5000;
                LimitCondition = () => main.S.isMonsterGoldCap3;
                break;
            case GoodsId.MonsterGoldCap4:
                Cost = () => 5000;
                LimitCondition = () => main.S.isMonsterGoldCap4;
                break;

            case GoodsId.TimeWarp2:
                Cost = () => 800;
                LimitCondition = () => main.S.isPurchasedTodayTimeWarp2;
                break;
            case GoodsId.TimeWarp4:
                Cost = () => 1500;
                LimitCondition = () => main.S.isPurchasedTodayTimeWarp4;
                break;
            case GoodsId.TimeWarp8:
                Cost = () => 2500;
                LimitCondition = () => main.S.isPurchasedTodayTimeWarp8;
                break;
            case GoodsId.TimeWarp24:
                Cost = () => 5000;
                LimitCondition = () => main.S.isPurchasedTodayTimeWarp24;
                break;
            default:
                Cost = () => 0;
                LimitCondition = () => false;
                break;
        }
    }


    void Buy()
    {
        if (main.epicShop.totalEpicCoin() < Cost())
            return;

        switch (goodsId)
        {
            case GoodsId.QueueCap1:
                main.S.Queue1_buyNum = 5;
                main.queueController.queue += 5;
                break;
            case GoodsId.QueueCap2:
                main.S.Queue2_buyNum = 5;
                main.queueController.queue += 5;
                break;
            case GoodsId.QueueCap3:
                main.S.Queue3_buyNum = 5;
                main.queueController.queue += 5;
                break;
            case GoodsId.QueueCap4:
                main.S.Queue4_buyNum = 10;
                main.queueController.queue += 10;
                break;
            case GoodsId.QueueCapInSlimeBank1:
                main.S.QueueInSlimeBank_buyNum1 = 3;
                main.queueController.SBqueue += 3;
                break;
            case GoodsId.QueueCapInSlimeBank2:               
                main.S.QueueInSlimeBank_buyNum2 = 3;
                main.queueController.SBqueue += 3;
                break;
            case GoodsId.QueueCapInSlimeBank3:
                main.S.QueueInSlimeBank_buyNum3 = 3;
                main.queueController.SBqueue += 3;
                break;
            case GoodsId.QueueCapInSlimeBank4:
                main.S.QueueInSlimeBank_buyNum4 = 6;
                main.queueController.SBqueue += 6;
                break;


            case GoodsId.MonsterFluidBundle:
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += MonsterFluidBundleNum();
                main.Log("Gained <color=green>Monster Fluid * " + tDigit(MonsterFluidBundleNum()), 5f);
                main.S.MonsterFluidPurchasedNum++;
                UpdateMFText();
                break;

            case GoodsId.MonsterFluidBundle2:
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 10000;
                main.Log("Gained <color=green>Monster Fluid * 10000",5f);
                break;

            case GoodsId.AutoLoot:
                main.S.AutoLoot = true;
                break;

            case GoodsId.SuperRebrth:
                main.S.SuperRebirthNum += 1 ;
                if (!main.S.boughtSuperRebirth)
                    main.S.boughtSuperRebirth = true;
                break;
            case GoodsId.InstantRebirth:
                main.S.InstantRebirthNum += 1 ;
                if (!main.S.boughtInstantRebirth)
                    main.S.boughtInstantRebirth = true;
                break;
            
            
            case GoodsId.AdditionalDailyQuest:
                main.S.AdditionalDailyQuest_buyNum += 1;
                break;
            case GoodsId.MinumumDailyQuest:
                main.S.MinimumDailyQuest_buyNum += 1;
                break;
            case GoodsId.oblivion:
                main.S.OblivionNum += 1;
                break;

            case GoodsId.ResetLottery:
                main.StatusUpgrade[6].level = 0;
                main.SR.R_HP = 0;
                main.SR.R_MP = 0;
                main.SR.R_ATK = 0;
                main.SR.R_DEF = 0;
                main.SR.R_MATK = 0;
                main.SR.R_MDEF = 0;
                main.SR.R_SPD = 0;
                main.SR.R_GOLD = 0;
                main.SR.R_EXP = 0;
                main.SR.R_stone = 0;
                main.SR.R_crystal = 0;
                main.SR.R_leaf = 0;
                main.SR.R_drop = 0;
                break;
            case GoodsId.ResetRebirthUpgrade:
                main.S.ResetRebirthUpgradeNum += 1;
                main.S.boughtResetRebirth = true;
                break;

            case GoodsId.ResetSpiritUpgrade:
                main.S.ResetReincarnationUpgradeNum += 1;
                break;
            case GoodsId.InstantSpiritUpgrade:
                main.S.InstantReincarnationNum += 1;
                break;


            case GoodsId.MajorTinctureSlime:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureGolem:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureSpider:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureFairy:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureBanana:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureOctobaddie:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum = 0;
                break;
            case GoodsId.MajorTinctureDistortion:
                main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum = 0;
                break;
            case GoodsId.LegendaryPotion:
                foreach (var quest in main.QuestCtrl.Quests)
                {
                    quest.clearedNum = 0;
                }
                break;

            case GoodsId.AddDailyQuest1:
                main.TutorialController.DailyQuest[1].GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.AddDQ1 = true;
                break;
            case GoodsId.AddDailyQuest2:
                main.TutorialController.DailyQuest[2].GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.AddDQ2 = true;
                break;
            case GoodsId.AddDailyQuest3:
                main.TutorialController.DailyQuest[3].GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.AddDQ3 = true;
                break;
            case GoodsId.DailyQuestRarity1:
                main.S.RareDQ1 = true;
                main.TutorialController.DailyQuestRarity();
                break;
            case GoodsId.DailyQuestRarity2:
                main.S.RareDQ2 = true;
                main.TutorialController.DailyQuestRarity();
                break;

            case GoodsId.ExtraSkillSlot:
                main.S.ExtraSkillSlot = true;
                main.skillSetController.UnleashSkillSlot();
                StartCoroutine(main.InstantiateLogText("Extra Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                break;
            case GoodsId.ExtraGlobalSkillSlot:
                main.S.ExtraGlobalSkillSlot = true;
                main.skillSetController.UnleashGrobalSkillSlot();
                StartCoroutine(main.InstantiateLogText("Extra Global Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                break;
            case GoodsId.ExtraGlobalSkillSlotFirst:
                main.S.ExtraGlobalSkillSlotFirst = true;
                main.skillSetController.UnleashGrobalSkillSlot();
                StartCoroutine(main.InstantiateLogText("Extra Global Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                break;

            case GoodsId.EquipmentSlot:
                main.S.EquipmentSlotNum += 1;
                break;
            case GoodsId.EquipmentSlot2:
                main.S.EquipmentSlotNum2 += 1;
                break;
            case GoodsId.EquipmentSlot3:
                main.S.EquipmentSlotNum3 += 1;
                break;

            case GoodsId.FavoriteEquip:
                main.S.FavoriteEquip = true;
                break;

            case GoodsId.ExpandAlchemyInventory1:
                main.S.ExpandAlchemyInventory1 = 1;
                break;
            case GoodsId.ExpandAlchemyInventory2:
                main.S.ExpandAlchemyInventory2 = 1;
                break;
            case GoodsId.ExpandAlchemyInventory3:
                main.S.ExpandAlchemyInventory3 = 1;
                break;
            case GoodsId.ExpandAlchemyInventory4:
                main.S.ExpandAlchemyInventory4 = 1;
                break;

            case GoodsId.NitroMax:
                main.S.CurrentNitro = main.NitroCharger.NitroCap();
                break;
            case GoodsId.NitroCapUp:
                main.S.NitroCapUpNum += 1;
                break;

            case GoodsId.WaterALL:
                main.S.WaterALL = true;
                break;
            case GoodsId.AutoExpandAlchemy:
                main.S.AutoExpandAlchemy = true;
                break;

            case GoodsId.AutoActiveSkill:
                main.toggles[11].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.AutoActiveSkill = true;
                break;
            case GoodsId.CustomRange:
                main.toggles[10].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.CustomRange = true;
                break;
            case GoodsId.CustomMoveSpeed:
                main.toggles[14].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.CustomSpeed = true;
                break;
            case GoodsId.FavoriteDungeon:
                main.S.FavoriteArea = true;
                break;
            case GoodsId.AllClearEQ:
                main.craftCtrl.allClearEQbutton.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.AllClearEQ = true;
                break;

            case GoodsId.SuperQueue:
                main.S.SuperQueue = true;
                break;
            case GoodsId.SuperQueueForSB:
                main.S.SuperQueueSB = true;
                break;
            case GoodsId.SuperQueueForAlchemy:
                main.S.isPurchasedSuperQueueAlchemy = true;
                break;

            case GoodsId.AlchemyLock:
                main.S.AlchemyLock = true;
                break;

            case GoodsId.SkillSetSave1:
                main.S.SkillSetSave1 = true;
                if (main.S.SkillSetSaveBuyNum == 0)
                    main.S.SkillSetSaveBuyNum++;
                main.S.SkillSetSaveBuyNum++;
                main.skillSetController.SkillSetSaveButtonActivate();
                foreach (SKILLSET skillslot in main.skillSlotCanvasAry)
                {
                    if(skillslot.canEquipped)
                        skillslot.SkillSetSave();
                }
                break;
            case GoodsId.SkillSetSave2:
                main.S.SkillSetSave2 = true;
                if (main.S.SkillSetSaveBuyNum == 0)
                    main.S.SkillSetSaveBuyNum++;
                main.S.SkillSetSaveBuyNum++;
                main.skillSetController.SkillSetSaveButtonActivate();
                foreach (SKILLSET skillslot in main.skillSlotCanvasAry)
                {
                    if (skillslot.canEquipped)
                        skillslot.SkillSetSave();
                }
                break;
            case GoodsId.SkillSetSave3:
                main.S.SkillSetSave3 = true;
                if (main.S.SkillSetSaveBuyNum == 0)
                    main.S.SkillSetSaveBuyNum++;
                main.S.SkillSetSaveBuyNum++;
                main.skillSetController.SkillSetSaveButtonActivate();
                foreach (SKILLSET skillslot in main.skillSlotCanvasAry)
                {
                    if (skillslot.canEquipped)
                        skillslot.SkillSetSave();
                }
                break;
            case GoodsId.SkillSetSave4:
                main.S.SkillSetSave4 = true;
                if (main.S.SkillSetSaveBuyNum == 0)
                    main.S.SkillSetSaveBuyNum++;
                main.S.SkillSetSaveBuyNum++;
                main.skillSetController.SkillSetSaveButtonActivate();
                foreach (SKILLSET skillslot in main.skillSlotCanvasAry)
                {
                    if (skillslot.canEquipped)
                        skillslot.SkillSetSave();
                }
                break;
            case GoodsId.SkillSetSaveLoad:
                main.S.SkillSetSaveLoad = true;
                foreach (SKILLSET skillslot in main.skillSlotCanvasAry)
                {
                    if (skillslot.canEquipped)
                        skillslot.SkillSetSave();
                }
                break;
            case GoodsId.AutoNitro:
                main.S.AutoNitro = true;
                break;
            case GoodsId.AutoMaxSkill:
                main.S.AutoMaxSkill = true;
                break;
            case GoodsId.SuperQueueMemory:
                main.S.SuperQueueMemory = true;
                break;

            case GoodsId.RainbowFish:
                main.S.isReinbowFishPurchase = true;
                break;
            case GoodsId.GemProduction:
                main.S.isDarkRitualPurchase = true;
                break;
            case GoodsId.ExpMulti1:
                main.S.isEXPMulti1 = true;
                break;
            case GoodsId.ExpMulti2:
                main.S.isEXPMulti2 = true;
                break;
            case GoodsId.MonsterGoldCap1:
                main.S.isMonsterGoldCap1 = true;
                main.S.monsterGoldCapFactor++;
                break;
            case GoodsId.MonsterGoldCap2:
                main.S.isMonsterGoldCap2 = true;
                main.S.monsterGoldCapFactor++;
                break;
            case GoodsId.MonsterGoldCap3:
                main.S.isMonsterGoldCap3 = true;
                main.S.monsterGoldCapFactor++;
                break;
            case GoodsId.MonsterGoldCap4:
                main.S.isMonsterGoldCap4 = true;
                main.S.monsterGoldCapFactor++;
                break;

            case GoodsId.PersistentSuperQueue:
                main.S.PersistentSuperQueue = true;
                break;
            case GoodsId.PersistentFavoriteEquip:
                main.S.PersistentFavoriteEquip = true;
                break;

            case GoodsId.TimeWarp2:
                main.idleBackGround.OfflineBonus(2f * 60 * 60);
                main.S.isPurchasedTodayTimeWarp2 = true;
                break;
            case GoodsId.TimeWarp4:
                main.idleBackGround.OfflineBonus(4f * 60 * 60);
                main.S.isPurchasedTodayTimeWarp4 = true;
                break;
            case GoodsId.TimeWarp8:
                main.idleBackGround.OfflineBonus(8f * 60 * 60);
                main.S.isPurchasedTodayTimeWarp8 = true;
                break;
            case GoodsId.TimeWarp24:
                main.idleBackGround.OfflineBonus(24f * 60 * 60);
                main.S.isPurchasedTodayTimeWarp24 = true;
                break;
        }

        main.S.ECconsumed += Cost();
    }

    public TextMeshProUGUI[] MonsterFluidTexts;
    public int MonsterFluidBundleNum()
    {
        return 500 * MonsterFluidLevel();
    }
    public int MonsterFluidLevel()
    {
        return Math.Min(1 + main.S.MonsterFluidPurchasedNum, 100);
    }
    public void UpdateMFText()
    {
        MonsterFluidTexts[0].text = "Monster Fluid Bundle x" + MonsterFluidLevel().ToString();
        MonsterFluidTexts[1].text = "<color=green>x" + MonsterFluidLevel().ToString();
        MonsterFluidTexts[2].text = "You can instantly gain <color=green>" + MonsterFluidBundleNum().ToString() + "</color> Monster Fluid. <color=orange>( The amount increases every purchase )";
        MonsterFluidTexts[3].text = "Purchased : <color=green>"+ main.S.MonsterFluidPurchasedNum.ToString() + "</color> / 99";
    }
    private void Start()
    {
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "<sprite=0> " + tDigit(Cost());
        if (goodsId == GoodsId.MonsterFluidBundle)
            UpdateMFText();
    }
   
    // Update is called once per frame
    void Update () {

        if(main.epicShop.totalEpicCoin() >= Cost() && !LimitCondition())
            buyButton.GetComponent<Button>().interactable = true;
        else
            buyButton.GetComponent<Button>().interactable = false;
        if (LimitCondition())
            setActive(unleashed);
        else
            setFalse(unleashed);
    }
}
