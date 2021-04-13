using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_BatCave : DUNGEON
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
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.batCave, "Bat Cave", 9, 1);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();
        if (!isDungeon)
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv ???";
            rewardExplain = "- EXP : 500\n- GOLD : 200\n- <color=green>New Contents";
        }
        else
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 6 ~ 15";
            rewardExplain = "- EXP : 500\n- GOLD : 200";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 200;
        main.DeathPanel.gold += 200;
        main.ally1.GetComponent<IDamagable>().currentExp += 500;
        main.DeathPanel.exp += 500;

        main.Log("<color=orange>Dungeon Clear !");
        main.Log("<color=green>EXP + 500");
        main.Log("<color=green>Gold + 200");

        if (!isDungeon)
        {
            isDungeon = true;

            main.TutorialController.isUpgradeIcon4 = true;
            main.TutorialController.isUpgradeIcon5 = true;
            main.TutorialController.isUpgradeIcon6 = true;
            main.TutorialController.isUpgradeIcon8 = true;//S1
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unlocked!", main.UpStatusSpriteAry[0]));

            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Sacred Fairy Cave\"<size=10> is Unleashed!", main.ChallengeSpriteAry[3]));

            main.TutorialController.ResetCraftRank();
            main.TutorialController.ShowCraftRank();
            StartCoroutine(main.InstantiateLogText("<size=12>Rank \"C\" Equipment<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));


            /*
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Bat Zone\"<size=10> is Unleashed!",main.ZoneSpritesAry[1]));
    */
            /*
                    main.TutorialController.ResetChallenge();
                    main.TutorialController.ShowChallenge();
                    StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Fairy\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[2]));
            */
        }
        main.TutorialController.isUpgradeIcon4 = true;
        main.TutorialController.isUpgradeIcon5 = true;
        main.TutorialController.isUpgradeIcon6 = true;
        main.TutorialController.isUpgradeIcon8 = true;//S1

    }

    //public override bool ClearCondition()
    //{
    //    if (dungeonFloorNum == dungeonMaxFloorNum+1 && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
    //    {
    //        dungeonFloorNum = dungeonMaxFloorNum;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //wave1 Blue Status
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] wave1Status = new double[] { 200, 5, 0, 0, 0, 100 };
    double[] NS = new double[] { 100, 5, 0, 0, 100 };
    //wave2 
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] N_wave2Status = new double[] { 200, 7, 0, 1, 0, 150 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] Y_wave2Status = new double[] { 200, 0, 7, 0, 1, 150 };
    //wave3
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] N_wave3Status = new double[] { 200, 8, 0, 1, 0, 200, };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] B_wave3Status = new double[] { 400, 8, 0, 2, 0, 400, };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] Y_wave3Status = new double[] { 200, 0, 8, 0, 1, 200, };
    //wave4
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] N_wave4Status = new double[] { 250, 9, 0, 1, 0, 250, };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] B_wave4Status = new double[] { 500, 9, 0, 2, 0, 500, };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] Y_wave4Status = new double[] { 250, 0, 9, 0, 2, 250, };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] P_wave4Status = new double[] { 2000, 12, 12, 20, 20, 500, };

    //public override void InstantiateEnemies(int dungeonFloorNum)
    //{
    //    if (main.GameController.currentDungeon == dungeon)
    //    {
    //        //Enemy Index
    //        //15 : Normal
    //        //16 : Blue
    //        //17 : Yellow

    //        //Base Status
    //        //initialHp = 100;
    //        //currentHp = 100;
    //        //initialAtk = 5;
    //        //initialGold = 100;


    //        switch (dungeonFloorNum)
    //        {
    //            case 0:
    //                InstantiateEnemy(15, new Vector3(0, 160), wave1Status);
    //                InstantiateEnemy(0, new Vector3(-140, 0), NS);
    //                InstantiateEnemy(0, new Vector3(-70, 60), NS);
    //                InstantiateEnemy(0, new Vector3(0, 0), NS);
    //                InstantiateEnemy(0, new Vector3(70, 60), NS);
    //                InstantiateEnemy(0, new Vector3(140, 0), NS);
    //                break;
    //            case 1:
    //                InstantiateEnemy(15, new Vector3(-100, 160), wave1Status);
    //                InstantiateEnemy(15, new Vector3(100, 160), wave1Status);
    //                InstantiateEnemy(15, new Vector3(0, 120), wave1Status);
    //                InstantiateEnemy(15, new Vector3(-60, 80), wave1Status);
    //                InstantiateEnemy(15, new Vector3(60, 80), wave1Status);
    //                InstantiateEnemy(15, new Vector3(0, 40), wave1Status);
    //                InstantiateEnemy(15, new Vector3(-120, 0), wave1Status);
    //                InstantiateEnemy(15, new Vector3(120, 0), wave1Status);
    //                InstantiateEnemy(0, new Vector3(-80, -60), NS);
    //                InstantiateEnemy(0, new Vector3(0, -60), NS);
    //                InstantiateEnemy(0, new Vector3(80, -60), NS);
    //                //InstantiateSquare(0, new Vector3(-120, 0), wave1Status, 5);
    //                //InstantiateSquare(0, new Vector3(120, 0), wave1Status, 5);
    //                //InstantiateSquare(0, new Vector3(0, 120), wave1Status, 5);
    //                break;
    //            case 2:
    //                InstantiateEnemy(0, new Vector3(130, -60), NS);
    //                InstantiateEnemy(0, new Vector3(-130, -60), NS);
    //                InstantiateEnemy(0, new Vector3(60, -90), NS);
    //                InstantiateEnemy(0, new Vector3(-60, -90), NS);
    //                InstantiateEnemy(0, new Vector3(-120, -120), NS);
    //                InstantiateEnemy(0, new Vector3(120, -120), NS);
    //                InstantiateEnemy(0, new Vector3(100, 30), NS);
    //                InstantiateEnemy(0, new Vector3(-100, 30), NS);
    //                InstantiateEnemy(15, new Vector3(40, 90), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(-40, 90), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(140, 160), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(-140, 160), N_wave2Status);
    //                break;
    //            case 3:
    //                InstantiateSquare(0, new Vector3(0, 20), NS, 5);
    //                InstantiateEnemy(15, new Vector3(-140, -140), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(140, -140), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(140, 180), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(-140, 180), N_wave2Status);
    //                break;
    //            case 4:
    //                InstantiateSquare(0, new Vector3(0, 20), NS, 10);
    //                break;
    //            case 5:
    //                InstantiateEnemy(15, new Vector3(0, 160), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(0, 80), N_wave2Status);
    //                InstantiateEnemy(15, new Vector3(0, 0), N_wave2Status);
    //                InstantiateEnemy(17, new Vector3(140, 20), Y_wave2Status);
    //                InstantiateEnemy(17, new Vector3(-140, 20), Y_wave2Status);
    //                InstantiateEnemy(15, new Vector3(0, -80), N_wave2Status);
    //                InstantiateEnemy(17, new Vector3(80, 100), Y_wave2Status);
    //                InstantiateEnemy(17, new Vector3(-80, 100), Y_wave2Status);
    //                break;
    //            case 6:
    //                InstantiateEnemy(15, new Vector3(130, -60), N_wave3Status);
    //                InstantiateEnemy(15, new Vector3(-130, -60), N_wave3Status);
    //                InstantiateEnemy(15, new Vector3(60, -90), N_wave3Status);
    //                InstantiateEnemy(15, new Vector3(-60, -90), N_wave3Status);
    //                InstantiateEnemy(16, new Vector3(-120, -120), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(120, -120), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(100, 30), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(-100, 30), B_wave3Status);
    //                InstantiateEnemy(17, new Vector3(40, 90), Y_wave3Status);
    //                InstantiateEnemy(17, new Vector3(-40, 90), Y_wave3Status);
    //                InstantiateEnemy(17, new Vector3(140, 160), Y_wave3Status);
    //                InstantiateEnemy(17, new Vector3(-140, 160), Y_wave3Status);
    //                break;
    //            case 7:
    //                InstantiateSquare(15, new Vector3(0, 0), N_wave3Status, 5);
    //                InstantiateEnemy(16, new Vector3(-120, -120), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(120, -120), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(-120, 120), B_wave3Status);
    //                InstantiateEnemy(16, new Vector3(120, 120), B_wave3Status);
    //                InstantiateEnemy(17, new Vector3(0, 160), Y_wave3Status);
    //                InstantiateEnemy(17, new Vector3(160, 0), Y_wave3Status);
    //                InstantiateEnemy(17, new Vector3(-160, 0), Y_wave3Status);
    //                break;
    //            case 8:
    //                InstantiateSquare(15, new Vector3(0, 20), N_wave4Status, 10);
    //                break;

    //            case 9:
    //                InstantiateEnemy(15, new Vector3(0, 0), N_wave4Status);
    //                InstantiateEnemy(15, new Vector3(0, -60), N_wave4Status);
    //                InstantiateEnemy(17, new Vector3(-60, -80), Y_wave4Status);
    //                InstantiateEnemy(17, new Vector3(60, -80), Y_wave4Status);
    //                InstantiateEnemy(16, new Vector3(120, 20), B_wave4Status);
    //                InstantiateEnemy(16, new Vector3(-120, 20), B_wave4Status);
    //                InstantiateEnemy(21, new Vector3(-80, 150), P_wave4Status);
    //                InstantiateEnemy(21, new Vector3(80, 150), P_wave4Status);
    //                break;
    //            default:
    //                break;
    //        }

    //    }
    //}


}
