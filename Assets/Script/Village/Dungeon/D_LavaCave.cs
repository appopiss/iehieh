using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_LavaCave : DUNGEON
{
    //public override int maxDungeonFloorNum
    //{
    //    get => main.SR.maxDungeonFloorNum[idDungeon];
    //    set => main.SR.maxDungeonFloorNum[idDungeon] = value;
    //}

    //public override DateTime dungeonPlayTime
    //{
    //    get { return DateTime.FromBinary(Convert.ToInt64(main.S.dungeonPlayTime[idDungeon])); }
    //    set { main.S.dungeonPlayTime[idDungeon] = value.ToBinary().ToString(); }
    //}

    // Use this for initialization
    void Awake() {
        AwakeDungeon(Main.Dungeon.lavaCave, "Lava Cave", 39, 7);
    }

    // Use this for initialization
    void Start() {
        StartDungeon();
    }

    // Update is called once per frame
    void Update() {
        UpdateDungeon();
        if (!isDungeon)
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv ???";
            rewardExplain = "- EXP : 1.5M\n- GOLD : 5.0T\n- New Contents";
        }
        else
        { 
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 71 ~ 90";
            rewardExplain = "- EXP : 1.5M\n- GOLD : 5.0T";
        }
    }   

    public override void GetReward()
    {
        main.SR.gold += 10000;
        main.DeathPanel.gold += 5000000000000;
        main.ally1.GetComponent<IDamagable>().currentExp += 1500000;
        main.DeathPanel.exp += 1500000;
        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.isUpgradeIcon9 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpCrystalSpriteAry[6]));
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"???\"<size=10> is Unleashed!"));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"???\"<size=10> is Unleashed!"));
        }
    }

    //public override bool ClearCondition()
    //{
    //    if (dungeonFloorNum == dungeonMaxFloorNum + 1 && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
    //    {
    //        dungeonFloorNum = dungeonMaxFloorNum;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //normalSpider
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] NB = new double[] { 10000, 50, 0, 0, 0, 5000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] BB = new double[] { 30000, 100, 0, 2000, 0, 10000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] YB = new double[] { 30000, 0, 50, 0, 0, 15000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] GB = new double[] { 50000, 0, 100, 0, 2000, 30000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] RB = new double[] { 50000, 200, 0, 4000, 2000, 50000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] OB = new double[] { 50000, 500, 0, 6000, 3000, 100000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] BlackB = new double[] { 2000000, 200, 200, 2000, 2000, 10000000 };

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            main.GameController.floorNum3 = 0;
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, 20), NB);
                    InstantiateEnemy(15, new Vector3(140, 20), NB);
                    InstantiateEnemy(15, new Vector3(-140, 160), NB);
                    InstantiateEnemy(15, new Vector3(140, 160), NB);
                    break;
                case 1:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, 20), NB);
                    InstantiateEnemy(15, new Vector3(140, 20), NB);
                    InstantiateEnemy(15, new Vector3(-140, 160), NB);
                    InstantiateEnemy(15, new Vector3(140, 160), NB);
                    break;
                case 2:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, 20), NB);
                    InstantiateEnemy(15, new Vector3(140, 20), NB);
                    InstantiateEnemy(16, new Vector3(-140, 160), BB);
                    InstantiateEnemy(16, new Vector3(140, 160), BB);
                    break;
                case 3:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(16, new Vector3(-140, 20), BB);
                    InstantiateEnemy(16, new Vector3(140, 20), BB);
                    InstantiateEnemy(16, new Vector3(-140, 160), BB);
                    InstantiateEnemy(16, new Vector3(140, 160), BB);
                    break;
                case 4:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, 20), BB);
                    InstantiateEnemy(16, new Vector3(140, 20), BB);
                    InstantiateEnemy(16, new Vector3(-140, 160), BB);
                    InstantiateEnemy(16, new Vector3(140, 160), BB);
                    break;
                case 5:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, 20), BB);
                    InstantiateEnemy(16, new Vector3(140, 20), BB);
                    InstantiateEnemy(17, new Vector3(-140, 160), YB);
                    InstantiateEnemy(17, new Vector3(140, 160), YB);
                    break;
                case 6:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, 20), BB);
                    InstantiateEnemy(17, new Vector3(140, 20), YB);
                    InstantiateEnemy(17, new Vector3(-140, 160), YB);
                    InstantiateEnemy(17, new Vector3(140, 160), YB);
                    break;
                case 7:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(17, new Vector3(-140, 20), YB);
                    InstantiateEnemy(17, new Vector3(140, 20), YB);
                    InstantiateEnemy(17, new Vector3(-140, 160), YB);
                    InstantiateEnemy(17, new Vector3(140, 160), YB);
                    break;
                case 8:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(17, new Vector3(-140, 20), YB);
                    InstantiateEnemy(17, new Vector3(140, 20), YB);
                    InstantiateEnemy(17, new Vector3(-140, 160), YB);
                    InstantiateEnemy(17, new Vector3(140, 160), YB);
                    break;
                case 9:
                    InstantiateEnemy(15, new Vector3(0, -80), NB);
                    InstantiateEnemy(15, new Vector3(40, -100), NB);
                    InstantiateEnemy(15, new Vector3(-40, -100), NB);
                    InstantiateEnemy(15, new Vector3(0, -20), NB);
                    InstantiateEnemy(15, new Vector3(50, -40), NB);
                    InstantiateEnemy(15, new Vector3(-50, -40), NB);
                    InstantiateEnemy(15, new Vector3(100, -80), NB);
                    InstantiateEnemy(15, new Vector3(-100, -80), NB);
                    InstantiateEnemy(15, new Vector3(0, 60), NB);
                    InstantiateEnemy(15, new Vector3(60, 40), NB);
                    InstantiateEnemy(15, new Vector3(-60, 40), NB);
                    InstantiateEnemy(15, new Vector3(120, 0), NB);
                    InstantiateEnemy(15, new Vector3(-120, 0), NB);
                    InstantiateEnemy(15, new Vector3(160, -40), NB);
                    InstantiateEnemy(15, new Vector3(-160, -40), NB);
                    InstantiateEnemy(16, new Vector3(100, 120), BB);
                    InstantiateEnemy(16, new Vector3(-100, 120), BB);
                    break;
                case 10:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, -30), NB);
                    InstantiateEnemy(15, new Vector3(140, -30), NB);
                    InstantiateEnemy(15, new Vector3(-140, 60), NB);
                    InstantiateEnemy(15, new Vector3(140, 60), NB);
                    InstantiateEnemy(15, new Vector3(-140, 150), NB);
                    InstantiateEnemy(15, new Vector3(140, 150), NB);
                    break;
                case 11:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, -30), NB);
                    InstantiateEnemy(15, new Vector3(140, -30), NB);
                    InstantiateEnemy(15, new Vector3(-140, 60), NB);
                    InstantiateEnemy(15, new Vector3(140, 60), NB);
                    InstantiateEnemy(16, new Vector3(-140, 150), BB);
                    InstantiateEnemy(16, new Vector3(140, 150), BB);
                    break;
                case 12:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, -30), NB);
                    InstantiateEnemy(15, new Vector3(140, -30), NB);
                    InstantiateEnemy(16, new Vector3(-140, 60), BB);
                    InstantiateEnemy(16, new Vector3(140, 60), BB);
                    InstantiateEnemy(16, new Vector3(-140, 150), BB);
                    InstantiateEnemy(16, new Vector3(140, 150), BB);
                    break;
                case 13:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(16, new Vector3(-140, -30), BB);
                    InstantiateEnemy(16, new Vector3(140, -30), BB);
                    InstantiateEnemy(16, new Vector3(-140, 60), BB);
                    InstantiateEnemy(16, new Vector3(140, 60), BB);
                    InstantiateEnemy(16, new Vector3(-140, 150), BB);
                    InstantiateEnemy(16, new Vector3(140, 150), BB);
                    break;
                case 14:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, -30), BB);
                    InstantiateEnemy(16, new Vector3(140, -30), BB);
                    InstantiateEnemy(16, new Vector3(-140, 60), BB);
                    InstantiateEnemy(16, new Vector3(140, 60), BB);
                    InstantiateEnemy(16, new Vector3(-140, 150), BB);
                    InstantiateEnemy(16, new Vector3(140, 150), BB);
                    break;
                case 15:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, -30), BB);
                    InstantiateEnemy(16, new Vector3(140, -30), BB);
                    InstantiateEnemy(16, new Vector3(-140, 60), BB);
                    InstantiateEnemy(16, new Vector3(140, 60), BB);
                    InstantiateEnemy(17, new Vector3(-140, 150), YB);
                    InstantiateEnemy(17, new Vector3(140, 150), YB);
                    break;
                case 16:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, -30), BB);
                    InstantiateEnemy(16, new Vector3(140, -30), BB);
                    InstantiateEnemy(17, new Vector3(-140, 60), YB);
                    InstantiateEnemy(17, new Vector3(140, 60), YB);
                    InstantiateEnemy(17, new Vector3(-140, 150), YB);
                    InstantiateEnemy(17, new Vector3(140, 150), YB);
                    break;
                case 17:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(17, new Vector3(-140, -30), YB);
                    InstantiateEnemy(17, new Vector3(140, -30), YB);
                    InstantiateEnemy(17, new Vector3(-140, 60), YB);
                    InstantiateEnemy(17, new Vector3(140, 60), YB);
                    InstantiateEnemy(17, new Vector3(-140, 150), YB);
                    InstantiateEnemy(17, new Vector3(140, 150), YB);
                    break;
                case 18:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(17, new Vector3(-140, -30), YB);
                    InstantiateEnemy(17, new Vector3(140, -30), YB);
                    InstantiateEnemy(17, new Vector3(-140, 60), YB);
                    InstantiateEnemy(17, new Vector3(140, 60), YB);
                    InstantiateEnemy(17, new Vector3(-140, 150), YB);
                    InstantiateEnemy(17, new Vector3(140, 150), YB);
                    break;
                case 19:
                    InstantiateEnemy(16, new Vector3(0, -80), BB);
                    InstantiateEnemy(16, new Vector3(40, -100), BB);
                    InstantiateEnemy(16, new Vector3(-40, -100), BB);
                    InstantiateEnemy(16, new Vector3(0, -20), BB);
                    InstantiateEnemy(16, new Vector3(50, -40), BB);
                    InstantiateEnemy(16, new Vector3(-50, -40), BB);
                    InstantiateEnemy(16, new Vector3(100, -80), BB);
                    InstantiateEnemy(16, new Vector3(-100, -80), BB);
                    InstantiateEnemy(16, new Vector3(0, 60), BB);
                    InstantiateEnemy(16, new Vector3(60, 40), BB);
                    InstantiateEnemy(16, new Vector3(-60, 40), BB);
                    InstantiateEnemy(16, new Vector3(120, 0), BB);
                    InstantiateEnemy(16, new Vector3(-120, 0), BB);
                    InstantiateEnemy(16, new Vector3(160, -40), BB);
                    InstantiateEnemy(16, new Vector3(-160, -40), BB);
                    InstantiateEnemy(17, new Vector3(100, 120), YB);
                    InstantiateEnemy(17, new Vector3(-100, 120), YB);
                    break;
                case 20:
                    InstantiateEnemy(15, new Vector3(-140, -120), NB);
                    InstantiateEnemy(15, new Vector3(140, -120), NB);
                    InstantiateEnemy(15, new Vector3(-140, -50), NB);
                    InstantiateEnemy(15, new Vector3(140, -50), NB);
                    InstantiateEnemy(15, new Vector3(-140, 20), NB);
                    InstantiateEnemy(15, new Vector3(140, 20), NB);
                    InstantiateEnemy(16, new Vector3(-140, 90), BB);
                    InstantiateEnemy(16, new Vector3(140, 90), BB);
                    InstantiateEnemy(16, new Vector3(-140, 160), BB);
                    InstantiateEnemy(16, new Vector3(140, 160), BB);
                    break;
                case 21:
                    InstantiateEnemy(16, new Vector3(-140, -120), BB);
                    InstantiateEnemy(16, new Vector3(140, -120), BB);
                    InstantiateEnemy(16, new Vector3(-140, -50), BB);
                    InstantiateEnemy(16, new Vector3(140, -50), BB);
                    InstantiateEnemy(16, new Vector3(-140, 20), BB);
                    InstantiateEnemy(16, new Vector3(140, 20), BB);
                    InstantiateEnemy(17, new Vector3(-140, 90), YB);
                    InstantiateEnemy(17, new Vector3(140, 90), YB);
                    InstantiateEnemy(17, new Vector3(-140, 160), YB);
                    InstantiateEnemy(17, new Vector3(140, 160), YB);
                    break;
                case 22:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(17, new Vector3(-140, -50), YB);
                    InstantiateEnemy(17, new Vector3(140, -50), YB);
                    InstantiateEnemy(17, new Vector3(-140, 20), YB);
                    InstantiateEnemy(17, new Vector3(140, 20), YB);
                    InstantiateEnemy(17, new Vector3(-140, 90), YB);
                    InstantiateEnemy(17, new Vector3(140, 90), YB);
                    InstantiateEnemy(18, new Vector3(-140, 160), GB);
                    InstantiateEnemy(18, new Vector3(140, 160), GB);
                    break;
                case 23:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(17, new Vector3(-140, -50), YB);
                    InstantiateEnemy(17, new Vector3(140, -50), YB);
                    InstantiateEnemy(17, new Vector3(-140, 20), YB);
                    InstantiateEnemy(17, new Vector3(140, 20), YB);
                    InstantiateEnemy(18, new Vector3(-140, 90), GB);
                    InstantiateEnemy(18, new Vector3(140, 90), GB);
                    InstantiateEnemy(18, new Vector3(-140, 160), GB);
                    InstantiateEnemy(18, new Vector3(140, 160), GB);
                    break;
                case 24:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(17, new Vector3(-140, -50), YB);
                    InstantiateEnemy(17, new Vector3(140, -50), YB);
                    InstantiateEnemy(18, new Vector3(-140, 20), GB);
                    InstantiateEnemy(18, new Vector3(140, 20), GB);
                    InstantiateEnemy(18, new Vector3(-140, 90), GB);
                    InstantiateEnemy(18, new Vector3(140, 90), GB);
                    InstantiateEnemy(18, new Vector3(-140, 160), GB);
                    InstantiateEnemy(18, new Vector3(140, 160), GB);
                    break;
                case 25:
                    InstantiateEnemy(17, new Vector3(-140, -120), YB);
                    InstantiateEnemy(17, new Vector3(140, -120), YB);
                    InstantiateEnemy(18, new Vector3(-140, -50), GB);
                    InstantiateEnemy(18, new Vector3(140, -50), GB);
                    InstantiateEnemy(18, new Vector3(-140, 20), GB);
                    InstantiateEnemy(18, new Vector3(140, 20), GB);
                    InstantiateEnemy(18, new Vector3(-140, 90), GB);
                    InstantiateEnemy(18, new Vector3(140, 90), GB);
                    InstantiateEnemy(18, new Vector3(-140, 160), GB);
                    InstantiateEnemy(18, new Vector3(140, 160), GB);
                    break;
                case 26:
                    InstantiateEnemy(18, new Vector3(-140, -120), GB);
                    InstantiateEnemy(18, new Vector3(140, -120), GB);
                    InstantiateEnemy(18, new Vector3(-140, -50), GB);
                    InstantiateEnemy(18, new Vector3(140, -50), GB);
                    InstantiateEnemy(18, new Vector3(-140, 20), GB);
                    InstantiateEnemy(18, new Vector3(140, 20), GB);
                    InstantiateEnemy(18, new Vector3(-140, 90), GB);
                    InstantiateEnemy(18, new Vector3(140, 90), GB);
                    InstantiateEnemy(18, new Vector3(-140, 160), GB);
                    InstantiateEnemy(18, new Vector3(140, 160), GB);
                    break;
                case 27:
                    InstantiateEnemy(18, new Vector3(-140, -120), GB);
                    InstantiateEnemy(18, new Vector3(140, -120), GB);
                    InstantiateEnemy(18, new Vector3(-140, -50), GB);
                    InstantiateEnemy(18, new Vector3(140, -50), GB);
                    InstantiateEnemy(18, new Vector3(-140, 20), GB);
                    InstantiateEnemy(18, new Vector3(140, 20), GB);
                    InstantiateEnemy(18, new Vector3(-140, 90), GB);
                    InstantiateEnemy(18, new Vector3(140, 90), GB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    break;
                case 28:
                    InstantiateEnemy(18, new Vector3(-140, -120), GB);
                    InstantiateEnemy(18, new Vector3(140, -120), GB);
                    InstantiateEnemy(18, new Vector3(-140, -50), GB);
                    InstantiateEnemy(18, new Vector3(140, -50), GB);
                    InstantiateEnemy(18, new Vector3(-140, 20), GB);
                    InstantiateEnemy(18, new Vector3(140, 20), GB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    break;
                case 29:
                    InstantiateEnemy(18, new Vector3(-140, -120), GB);
                    InstantiateEnemy(18, new Vector3(140, -120), GB);
                    InstantiateEnemy(18, new Vector3(-140, -50), GB);
                    InstantiateEnemy(18, new Vector3(140, -50), GB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    break;
                case 30:
                    InstantiateEnemy(18, new Vector3(-140, -120), GB);
                    InstantiateEnemy(18, new Vector3(140, -120), GB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    break;
                case 31:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    break;
                case 32:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    InstantiateEnemy(20, new Vector3(0, 160), OB);
                    break;
                case 33:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    break;
                case 34:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(19, new Vector3(-140, 160), RB);
                    InstantiateEnemy(19, new Vector3(140, 160), RB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    InstantiateEnemy(20, new Vector3(0, 120), OB);
                    break;
                case 35:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(19, new Vector3(-140, 90), RB);
                    InstantiateEnemy(19, new Vector3(140, 90), RB);
                    InstantiateEnemy(20, new Vector3(-140, 160), OB);
                    InstantiateEnemy(20, new Vector3(140, 160), OB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    InstantiateEnemy(20, new Vector3(0, 120), OB);
                    break;
                case 36:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(19, new Vector3(-140, 20), RB);
                    InstantiateEnemy(19, new Vector3(140, 20), RB);
                    InstantiateEnemy(20, new Vector3(-140, 90), OB);
                    InstantiateEnemy(20, new Vector3(140, 90), OB);
                    InstantiateEnemy(20, new Vector3(-140, 160), OB);
                    InstantiateEnemy(20, new Vector3(140, 160), OB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    InstantiateEnemy(20, new Vector3(0, 120), OB);
                    break;
                case 37:
                    InstantiateEnemy(19, new Vector3(-140, -120), RB);
                    InstantiateEnemy(19, new Vector3(140, -120), RB);
                    InstantiateEnemy(19, new Vector3(-140, -50), RB);
                    InstantiateEnemy(19, new Vector3(140, -50), RB);
                    InstantiateEnemy(20, new Vector3(-140, 20), OB);
                    InstantiateEnemy(20, new Vector3(140, 20), OB);
                    InstantiateEnemy(20, new Vector3(-140, 90), OB);
                    InstantiateEnemy(20, new Vector3(140, 90), OB);
                    InstantiateEnemy(20, new Vector3(-140, 160), OB);
                    InstantiateEnemy(20, new Vector3(140, 160), OB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    InstantiateEnemy(20, new Vector3(0, 120), OB);
                    break;
                case 38:
                    InstantiateEnemy(20, new Vector3(-140, -120), OB);
                    InstantiateEnemy(20, new Vector3(140, -120), OB);
                    InstantiateEnemy(20, new Vector3(-140, -50), OB);
                    InstantiateEnemy(20, new Vector3(140, -50), OB);
                    InstantiateEnemy(20, new Vector3(-140, 20), OB);
                    InstantiateEnemy(20, new Vector3(140, 20), OB);
                    InstantiateEnemy(20, new Vector3(-140, 90), OB);
                    InstantiateEnemy(20, new Vector3(140, 90), OB);
                    InstantiateEnemy(20, new Vector3(-140, 160), OB);
                    InstantiateEnemy(20, new Vector3(140, 160), OB);
                    InstantiateEnemy(20, new Vector3(40, 160), OB);
                    InstantiateEnemy(20, new Vector3(-40, 160), OB);
                    InstantiateEnemy(20, new Vector3(0, 120), OB);
                    break;
                case 39:
                    InstantiateEnemy(57, new Vector3(0, 120), BlackB);
                    break;


                default:
                    break;
            }

        }
    }


}
