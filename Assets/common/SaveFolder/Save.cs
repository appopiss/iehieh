using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public partial class Save
{
    public bool isLanguageGotOnce;//一度でもlanguageを取得したかどうか
    public Language language;
    public long TotalChiliGathered;
    public long TotalReinbowFishGathered;
    //最初に書くやつ
    public bool isAfterReincarnationImplemented; //レインカーネーションがリリースされてからプレイしたか？
    public bool isAfterVer1100;//こっちを使うぜ
    public bool isAfterVer1101;//OctoMaxLeachedの同期
    public bool isAfterVer1102;//hotfix, SEの修正, Challenge Boss Captureの修正
    public bool isAfterVer1103;//ResetSpiritUpgradesの配布
    //public bool isEpicCoinRestored;
    //EpicStore    
    public int Queue1_buyNum;
    public int Queue2_buyNum;
    public int Queue3_buyNum;
    public int Queue4_buyNum;
    public int QueueInSlimeBank_buyNum1;
    public int QueueInSlimeBank_buyNum2;
    public int QueueInSlimeBank_buyNum3;
    public int QueueInSlimeBank_buyNum4;
    public bool AutoLoot;
    public bool boughtSuperRebirth;//初めて買ったときにtrue
    public int SuperRebirthNum;
    public bool boughtInstantRebirth;//初めて買ったときにtrue
    public int ResetRebirthUpgradeNum;
    public int ResetReincarnationUpgradeNum;
    public int InstantReincarnationNum;
    public bool boughtResetRebirth;//初めて買ったときにtrue
    public int InstantRebirthNum;
    public int AdditionalDailyQuest_buyNum;
    public int MinimumDailyQuest_buyNum;
    public int OblivionNum;
    public bool AddDQ1;
    public bool AddDQ2;
    public bool AddDQ3;
    public bool RareDQ1;
    public bool RareDQ2;
    public bool ExtraSkillSlot;
    public bool ExtraGlobalSkillSlot;
    public bool ExtraGlobalSkillSlotFirst;
    public int EquipmentSlotNum;//Kreds1回のみ
    public int EquipmentSlotNum2;//Kreds1回のみ
    public int EquipmentSlotNum3;//Kreds1回のみ
    public bool FavoriteEquip;
    public int ExpandAlchemyInventory1;
    public int ExpandAlchemyInventory2;
    public int ExpandAlchemyInventory3;
    public int ExpandAlchemyInventory4;
    public int EC1, EC2, EC3, EC4, EC5, EC6, EC7, EC8;
    public int ECF1, ECF2, ECF3, ECF4, ECF5, ECF6, ECS1, ECS2, ECS3, ECS4;
    //５倍を入れておく↓
    public int ECC1;
    public int AP1, APconsumed;
    public bool isDailyAP;
    public int dailyECnum;
    public float nitroExplosionTimeLeft;
    public long NitroCapUpNum;
    public bool isNitro;
    public double GoldCapByKreds;
    public bool WaterALL;
    public bool AutoExpandAlchemy;
    public bool AutoActiveSkill;
    public bool CustomRange;
    public bool CustomSpeed;
    public bool FavoriteArea;
    public bool AllClearEQ;
    public bool SuperQueue;
    public bool SuperQueueSB;
    public bool AlchemyLock;
    public bool SkillSetSave1;
    public bool SkillSetSave2;
    public bool SkillSetSave3;
    public bool SkillSetSave4;
    public int SkillSetSaveBuyNum;
    public bool SkillSetSaveLoad;
    public bool AutoNitro;
    public bool AutoMaxSkill;
    public bool SuperQueueMemory;
    public bool PersistentSuperQueue;
    public bool PersistentFavoriteEquip;
    public bool isReinbowFishPurchase;
    public bool isDarkRitualPurchase;
    public bool isEXPMulti1;
    public bool isEXPMulti2;
    
    public bool isMonsterGoldCap1;
    public bool isMonsterGoldCap2;
    public bool isMonsterGoldCap3;
    public bool isMonsterGoldCap4;
    public int monsterGoldCapFactor;
    public int MonsterFluidPurchasedNum;
    public bool isPurchasedSuperQueueAlchemy;

    //BonusCode
    public bool BC1IEHhapiwaku;
    public bool BC2IEHmonthlycontest;
    public bool BC3IEHhapiwakuMay;
    public bool BC7IEHhapiwakuJune;
    public bool BC8IEHhapiwakuJuly;
    public bool BC9IEHhapiwakuAugustKong;//Kongではこっち
    public bool BC9IEHhapiwakuAugustArmorGames;//ArmorGamesではこっ
    public bool BC10IEHhapiwakuSeptemberKong;
    public bool BC10IEHhapiwakuSeptemberArmorGames;
    public bool BC11IEHhapiwakuOctoberKong;
    public bool BC11IEHhapiwakuOctoberArmorGames;
    public bool BC4IEHoctobaddie30;
    public bool BC5IEHoctobaddie3;
    public bool BC6IEHoctobaddie1;
    public bool BCSteam;
    public bool isInstalledYC;
    public bool BCYC;
    public bool BCanniversary;
    public int octoMaxReachedLevel;
    //public int MajorPotionNum;
    //public int PotentPotionNum;
    //KeyItem
    public int[] keyItemNum;
    public bool[] key_isUnlocked;
    public int[] chestNum;
    //RebirthUpgrade
    public long consumedWarP;
    public long consumedWizP;
    public long consumedAngP;
    //ここまで
    public int slimeReputation;
    public long ECbyMission;//x5する前の値
    public long ECbyMissionHidden;//x5する前
    public long ECbyKreds;//x50する前の値
    public long ECbyQuest;//x10する前の値
    public long ECbyDailyQuest;//x5する前の値
    public long ECconsumed;//支払った累計のEC
    public long ECforDebug;//x70000
    public long ECbyRestoredMission;//Missionバグでリストアする分
    public long ECbyLocalSave;//LocalSaveによる+30/30
    //public long EpicCoin;
    public bool[] Slot_canEquipped;
    public bool[] SlotG_canEquipped;
    public bool[] isDropped;
    public float CurrentNitro;
    public bool isAutoNitro;
    public int[] BankUpgradeLevel;
    //CurseRein
    public int[] CurseReinClearNum;
    public CurseId CurrentCurseId;


    //PassiveSkills
    public bool P_SwordAttack, P_ShieldAttack, P_Block;
    public bool P_StaffAttack, P_fire, P_ice, P_thunder;
    public bool P_GodBless, P_AngelDistruction, P_HoldWing;

    //補填・配布等
    public bool isDistributedResetRebirth;//ResetUpgradeTicket20200424
    //public bool isNewIEH;
    public bool isNewReleasedIEH;
    public int[] dungeonClearNum;
    public int[] dungeonClearNumForMission;
    public bool[] isMissionCompleted;
    public bool[] isMissionCompletedAfterReincarnation;
    public bool[] isMissionMileStone;
    public bool[] isMissionMileStoneHidden;

    public bool isMission325Completed;
    public bool isMission384Completed;
    public bool[] toggleSave;
    //ポーションの数
    public long HpPotion;
    public long MpPotion;
    public long CurePotion;
    public long SpicyPotion;
    public long ExpPotion;
    public long GoldPotion;
    public long DropPotion;
    public long PoisonBanana;
    public long Trap;
    //public int EquipmentBuyNum;

    public double WalkDistance;

    public double SlimeCoin;
    public double TempStoreSlimeCoin;

    //ミッション
    public int MissionCount;
    public int MissionCountHidden;
    public bool[] M_isCleared;
    public bool[] M_isClearedAfterReincarnation;
    public long[] M_materialNum;
    public long[] M_capturedNum;
    public int[] MissionClearNumAfterReincarnation;
    public double[] D_spendTime;
    public int totalMissionCleared;
    public int totalHeartStoneGot;
    //ミッションクリア条件
    public long bigSlimeNumByBase, hidden_bigSlimeNumByBase;
    public long purpleSlimeNum, hidden_purpleSlimeNum;
    public long metalSlimeNum, hidden_metalSlimeNum;
    public long metalSlimeNum2, hidden_metalSlimeNum2;
    public long slimeBossNum, hidden_slimeBossNum;
    public long normalBatNum, hidden_normalBatNum;
    public long yellowBatNum, hidden_yellowBatNum;
    public long blackBatNum, hidden_blackBatNum;
    public long activeSkillAt15,hidden_activeSkillAt15;

    public double reincarnationTime;
    public string lastTime;
    public string birthDate;
    public bool isContinuePlay;
    public double allTime;
    public double realAllTime;
    public double lastLocalSaveTime;
    public double lastAdsWatchTime;
    public string lastRealTimeOnServer;
    public string dateTimeWhenLastSync;
    public string lastLocalTime;
    public bool initialized_server_time;

    public float SEVolume;
    public float BGMVolume;

    public long ascendPoint;
    public bool isAscend;
    public bool isOnAscendConfirm;
    public bool isDead;
    /* libraryここまで */
    /* ここから永久に保存したい変数をpublicで宣言していく */
    /* 初期化はSave */

    //Temrorary Dungeon time
    public string[] dungeonPlayTime;

    //ReleaseContents
    public bool FirstButton;
    public bool isJobbed;

    //解禁
    //public bool[] canEquipped;
    //チュートリアル
    public bool isUpgrade;
    public bool isSkillTreeOpen;
    public bool isSkillTree;
    public bool isSkillSet;
    public bool isDungeonOpen;
    public bool isSlimeHideoutTryAgainFirst;//スライムダンジョンの達成率を最初だけ0%にするためだけのブール
    public bool isSlimeHideoutClear;
    //グローバルスロット
    public bool isGlobalSlotEquipped;
    public bool isGlobalSlotbyMissionMilestone;
    //クエスト
    public bool isOpenedQuest;
    //ActiveSill
    public bool isWarActiveSkill, isWizActiveSkill, isAngActiveSkill;
    //UPGRADEアイコン
    public bool isUpgradeIcon1;
    public bool isUpgradeIcon2;
    public bool isUpgradeIcon3;
    public bool isUpgradeIcon4;
    public bool isUpgradeIcon5;
    public bool isUpgradeIcon6;
    public bool isUpgradeIcon7;
    public bool isUpgradeIcon8;
    public bool isUpgradeIcon9;
    public bool isUpgradeIcon10;
    public bool isUpgradeIcon11;
    public bool isUpgradeIcon12;
    public bool isUpgradeIcon13;
    public bool isUpgradeIcon14;
    public bool isUpgradeIcon15;
    //ZONE
    public bool isZone1;
    public bool isZone2;
    public bool isZone3;
    public bool isZone4;
    public bool isZone5;
    public bool isZone6;
    public bool isZone7;

    public bool isHidden;//裏エリア
    public bool isUnleashedHidden;

    //最高到達フロア（ランキングやアチーブメントに使う）統計量
    public int maxFloorNum;
    public int maxFloorNum1;
    public int maxFloorNum2;
    public int maxFloorNum3;
    public int maxFloorNum4;
    public int AscendNum;//永遠に累計カウント
    public int AscendNumWhileReincarnation;//今回の転生中のRebierth回数

    public long totalEnemyKilled;
    public long totalSlimeKilled;
    public long[] totalEnemiesKilled = new long[200];
    public long[] totalEnemiesKilledAfterReincarnation;
    public long[] totalEnemiesCaptured;
    public float[] timeToLoot;
    public long totalClickNum;
    public double totalGetStone;
    public double totalGetCrystal;
    public double totalGetLeaf;
    public long totalEnemyCaptured;
    //Challenge Boss
    public long C_totalSlimeKilled;
    public long C_totalFairyKilled;
    public long C_totalGolemKilled;
    public long C_totalBananoonKilled;
    public long C_totalDeathpiderKilled;
    public long C_totalMontblangoKilled;
    public long C_totalDistortionSlimeKilled;
    public long C_totalOctoKilled;
    public bool C_S_isDefeatedOnce, C_F_isDefeatedOnce, C_G_isDefeatedOnce, C_M_isDefeatedOnce, C_D_isDefeatedOnce, C_B_isDefeatedOnce, C_Dis_isDefeatedOnce;
    public bool C_O_isDefeatedOnce;
    //MaxLevelReached
    public long maxLevelReached;
    public long maxLevelReachedWhileReincarnation;
    //SkillLevel
    public ALLY.Job job;
    //Warrior
    public int SLv_wariior;
    public int SLv_slash;
    public int SLv_doubleSlash;
    public int SLv_sonicSlash;
    public int SLv_swingDown;
    public int SLv_swingAround;
    public int SLv_chargeSwing;
    public int SLv_fanSwing;
    public int SLv_shieldAttack;
    public int SLv_block;
    //Wizard
    public int SLv_stuffAttack;
    public int SLv_fireBall;
    public int SLv_fireStorm;
    public int SLv_meteoStrike;
    public int SLv_iceBall;
    public int SLv_chillingTouch;
    public int SLv_blizzard;
    public int SLv_thunderBall;
    public int SLv_doubleThunderBall;
    public int SLv_lightningThunder;
    //Angel
    public int SLv_wingAttack;
    public int SLv_wingShoot;
    public int SLv_heal;
    public int SLv_godBless;
    public int SLv_muscleInflation;
    public int SLv_magicImpact;
    public int SLv_protectWall;
    public int SLv_haste;
    public int SLv_angelDistraction;
    public int SLv_holdWings;

    //SkillProficiency
    //Warrior
    public double SPro_warrior;
    public double SPro_slash;
    public double SPro_doubleSlash;
    public double SPro_sonicSlash;
    public double SPro_swingDown;
    public double SPro_swingAround;
    public double SPro_chargeSwing;
    public double SPro_fanSwing;
    public double SPro_shieldAttack;
    public double SPro_block;
    //Wizard
    public double SPro_stuffAttack;
    public double SPro_fireBall;
    public double SPro_fireStorm;
    public double SPro_meteoStrike;
    public double SPro_iceBall;
    public double SPro_chillingTouch;
    public double SPro_blizzard;
    public double SPro_thunderBall;
    public double SPro_doubleThunderBall;
    public double SPro_lightningThunder;
    //Angel
    public double SPro_wingAttack;
    public double SPro_wingShoot;
    public double SPro_heal;
    public double SPro_godBless;
    public double SPro_muscleInflation;
    public double SPro_magicImpact;
    public double SPro_protectWall;
    public double SPro_haste;
    public double SPro_angelDistraction;
    public double SPro_holdWings;

    //スキルスロットのセーブ
    public int SkillSetSaveID;//デフォルト（ボタン１）は０、ボタン２は１に対応
    public int[] WarSaveSkillId1;
    public int[] WarSaveSkillId2;
    public int[] WarSaveSkillId3;
    public int[] WarSaveSkillId4;
    public int[] WarSaveSkillId5;
    public int[] WizSaveSkillId1;
    public int[] WizSaveSkillId2;
    public int[] WizSaveSkillId3;
    public int[] WizSaveSkillId4;
    public int[] WizSaveSkillId5;
    public int[] AngSaveSkillId1;
    public int[] AngSaveSkillId2;
    public int[] AngSaveSkillId3;
    public int[] AngSaveSkillId4;
    public int[] AngSaveSkillId5;


    //AutoRebirth,AutoRein
    public bool canAutoRebirth;
    public bool canAutoRebirthWarrior, canAutoRebirthWiz, canAutoRebirthAng;
    public bool canAutoRein;
    public bool canAutoReinWarrior, canAutoReinWiz, canAutoReinAng;
    public bool didAutoRein;
    public bool didAutoRebirth;
    public ALLY.Job autoReinJob;
    public Main.Dungeon autoRebirthArea;
    public int P_levelWarR4, P_levelWizR4, P_levelAngR4;
    public bool canGetExtWarR4, canGetExtWizR4, canGetExtAngR4;
    public double P_expWarR4, P_expWizR4, P_expAngR4;
    //public bool isAutoRebirthArea;//Areaが指定されているかどうか。
    //スキル解禁可能条件
    //Warrior
    public bool canS_warrior;
    public bool canS_slash;
    public bool canS_doubleSlash;
    public bool canS_sonicSlash;
    public bool canS_swingDown;
    public bool canS_swingAround;
    public bool canS_chargeSwing;
    public bool canS_fanSwing;
    public bool canS_shieldAttack;
    public bool canS_block;
    //Wizard
    public bool canS_stuffAttack;
    public bool canS_fireBall;
    public bool canS_fireStorm;
    public bool canS_meteoStrike;
    public bool canS_iceBall;
    public bool canS_chillingTouch;
    public bool canS_blizzard;
    public bool canS_thunderBall;
    public bool canS_doubleThunderBall;
    public bool canS_lightningThunder;
    //Angel
    public bool canS_wingAttack;
    public bool canS_wingShoot;
    public bool canS_heal;
    public bool canS_godBless;
    public bool canS_muscleInflation;
    public bool canS_magicImpact;
    public bool canS_protectWall;
    public bool canS_haste;
    public bool canS_angelDistraction;
    public bool canS_holdWings;

    //Dungeon
    public int[] maxDungeonFloorNum;
    public bool unleashDungeon1;
    public bool unleashDungeon2;
    public bool unleashDungeon3;
    public bool unleashDungeon4;
    public bool unleashDungeon5;
    public bool unleashDungeon6;
    public bool unleashDungeon7;
    public bool unleashDungeon8;
    //DarkRitual,Bank解禁
    public bool unleashDarkRitual;
    public bool unleashBank;

    //Challange
    public int clear1, clear2, clear3, clear4, clear5,clear6,clear7,clear8,clear9;
    public int clear_Slime,clear_spider,clear_montblango,clear_distortion,clear_octo;
    public bool iC_fairy, iC_golem, iC_bananoon, iC_slimeBoss,iC_slime,iC_spider,iC_montblango,iC_distortion,iC_octo;
    public int mClear_slime, mClear_fairy, mClear_golem, mClear_bananoon, mClear_spider, mClear_montblango, mClear_distortion, mClear_octo;

    //Artifact 
    public int[] materialNum;
    public int[] consumeItemNum;
    public ARTIFACT.Condition[] condition;
    //public MATERIAL.Condition[] condition2;
    public float[] leftTime2;
    public float[] leftTime;
    public int[] storedNum;
    public bool[] isEquipped;
    public bool[] isFavoriteEquipped;
    public int[] level;
    public int[] evolutionNum;
    public float[] duration = new float[20];

    //ConsumeItemFactor
    public double hpPortion;
    public double mpPortion;

    //Achievement
    public bool[] isUnlocked = new bool[100];
    public ACHIEVEMENT.Mode[] mode = new ACHIEVEMENT.Mode[100];
    public int[] clearNum = new int[100];
    public long QuestPoint;
    public bool eatSandwich;

    //Alchemy
    public int[] leftItems;
    public int[] leftItemsQuality;
    public bool[] leftItemsIsLock;
    public bool[] isUnlockedAlchemy;
    public double gainedAlchemyPoint;
    public double consumedAlchemyPoint;
    public double vitalityLevel;
    public double vitalityValue;
    public double muscleLevel;
    public double muscleValue;
    public double wisdomLevel;
    public double wisdomValue;
    public double agilityLevel;
    public double agilityValue;
    public int maxReachedCap;
    public bool isAuto;
    public bool isAutoUse;
    public bool[] isSuperQueuedAlchemy;

    //DailyQuest
    public int[] DailyQuestSavedDate;
    public int[] TodaysDailyQuestId;
    public int[] dailyQuestInfoId;
   // public long[] requiredEnemy;
   // public long[] requiredMaterial;
    public long[] defeatedEnemyNum;
    public long[] getheredMaterialNum;
    public bool[] isClearedToday;
    public bool[] isQuestInstantiated;
    public DQctrl.Rarity[] rarity;
    public DQctrl.QuestKind[] questKind;
    public ENEMY.EnemyKind[] targetEnemy;
    public ArtiCtrl.MaterialList[] targetMaterial;

    //JobChange
    public long WarP, WizP, AngP;
    public int[] A_level = new int[100];
    //Reincarnation
    public long ReincarnationNum;
    public long RP;//, SRP;
    public long SRPfromTime, SRPfromRebirth, SRPfromEquipment, SRPfromPrevious,SRPfromBankCap,SRPfromMaterial,SRPfromMission,SRPfromMontblango, SRPfromLevel,SRPfromQuest;
    public long SRPfromMaterialBase;
    public bool isMontblangoBeated;
    public bool isDistortionBeated;
    public long SRPconsumed;
    public long SRPinstantConsumed;
    public int[] R_level = new int[100];
    public int[] SR_level = new int[100];
    //SuperRebirth用
    public bool isSuperRebirth;
    public int tempLevel;
    public double stone;
    public double cristal;
    public double leaf;
    public int stoneGoldLevel;
    public int crystalGoldLevel;
    public int leafGoldLevel;
    public double stoneExp;
    public double crystalExp;
    public double leafExp;
    public int[] stoneUpgradeLevel;
    public int[] crystalUpgradeLevel;
    public int[] leafUpgradeLevel;
    public int[] statusUpgradeLevel;
    public long WorkerNum;
    //public long workerNum;
    public long BuyLevel;
    public long CapLevel;
    public long[] currentWorkerNum;
    public double R_HP;
    public double R_MP;
    public double R_ATK;
    public double R_DEF;
    public double R_MATK;
    public double R_MDEF;
    public double R_SPD;
    public double R_GOLD;
    public double R_EXP;
    public double R_stone;
    public double R_crystal;
    public double R_leaf;
    public double R_drop;
    public double spiritWar;
    public double spiritWiz;
    public double spiritAng;
    public int SalchemyQuantity;
    public int[] SwaterCap;
    public int[] ScurrentWater;
    public float[] SwaterValue;
    public float SwaterAddDPSByPotion;
    public float DPSbankFactor;
    public int SreachedCap;

    //SuperQueue
    public bool[] isSuperQueueAssignedforStoneUpgrade;
    public bool[] isSuperQueueAssignedforCrystalUpgrade;
    public bool[] isSuperQueueAssignedforLeafUpgrade;
    public bool[] isSuperQueueAssignedforStatusUpgrade;
    public bool[] isSuperQueueSBAssigned;

    //System
    public bool dmgTxtLimitOff;
    public bool isDeathPanel;
    public float dmgTxtLimit;
    public float customRange;
    public float customSpeed;
    public float bgmSliderValue = 0.2f;
    public float seSliderValue  = 0.2f;
    public bool isDisableTooltip;
    public bool isDisableLootLog;
    public bool isDisableEffect;

    //DarkRitual
    public double[] JemLevel;
    public double[] CurrentExp;
    public bool[] isJemUnlocked;

    //Queue
    public int Queue_unleashed;
    //public int SBQueue_unleashed;


    //Quest
    public bool isRainbowFish;
    public int[] Q_upgradeLevel;
    public bool[] isS_treasureHunt;
    public bool[] isS_errand;
    public bool[] isS_merciless;
    public bool[] isS_slimeLover;
    public bool isPurse, isPoppy;
    public long DefeatBySlimeBall;
    public float MT_slime = 99999f, MT_bat = 99999f, MT_fairy = 99999f, MT_spider = 99999f;
    public bool merciless;
    public long RainbowFishClearedNum;

    //SteamDLC
    public bool dlcStarter;
    public bool dlcGlobal;
    public bool dlcNitro;
    public bool dlcGold;
    public bool dlcGlobalGotFixed;//こっちを使う！

    public bool dlcStarterECGot;
    public bool dlcGlobalECGot;
    public bool dlcNitroECGot;
    public bool dlcGoldECGot;
    public bool dlcIeh2ECGot;

    //SteamAchievement
    public bool[] isAchievedSteam;
    public int isIEBSteamAchievementNum;
    public bool[] isPurchasedIEBBonus;
}