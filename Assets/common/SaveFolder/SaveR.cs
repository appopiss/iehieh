using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class SaveR
{
    public string ascendTime;
    public double rebirthTime;
    public double realRebirthTime;
    /* ここからアセンドでリセットする変数をpublicで宣言していく */
    /* NOTE : インスペクターに表示させたくない変数は[NonSerialized]をつける */
    /* NOTE : サイズの大きい配列は[NonSeriarized]をつける */
    public float R_time;
    public float RC_time;
    //Temp Job Point
    public long JP_level, JP_enemy, JP_craft;
    //DailyQuest

    //ダンジョンのplayTime
    public double[] dungeonPlayTime;

    public double gold;
    //public ALLY.Job job;
    public Main.Dungeon currentDungeon;
    public bool isReinClassSprite;

    public bool isDead;

    //Rebirth後にすぐTrueになるbool
    public bool afterRebirth;

    //DUNGEON
    public bool[] isDungeon;
    public Main.Dungeon favoriteDungeon;

    public double currentDPS;
    public double currentEXP;
    public double currentGOLD;
    //FloorNum
    public int floorNum;
    public int maxFloorNum;
    public int floorNum1;
    public int maxFloorNum1;
    public int floorNum2;
    public int maxFloorNum2;
    public int floorNum3;
    public int maxFloorNum3;
    public int floorNum4;
    public int maxFloorNum4;
    public Main.Village currentVillage;
    public Main.CurrentStage currentStage;


    //currentStatus
    public double currentHp;
    public double currentMp;
    public int level;
    public double currentExp;

    //slot save
    public SKILL[] currentSkill;
    public SKILL[] currentGrobalSkill;
    public int[] saveSkillId;
    public int[] saveGrobalSkillId;

    //Resourses
    public double stone;
    public double cristal;
    public double leaf;
    public int stoneGoldLevel;
    public int crystalGoldLevel;
    public int leafGoldLevel;
    public double stoneExp;
    public double crystalExp;
    public double leafExp;

    //RandomUpgrade//仮にここを追加した場合は、SuperRebirth時の保存を忘れずに！
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
    //Spiritスキル
    public double spiritWar;
    public double spiritWiz;
    public double spiritAng;
    //RecoursesUpgradeLevel
    public int L_random1, L_random2, L_random3;
    public int LC_stone,LC_cristal,LC_leaf;
    public int LC_stone2, LC_cristal2, LC_leaf2;
    public int LC_stone3, LC_cristal3, LC_leaf3;
    public int L_stone;
    public int L_stone2;
    public int L_stone3;
    public int L_stone4;
    public int LS_stone, LS_stone2, LS_stone3, LS_stone4;
    public int L_cristal;
    public int L_cristal2;
    public int L_cristal3;
    public int L_cristal4;
    public int LS__cristal, LS_cristal2, LS_cristal3, LS_cristal4;
    public int L_leaf;
    public int L_leaf2;
    public int L_leaf3;
    public int L_leaf4;
    public int LS_leaf, LS_leaf2, LS_leaf3, LS_leaf4;
    //StatusUp
    public int AtkStone, MatkCristal, HpLeaf;
    //EquipmentUp
    public int EquipSlotUp;
    public int GoldBonusUp;
    public int ExpBonusUp;
    public bool[] isEquippedforRemember;
    public bool isAllClearedEQ;

    //PassiveSkills
    public bool P_SwordAttack, P_ShieldAttack, P_Block;
    public bool P_StaffAttack, P_fire, P_ice, P_thunder;
    public bool P_GodBless, P_AngelDistruction, P_HoldWing;

    //Storage
    public int Storage1, Storage2, Storage3;

    //NewUpgrades
    public int StoneSliderLevel, CristalSliderLevel, LeafSliderLevel;
    public int N_stone1, N_stone2, N_stone3, N_stone4, N_stone5;
    public int NS_stone1, NS_stone2, NS_stone3, NS_stone4, NS_Stone5;
    public int N_cristal1, N_cristal2, N_cristal3, N_cristal4, N_cristal5;
    public int NS_cristal1, NS_cristal2, NS_cristal3, NS_cristal4, NS_cristal5;
    public int N_leaf1, N_leaf2, N_leaf3, N_leaf4, N_leaf5;
    public int NS_leaf1, NS_leaf2, NS_leaf3, NS_leaf4, NS_leaf5;
    //BuyMode
    public UPGRADE.buyMode buyMode;
    public UPGRADE.buyMode B_buyMode;

    //Alchemy
    public int alchemyQuantity;
    public int[] waterCap;
    public int[] currentWater;
    public float[] waterValue;
    public float waterAddDPSByPotion;
    public int reachedCap;
    public float DPSBankFactor;

    //Result画面
    public double R_gold, RC_gold;
    public double R_exp, RC_exp;
    public int[] R_materials;
    public int[] RC_materials;

    //ActiveSkillのcooltime
    public float warrior14;
    public float earthquake;

    //DarkRItual
    public long WorkerNum;
    public long BuyLevel;
    public long CapLevel;
    public long[] currentWorkerNum;
}
