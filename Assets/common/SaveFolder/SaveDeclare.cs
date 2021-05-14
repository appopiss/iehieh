using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static UsefulStatic;

/// <summary>
/// 主にsaveしたい配列の初期化を行うクラス
/// InitializeArray(ref main.SR.hoge, サイズ);
/// のようにして初期化する。アップデートなどで途中から変更することも可能。
/// 初期化はAwake()のAwakeBASE();のあとに書くことを推奨。
/// </summary>
public class SaveDeclare : BASE
{
	// Use this for initialization/
	void Awake () {
		StartBASE();
        InitializeArray(ref main.SR.currentSkill, 40);
        InitializeArray(ref main.SR.currentGrobalSkill, 40);
        InitializeArray(ref main.S.materialNum, 200);
        InitializeArray(ref main.S.condition, 100);
        //InitializeArray(ref main.S.condition2, 100);
        InitializeArray(ref main.S.leftTime2, 100);
        InitializeArray(ref main.S.leftTime, 100);
        InitializeArray(ref main.S.isEquipped, 100);
        InitializeArray(ref main.S.isFavoriteEquipped, 100);
        InitializeArray(ref main.SR.isEquippedforRemember, 100);
        InitializeArray(ref main.S.level, 100);
        InitializeArray(ref main.S.isUnlocked, 100);
        InitializeArray(ref main.SR.isDungeon, 100);
        InitializeArray(ref main.SR.dungeonPlayTime, 100);
        InitializeArray(ref main.S.maxDungeonFloorNum, 100);
        InitializeArray(ref main.S.dungeonPlayTime, 100);
        //InitializeArray(ref main.S.canEquipped, 30);

        //InitializeArray(ref main.S.A_level, 100);
        InitializeArray(ref main.SR.R_materials, 200);
        InitializeArray(ref main.SR.RC_materials, 200);
        InitializeArray(ref main.SR.saveSkillId, 40);
        InitializeArray(ref main.S.WarSaveSkillId1, 40);
        InitializeArray(ref main.S.WarSaveSkillId2, 40);
        InitializeArray(ref main.S.WarSaveSkillId3, 40);
        InitializeArray(ref main.S.WarSaveSkillId4, 40);
        InitializeArray(ref main.S.WarSaveSkillId5, 40);
        InitializeArray(ref main.S.WizSaveSkillId1, 40);
        InitializeArray(ref main.S.WizSaveSkillId2, 40);
        InitializeArray(ref main.S.WizSaveSkillId3, 40);
        InitializeArray(ref main.S.WizSaveSkillId4, 40);
        InitializeArray(ref main.S.WizSaveSkillId5, 40);
        InitializeArray(ref main.S.AngSaveSkillId1, 40);
        InitializeArray(ref main.S.AngSaveSkillId2, 40);
        InitializeArray(ref main.S.AngSaveSkillId3, 40);
        InitializeArray(ref main.S.AngSaveSkillId4, 40);
        InitializeArray(ref main.S.AngSaveSkillId5, 40);

        InitializeArray(ref main.SR.saveGrobalSkillId, 40);
        InitializeArray(ref main.S.storedNum, 100);
        InitializeArray(ref main.SR.currentWorkerNum, 20);
        InitializeArray(ref main.S.JemLevel, 20);
        InitializeArray(ref main.S.CurrentExp, 20);
        InitializeArray(ref main.S.isJemUnlocked, 20);

        //SuperQueue
        InitializeArray(ref main.S.isSuperQueueAssignedforStoneUpgrade, 10);
        InitializeArray(ref main.S.isSuperQueueAssignedforCrystalUpgrade, 10);
        InitializeArray(ref main.S.isSuperQueueAssignedforLeafUpgrade, 10);
        InitializeArray(ref main.S.isSuperQueueAssignedforStatusUpgrade, 10);
        InitializeArray(ref main.S.isSuperQueueSBAssigned, 100);
        //SuperRebirth
        InitializeArray(ref main.S.stoneUpgradeLevel, 10);
        InitializeArray(ref main.S.crystalUpgradeLevel, 10);
        InitializeArray(ref main.S.leafUpgradeLevel, 10);
        InitializeArray(ref main.S.statusUpgradeLevel, 10);
        InitializeArray(ref main.S.currentWorkerNum, 20);

        //Reincarnation
        InitializeArray(ref main.saveWar.canGetExp, 20);
        InitializeArray(ref main.saveWar.SkillLevel, 20);
        InitializeArray(ref main.saveWar.exp, 20);

        InitializeArray(ref main.saveWiz.canGetExp, 20);
        InitializeArray(ref main.saveWiz.SkillLevel, 20);
        InitializeArray(ref main.saveWiz.exp, 20);

        InitializeArray(ref main.saveAng.canGetExp, 20);
        InitializeArray(ref main.saveAng.SkillLevel, 20);
        InitializeArray(ref main.saveAng.exp, 20);
        InitializeArray(ref main.S.mode, 100);
        InitializeArray(ref main.S.clearNum, 100);
        InitializeArray(ref main.S.Q_upgradeLevel, 100);
        InitializeArray(ref main.S.isS_treasureHunt, 10);
        InitializeArray(ref main.S.isS_errand, 10);
        InitializeArray(ref main.S.isS_slimeLover, 10);
        InitializeArray(ref main.S.isS_merciless, 10);
        InitializeArray(ref main.S.evolutionNum, 100);
        InitializeArray(ref main.S.M_isCleared, 384*2);
        InitializeArray(ref main.S.M_isClearedAfterReincarnation, 384*2);
        InitializeArray(ref main.S.M_materialNum, 384*2);
        InitializeArray(ref main.S.M_capturedNum, 384*2);
        InitializeArray(ref main.S.D_spendTime, 100*2);
        InitializeArray(ref main.S.Slot_canEquipped, 9);
        InitializeArray(ref main.S.SlotG_canEquipped, 20);
        InitializeArray(ref main.S.dungeonClearNum, 100*2);
        InitializeArray(ref main.S.dungeonClearNumForMission, 100*2);
        InitializeArray(ref main.S.toggleSave, 20);
        InitializeArray(ref main.S.DailyQuestSavedDate, 4);
        InitializeArray(ref main.S.isQuestInstantiated, 4);
        InitializeArray(ref main.S.isClearedToday, 4);
        InitializeArray(ref main.S.dailyQuestInfoId, 4);
        InitializeArray(ref main.S.rarity, 4);
        InitializeArray(ref main.S.questKind, 4);
        InitializeArray(ref main.S.targetEnemy, 4);
        InitializeArray(ref main.S.targetMaterial, 4);
        InitializeArray(ref main.S.keyItemNum, Enum.GetNames(typeof(KEYITEM.ArtifactId)).Length);
        InitializeArray(ref main.S.key_isUnlocked, Enum.GetNames(typeof(KEYITEM.ArtifactId)).Length);
        InitializeArray(ref main.S.chestNum, 8);
        InitializeArray(ref main.S.isMissionCompleted, 100*2);
        InitializeArray(ref main.S.isMissionCompletedAfterReincarnation, 100*2);
        InitializeArray(ref main.S.MissionClearNumAfterReincarnation, 384*2);
        // InitializeArray(ref main.S.requiredEnemy, 3);
        // InitializeArray(ref main.S.requiredMaterial, 3);
        InitializeArray(ref main.S.defeatedEnemyNum, 200);
        InitializeArray(ref main.S.getheredMaterialNum, Enum.GetNames(typeof(ArtiCtrl.MaterialList)).Length);
        //InitializeArray(ref main.S.TodaysDailyQuestId, 3);

        //EnemyDefeatedNum
        InitializeArray(ref main.S.totalEnemiesKilled, 200);
        InitializeArray(ref main.S.totalEnemiesKilledAfterReincarnation, 200);
        InitializeArray(ref main.S.totalEnemiesCaptured, 200);
        InitializeArray(ref main.S.timeToLoot, 200);

        InitializeArray(ref main.SR.waterCap, 14);
        InitializeArray(ref main.SR.currentWater, 14);
        InitializeArray(ref main.SR.waterValue, 14);
        InitializeArray(ref main.S.SwaterCap, 14);
        InitializeArray(ref main.S.ScurrentWater, 14);
        InitializeArray(ref main.S.SwaterValue, 14);
        InitializeArray(ref main.S.leftItems, 32);
        InitializeArray(ref main.S.leftItemsQuality, 32);
        InitializeArray(ref main.S.leftItemsIsLock, 32);
        InitializeArray(ref main.S.isUnlockedAlchemy, 100);
        InitializeArray(ref main.S.isMissionMileStone, 30);
        InitializeArray(ref main.S.isMissionMileStoneHidden, 35);
        InitializeArray(ref main.S.isSuperQueuedAlchemy, 50 * 20);

        /* ConsumeItem */
        InitializeArray(ref main.S.consumeItemNum, Enum.GetNames(typeof(ArtiCtrl.ConsumeItemList)).Length);
        InitializeArray(ref main.S.isDropped, Enum.GetNames(typeof(ArtiCtrl.MaterialList)).Length);
        InitializeArray(ref main.S.BankUpgradeLevel, 100);

        //CurseRein
        InitializeArray(ref main.S.CurseReinClearNum, Enum.GetNames(typeof(CurseId)).Length);

        //Expedition
        InitializeArray(ref main.S.expedition, Enum.GetNames(typeof(ExpeditionKind)).Length);

        //SteamAchievement
        InitializeArray(ref main.S.isAchievedSteam, 24);
        InitializeArray(ref main.S.isPurchasedIEBBonus, 23);
    }

    // Use this for initialization
    void Start () {

	}
}
