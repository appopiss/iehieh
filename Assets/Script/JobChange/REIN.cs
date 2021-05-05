    using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;

public class REIN : BASE {

    public TextMeshProUGUI ReincarnationNumText;
    public TextMeshProUGUI RPtext;
    public Button ReincarnationButton;
    public Button ToReincarnation;
    public Button ToRebirth;
    public Button ResetReincarnation;
    public Button InstantReincarnation;
    public GameObject rebirthCanvas;
    public GameObject reincarnationCanvas;
    public R_UPGRADE[] R_upgrades;
    public R_UPGRADE[] SR_upgrades;
    public ReinFactor R_factor;
    public ReinWindow reinWindow;
    public Button ResetButton;
    public TextMeshProUGUI SRPtext;
    public Transform R_upgradeCanvas;
    public long currentSavedRP;
    public long currentSavedSRP;

	// Use this for initialization
	void Awake () {
		StartBASE();
        ReincarnationButton.onClick.AddListener(confirmReincarn);
        ToReincarnation.onClick.AddListener(Open);
        ToRebirth.onClick.AddListener(Close);
        //StartCoroutine(updatePointText());
	}
    void confirmReincarn()
    {
        Instantiate(main.P_texts[35], main.DeathShowCanvas);
    }
    void confirmResetReincarnation()
    {
        Instantiate(main.P_texts[36], main.DeathShowCanvas);
    }
    void confirmInstantReincarnation()
    {
        Instantiate(main.P_texts[38], main.DeathShowCanvas);
    }



    // Use this for initialization
    void Start () {
        //リセットする
        ResetButton.onClick.AddListener(ResetAssignment);
        ResetReincarnation.onClick.AddListener(confirmResetReincarnation);
        InstantReincarnation.onClick.AddListener(confirmInstantReincarnation);
        if (main.S.ReincarnationNum>=1)
            Application.ExternalCall("kongregate.stats.submit", "ReinNum", main.S.ReincarnationNum);

    }

    public void ResetAssignment()
    {
        foreach (R_UPGRADE upgrade in main.rein.R_upgrades)
        {
            upgrade.tempLevel = main.S.R_level[(int)upgrade.R_thisId];
        }
        foreach (R_UPGRADE upgrade in main.rein.SR_upgrades)
        {
            upgrade.tempLevel = main.S.SR_level[(int)upgrade.SR_thisId];
        }
        main.tempRP = main.S.RP;
        currentSavedRP = main.S.RP;
        main.tempSRP = main.RPmanager.SpiritEssence();
        currentSavedSRP = main.RPmanager.SpiritEssence();
    }

    public void Open()
    {
        reincarnationCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000);
        //オープンした時にmaterial pointをアップデート
        RPmanager.UpdateMaterialPoint();
        ResetAssignment();
        //main.GameController.SetAllImageAndText(reincarnationCanvas, true);
        //main.GameController.SetAllImageAndText(rebirthCanvas, false);
    }
    public void Close()
    {
        reincarnationCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -1000);
        //main.GameController.SetAllImageAndText(reincarnationCanvas, false);
        //main.GameController.SetAllImageAndText(rebirthCanvas, true);
    }

    // Update is called once per frame
    void Update () {
        //ReincarnationNumText.text = ReinNumText();
        if (main.GameController.currentCanvas == main.GameController.JobchangeCanvas)
        {
            RPtext.text = RPText();
            SRPtext.text = SRPText();
            if (main.S.ResetReincarnationUpgradeNum > 0)
                ResetReincarnation.interactable = true;
            else
                ResetReincarnation.interactable = false;
            if (main.S.InstantReincarnationNum > 0)
                InstantReincarnation.interactable = true;
            else
                InstantReincarnation.interactable = false;

        }
        if (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].isCleared)
            ReincarnationButton.interactable = true;
        else
            ReincarnationButton.interactable = false;
        // Debug.Log("TempRp : " + main.tempRP);
        // Debug.Log("RP : " + main.S.RP);
    }

    //long saveRP;
    //long saveSRP;
    //IEnumerator updatePointText()
    //{
    //    while (true)
    //    {
    //        saveRP = main.S.RP;
    //        saveSRP = main.RPmanager.SpiritEssence();
    //        yield return new WaitUntil(() => main.S.RP > saveRP || main.RPmanager.SpiritEssence() > saveSRP);
    //        main.tempRP += Math.Max(main.S.RP - saveRP, 0);
    //        main.tempSRP += Math.Max(main.RPmanager.SpiritEssence() - saveSRP, 0);
    //        yield return new WaitForSeconds(0.05f);            
    //    }
    //}

    //long GetRP()
    //{
    //    return 1;
    //}
    long SpiritEssenceNum;
    //Reincarnationの処理を書いていく
    void CalculateReincarnatePoint()
    {
        //ポイントを反映させる。
        SpiritEssenceNum = main.RPmanager.SpiritEssence();
        main.S.RP = main.tempRP;
        main.S.SRPfromPrevious += SpiritEssenceNum - (main.S.SRPfromPrevious - main.S.SRPconsumed - main.S.SRPinstantConsumed);//今回の転生で獲得したSE
        main.S.SRPconsumed += (SpiritEssenceNum - main.tempSRP) + main.S.SRPinstantConsumed;//ここ絶対に順番変えちゃダメ！
        main.S.SRPfromEquipment = 0;
        main.S.SRPfromTime = 0;
        main.S.SRPfromRebirth = 0;
        main.S.SRPfromBankCap = 0;
        main.S.SRPfromMaterial = 0;
        main.S.SRPfromMaterialBase = 0;
        main.S.SRPfromMission = 0;
        main.S.SRPfromMontblango = 0;
        main.S.SRPfromQuest = 0;
        main.S.SRPinstantConsumed = 0;
    }
    IEnumerator ResetForReincarnate()
    {
        //裏AreaでなくNormalエリアに
        main.S.isHidden = false;
        //ミッションの回数などをリセット
        foreach (DUNGEON dungeon in main.dungeonAry)
        {
            dungeon.spendTime = 0;
            dungeon.dungeonClearNumForMission = 0;
            dungeon.isMissionCompletedAfterReincarnation = false;
            foreach (MISSION mission in dungeon.GetComponents<MISSION>())
            {
                mission.materialNum = 0;
                mission.capturedNum = 0;
                mission.isClearedAfterReincarnation = false;
            }
        }
        main.S.bigSlimeNumByBase = 0;
        main.S.purpleSlimeNum = 0;
        main.S.metalSlimeNum = 0;
        main.S.metalSlimeNum2 = 0;
        main.S.slimeBossNum = 0;
        main.S.normalBatNum = 0;
        main.S.yellowBatNum = 0;
        main.S.blackBatNum = 0;
        main.S.activeSkillAt15 = 0;
        main.S.eatSandwich = false;
        //リバースアップグレード
        for (int i = 0; i < main.S.A_level.Length; i++)
        {
            main.S.A_level[i] = 0;
        }
        main.S.WarP = 0;
        main.S.WizP = 0;
        main.S.AngP = 0;
        main.S.consumedAngP = 0;
        main.S.consumedWarP = 0;
        main.S.consumedWizP = 0;
        //GlobalSkillSlotもリバースによるものはリセット
        main.skillSetController.ResetGrobalSkillSlot();
        //SkillSlotのリセット
        main.skillSetController.ResetSkillSlot();
        //SkillSlotSaveのリセット
        main.S.SkillSetSaveID = 0;
        for (int i = 0; i < main.S.WarSaveSkillId1.Length; i++)
        {
            main.S.WarSaveSkillId1[i] = 0;
            main.S.WarSaveSkillId2[i] = 0;
            main.S.WarSaveSkillId3[i] = 0;
            main.S.WarSaveSkillId4[i] = 0;
            main.S.WarSaveSkillId5[i] = 0;
            main.S.WizSaveSkillId1[i] = 0;
            main.S.WizSaveSkillId2[i] = 0;
            main.S.WizSaveSkillId3[i] = 0;
            main.S.WizSaveSkillId4[i] = 0;
            main.S.WizSaveSkillId5[i] = 0;
            main.S.AngSaveSkillId1[i] = 0;
            main.S.AngSaveSkillId2[i] = 0;
            main.S.AngSaveSkillId3[i] = 0;
            main.S.AngSaveSkillId4[i] = 0;
            main.S.AngSaveSkillId5[i] = 0;
        }
        //Stanceのリセット
        main.S.P_SwordAttack = false;
        main.S.P_ShieldAttack = false;
        main.S.P_Block = false;
        main.S.P_StaffAttack = main.SR.P_StaffAttack = false;
        main.S.P_fire = false;
        main.S.P_ice = false;
        main.S.P_thunder = false;
        main.S.P_GodBless = false;
        main.S.P_AngelDistruction = false;
        main.S.P_HoldWing = false;
        //Craft系のレベルを全て0に
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (!arti.stayAfterReincarnation)
            {
                if (main.S.PersistentFavoriteEquip && arti.isFavoriteEquipped)
                {
                    arti.level = 1;
                    arti.EvolutionNum = (int)Math.Ceiling(arti.EvolutionNum / 2d);
                }
                else
                {
                    arti.isEquipped = false;
                    arti.isFavoriteEquipped = false;
                    arti.level = 0;
                    arti.EvolutionNum = 0;
                    arti.condition = ARTIFACT.Condition.locked;
                }
            }
        }
        //素材を全部０に
        for (int i = 0; i < main.S.materialNum.Length; i++)
        {
            if(i == (int)ArtiCtrl.MaterialList.WarriorSoul
                || i == (int)ArtiCtrl.MaterialList.WizardSoul
                || i == (int)ArtiCtrl.MaterialList.AngelSoul
                || i == (int)ArtiCtrl.MaterialList.DarkMatter
                || i == (int)ArtiCtrl.MaterialList.ProofOfAngel
                || i == (int)ArtiCtrl.MaterialList.ProofOfWarrior
                || i == (int)ArtiCtrl.MaterialList.ProofOfWizard
                )
            {
                continue;
            }
            main.S.materialNum[i] = 0;
        }
        //SlimeBank系soul
        foreach (B_Upgrade upgrade in main.bankCtrl.BankUpgrades)
        {
            upgrade.level = 0;
        }
        main.S.SlimeCoin = 0;
        main.S.slimeReputation = 0;
        //SuperQueue
        if (!main.S.PersistentSuperQueue)
        {
            for (int i = 0; i < main.StoneUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforStoneUpgrade[i] = false;
            }
            for (int i = 0; i < main.CristalUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforCrystalUpgrade[i] = false;
            }
            for (int i = 0; i < main.LeafUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforLeafUpgrade[i] = false;
            }
            for (int i = 0; i < main.StatusUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforStatusUpgrade[i] = false;
            }
            for (int i = 0; i < main.bankCtrl.BankUpgrades.Length; i++)
            {
                main.S.isSuperQueueSBAssigned[i] = false;
            }
            main.S.Queue_unleashed = 0;
        }

        if (main.S.isMission325Completed)
        {
            main.S.WorkerNum = main.SR.WorkerNum;
            main.S.BuyLevel = main.SR.BuyLevel;
            main.S.CapLevel = main.SR.CapLevel;
            for (int i = 0; i < main.SR.currentWorkerNum.Length; i++)
            {
                main.S.currentWorkerNum[i] = main.SR.currentWorkerNum[i];
            }
        }
        else
        {
            main.S.WorkerNum = 0;
            main.S.BuyLevel = 0;
            main.S.CapLevel = 0;
            //DarkRitual系->全部解禁！
            for (int i = 0; i < main.S.currentWorkerNum.Length; i++)
            {
                main.S.currentWorkerNum[i] = 0;
            }
        }

        //Alchemy
        //AlchemyInventory
        for (int i = 0; i < main.S.leftItems.Length; i++)
        {
            main.S.leftItems[i] = 0;
            main.S.leftItemsQuality[i] = 0;
            main.S.leftItemsIsLock[i] = false;
        }
        //AlchemyPotion解禁
        for (int i = 0; i < main.S.isUnlockedAlchemy.Length; i++)
        {
            main.S.isUnlockedAlchemy[i] = false;
        }
        //AlchemyStats
        main.S.vitalityLevel = 0;
        main.S.vitalityValue = 0;
        main.S.muscleLevel = 0;
        main.S.muscleValue = 0;
        main.S.wisdomLevel = 0;
        main.S.wisdomValue = 0;
        main.S.agilityLevel = 0;
        main.S.agilityValue = 0;
        //AlchemyPoint
        main.S.consumedAlchemyPoint = 0;
        main.S.gainedAlchemyPoint = main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.AlchemyPoint].GetCurrentValue() * main.S.gainedAlchemyPoint;
        //AlchemyAutoの到達リセットしないことにした（ver.1.1.1.0)
        //main.S.maxReachedCap = 0;
        //RebirthNum
        main.S.AscendNumWhileReincarnation = 0;
        main.S.maxLevelReachedWhileReincarnation = 0;
        //Quest系
        foreach (ACHIEVEMENT quest in main.quests)
        {
            if (quest == null)
                continue;
            //if(quest.questType!=ACHIEVEMENT.Type.Permanent)
            quest.clearNum = 0;
            quest.isUnlocked = false;
            quest.mode = ACHIEVEMENT.Mode.locked;
        }
        main.S.RainbowFishClearedNum = 0;
        main.S.isRainbowFish = false;
        main.S.isPurse = false;
        main.S.isPoppy = false;
        //Challenge系
        for (int i = 0; i < main.QuestCtrl.Quests.Length; i++)
        {
            if (i != (int)QuestCtrl.QuestId.distortion)
            {
                main.QuestCtrl.Quests[i].maxClaredNum = 0;
                main.QuestCtrl.Quests[i].isCleared = false;
            }
            main.QuestCtrl.Quests[i].clearedNum = 0;
        }
        //foreach (QUEST quest in main.QuestCtrl.Quests)
        //{
        //    quest.maxClaredNum = 0;
        //    quest.clearedNum = 0;
        //    quest.isCleared = false;
        //}
        //Nitro系→2021.04.15~リセットしなくした
        //main.S.CurrentNitro = 0;
        //Dungeonの到達階層
        for (int i = 0; i < main.S.maxDungeonFloorNum.Length; i++)
        {
            main.S.maxDungeonFloorNum[i] = 0;
        }
        //Areaのクリア回数
        for (int i = 0; i < main.S.dungeonClearNum.Length; i++)
        {
            main.S.dungeonClearNum[i] = 0;
        }
        //Tutorial系のboolを全てfalseにする↓
        main.GameController.isJobbed = false;
        main.GameController.FirstButton = false;
        main.S.job = ALLY.Job.Novice;
        //Upgrade
        main.TutorialController.isUpgradeIcon4 = false;
        main.TutorialController.isUpgradeIcon5 = false;
        main.TutorialController.isUpgradeIcon6 = false;
        main.TutorialController.isUpgradeIcon7 = false;
        main.TutorialController.isUpgradeIcon8 = false;
        main.TutorialController.isUpgradeIcon9 = false;
        main.TutorialController.isUpgradeIcon10 = false;
        main.TutorialController.isUpgradeIcon11 = false;
        main.TutorialController.isUpgradeIcon12 = false;
        main.TutorialController.isUpgradeIcon13 = false;
        main.TutorialController.isUpgradeIcon14 = false;
        main.TutorialController.isUpgradeIcon15 = false;
        main.S.unleashBank = false;
        //main.S.unleashDarkRitual = false;
        yield return null;
    }
    public bool isStartedRein;
    public IEnumerator Reincarnate()
    {
        isStartedRein = true;
        StopCoroutine(main.saveCtrl.save);
        CalculateReincarnatePoint();
        //時間を0にする
        main.S.reincarnationTime = 0;
        main.S.ReincarnationNum++;
        //main.S.RP += GetRP();montblango討伐時に１だけもらえることとする
        //レベルを反映させる。
        foreach (R_UPGRADE upgrade in main.rein.R_upgrades)
        {
            main.S.R_level[(int)upgrade.R_thisId] = upgrade.tempLevel;
            //Debug.Log(upgrade.tempLevel);
        }
        foreach (R_UPGRADE upgrade in main.rein.SR_upgrades)
        {
            main.S.SR_level[(int)upgrade.SR_thisId] = upgrade.tempLevel;
        }
        yield return StartCoroutine(ResetForReincarnate());
        //カースモードを代入する
        main.cc.CurrentCurseId = main.cc.InputCurseId;
        if (main.cc.InputCurseId == CurseId.curse_of_angel3 ||
             main.cc.InputCurseId == CurseId.curse_of_warrior3 ||
            main.cc.InputCurseId == CurseId.curse_of_wizard3)
            main.S.isHidden = true;
        main.toggles[6].isOn = true;
        main.S.toggleSave[6] = true;//AutoProgressは常にON
        yield return null;
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(1f);
        //消す処理
        PlayerPrefs.DeleteKey(keyList.resetSaveKey);
        PlayerPrefs.DeleteKey(keyList.Wiz_saveKey);
        PlayerPrefs.DeleteKey(keyList.War_saveKey);
        PlayerPrefs.DeleteKey(keyList.Ang_saveKey);

        SceneManager.LoadScene("main");
    }

    //string ReinNumText()
    //{
    //    StringBuilder tempText = new StringBuilder();
    //    tempText.Append("Number of Reincarnation     ");
    //    tempText.Append(tDigit(main.S.ReincarnationNum));
    //    return tempText.ToString();
    //}
    string RPText()
    {
        StringBuilder tempText = new StringBuilder();
        tempText.Append(tDigit(main.tempRP));
        tempText.Append(" / ");
        tempText.Append(tDigit(currentSavedRP));
        return tempText.ToString();
    }
    string SRPText()
    {
        StringBuilder tempText = new StringBuilder();
        tempText.Append(tDigit(main.tempSRP));
        tempText.Append(" / ");
        tempText.Append(tDigit(currentSavedSRP));
        return tempText.ToString();
    }
}
