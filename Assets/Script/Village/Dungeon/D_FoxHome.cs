using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_FoxHome : DUNGEON
{
    ////public override int maxDungeonFloorNum
    ////{
    ////    get => main.SR.maxDungeonFloorNum[idDungeon];
    ////    set => main.SR.maxDungeonFloorNum[idDungeon] = value;
    ////}

    ////public override DateTime dungeonPlayTime
    ////{
    ////    get { return DateTime.FromBinary(Convert.ToInt64(main.S.dungeonPlayTime[idDungeon])); }
    ////    set { main.S.dungeonPlayTime[idDungeon] = value.ToBinary().ToString(); }
    ////}

    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.foxHome, "Fox Den", 39, 4);
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
            rewardExplain = "- EXP : 10000\n- GOLD : 3000\n- New Contents";
        }
        else
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 36 ~ 50";
            rewardExplain = "- EXP : 10000\n- GOLD : 3000";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 3000;
        main.DeathPanel.gold += 3000;
        main.ally1.GetComponent<IDamagable>().currentExp += 10000;
        main.DeathPanel.exp += 10000;
        main.Log("<color=orange>Dungeon Clear !");
        main.Log("<color=green>EXP + 10000");
        main.Log("<color=green>Gold + 3000");


        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Slime Secret Base\"<size=10> is Unleashed!", main.ChallengeSpriteAry[4]));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Ball Zone\"<size=10> is Unleashed!", main.ZoneSpritesAry[2]));
            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Bananoon\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[7]));

            //main.TutorialController.ResetZone();
            //main.TutorialController.ShowZone();
            //StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Devil Fish Zone\"<size=10> is Unleashed!",main.ZoneSpritesAry[4]));
            //main.TutorialController.ResetChallenge();
            //main.TutorialController.ShowChallenge();
            //StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Deathpider\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[8]));
            main.TutorialController.isUpgradeIcon9 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unlocked!", main.UpCrystalSpriteAry[6]));

        }
        main.TutorialController.isUpgradeIcon9 = true;

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
    double[] WFox = new double[] { 50000, 100 * 2, 240 * 2, 50, 100, 1000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] YFox = new double[] { 200000, 200 * 2, 360 * 2, 100, 200, 2000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] SB = new double[] { 500000, 300 * 2, 0, 0, 0, 1000000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] NSlime = new double[] { 30000, 400 * 2, 0, 0, 0, 200 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] NMSlime = new double[] { 20000, 0, 200 * 2, 0, 0, 200 };
    double[] GS = new double[] { 50000, 300 * 2, 300 * 2, 100, 100 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] NTB = new double[] { 1000000, 600, 600, 100, 100, 1000000 };



    //public override void InstantiateEnemies(int dungeonFloorNum)
    //{
    //    if (main.GameController.currentDungeon == dungeon)
    //    {
    //        switch (dungeonFloorNum)
    //        {
    //            case 0:
    //                InstantiateEnemy(71, new Vector3(-140, 160), WFox);
    //                InstantiateEnemy(71, new Vector3(140, 160), WFox);
    //                break;
    //            case 1:
    //                InstantiateEnemy(71, new Vector3(-120, -100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 0), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 100), WFox);
    //                break;
    //            case 2:
    //                InstantiateEnemy(71, new Vector3(120, -100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 0), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 100), WFox);
    //                break;
    //            case 3:
    //                InstantiateEnemy(71, new Vector3(120, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, -60), WFox);
    //                break;
    //            case 4:
    //                InstantiateEnemy(71, new Vector3(0, -120), WFox);
    //                InstantiateEnemy(71, new Vector3(0, -30), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 150), WFox);
    //                break;
    //            case 5:
    //                InstantiateEnemy(71, new Vector3(0, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120), WFox);
    //                break;
    //            case 6:
    //                InstantiateEnemy(71, new Vector3(0, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 80), WFox);
    //                break;
    //            case 7:
    //                InstantiateEnemy(71, new Vector3(-60, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(60, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 80), WFox);
    //                break;
    //            case 8:
    //                InstantiateEnemy(71, new Vector3(0, -60 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                break;
    //            case 9:
    //                InstantiateEnemy(71, new Vector3(0, -60 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                InstantiateEnemy(91, new Vector3(0, 100), SB);
    //                break;
    //            case 10:
    //                InstantiateEnemy(71, new Vector3(-120, 0), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 0), WFox);
    //                InstantiateEnemy(0, new Vector3(-60, -60), NSlime);
    //                InstantiateEnemy(0, new Vector3(60, -60), NSlime);
    //                InstantiateEnemy(0, new Vector3(0, -40), NSlime);
    //                InstantiateEnemy(0, new Vector3(-100, 80), NSlime);
    //                InstantiateEnemy(0, new Vector3(100, 80), NSlime);
    //                InstantiateEnemy(0, new Vector3(0, 80), NSlime);
    //                break;
    //            case 11:
    //                InstantiateEnemy(71, new Vector3(-120, -100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 0), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 100), WFox);
    //                InstantiateEnemy(0, new Vector3(0, -100), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, -100), NSlime);
    //                InstantiateEnemy(0, new Vector3(-120, 100), NSlime);
    //                InstantiateEnemy(0, new Vector3(0, 100), NSlime);
    //                InstantiateEnemy(0, new Vector3(-120, 0), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, 0), NSlime);
    //                break;
    //            case 12:
    //                InstantiateEnemy(71, new Vector3(120, -100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 0), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 100), WFox);
    //                InstantiateEnemy(0, new Vector3(0, -100), NSlime);
    //                InstantiateEnemy(0, new Vector3(-120, -100), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, 100), NSlime);
    //                InstantiateEnemy(0, new Vector3(0, 100), NSlime);
    //                InstantiateEnemy(0, new Vector3(-120, 0), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, 0), NSlime);
    //                break;
    //            case 13:
    //                InstantiateEnemy(71, new Vector3(120, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, -60), WFox);
    //                InstantiateEnemy(0, new Vector3(0, -100), NSlime);
    //                InstantiateEnemy(0, new Vector3(30, -60), NSlime);
    //                InstantiateEnemy(0, new Vector3(-30, -60), NSlime);
    //                InstantiateEnemy(0, new Vector3(60, -20), NSlime);
    //                InstantiateEnemy(0, new Vector3(-60, -20), NSlime);
    //                InstantiateEnemy(0, new Vector3(90, 20), NSlime);
    //                InstantiateEnemy(0, new Vector3(-90, 20), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, 60), NSlime);
    //                InstantiateEnemy(0, new Vector3(-120, 60), NSlime);
    //                break;
    //            case 14:
    //                InstantiateEnemy(71, new Vector3(0, -120), WFox);
    //                InstantiateEnemy(71, new Vector3(0, -30), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 150), WFox);
    //                InstantiateEnemy(0, new Vector3(-120, 15), NSlime);
    //                InstantiateEnemy(0, new Vector3(120, 15), NSlime);
    //                InstantiateEnemy(0, new Vector3(-60, -75), NSlime);
    //                InstantiateEnemy(0, new Vector3(60, -75), NSlime);
    //                InstantiateEnemy(0, new Vector3(-60, 75), NSlime);
    //                InstantiateEnemy(0, new Vector3(60, 75), NSlime);
    //                break;
    //            case 15:
    //                InstantiateEnemy(71, new Vector3(0, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120), WFox);
    //                InstantiateEnemy(2, new Vector3(80, -40), NMSlime);
    //                InstantiateEnemy(2, new Vector3(-80, -40), NMSlime);
    //                InstantiateEnemy(2, new Vector3(80, 0), NMSlime);
    //                InstantiateEnemy(2, new Vector3(-80, 0), NMSlime);
    //                InstantiateEnemy(2, new Vector3(80, 40), NMSlime);
    //                InstantiateEnemy(2, new Vector3(-80, 40), NMSlime);
    //                InstantiateEnemy(0, new Vector3(0, 80), NMSlime);

    //                break;
    //            case 16:
    //                InstantiateEnemy(71, new Vector3(0, -60), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 80), WFox);
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(0, new Vector3(-120 + 40 * i, 10), NSlime);
    //                }
    //                InstantiateEnemy(2, new Vector3(100, -40), NMSlime);
    //                InstantiateEnemy(2, new Vector3(-100, -40), NMSlime);
    //                break;
    //            case 17:
    //                InstantiateEnemy(71, new Vector3(-60, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(60, 120), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 80), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 80), WFox);
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(0, new Vector3(-120 + 40 * i, 40), NSlime);
    //                }
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(2, new Vector3(-120 + 40 * i, -20), NMSlime);
    //                }
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(0, new Vector3(-120 + 40 * i, -80), NSlime);
    //                }
    //                break;
    //            case 18:
    //                InstantiateEnemy(71, new Vector3(0, -60 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                break;
    //            case 19:
    //                InstantiateEnemy(71, new Vector3(0, -60 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(0, 30 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(-120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                InstantiateEnemy(71, new Vector3(120, 120 - 100), WFox);
    //                InstantiateEnemy(91, new Vector3(-100, 100), SB);
    //                InstantiateEnemy(91, new Vector3(100, 100), SB);
    //                break;
    //            case 20:
    //                InstantiateEnemy(72, new Vector3(-140, 160), YFox);
    //                InstantiateEnemy(72, new Vector3(140, 160), YFox);
    //                for (int i = 0; i < 9; i++)
    //                {
    //                    InstantiateEnemy(5, new Vector3(-160 + i * 40, 0), GS);
    //                }
    //                for (int i = 0; i < 5; i++)
    //                {
    //                    InstantiateEnemy(5, new Vector3(-160 + i * 80, -60), GS);
    //                    InstantiateEnemy(6, new Vector3(-160 + i * 80, 60), GS);
    //                }
    //                break;
    //            case 21:
    //                InstantiateEnemy(72, new Vector3(-120, -100), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 0), YFox);
    //                InstantiateEnemy(72, new Vector3(120, 100), YFox);
    //                InstantiateSquare(5, new Vector3(-120, 100), GS, 4);
    //                InstantiateSquare(5, new Vector3(120, -100), GS, 4);
    //                break;
    //            case 22:
    //                InstantiateEnemy(72, new Vector3(120, -100), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 0), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, 100), YFox);
    //                InstantiateSquare(6, new Vector3(120, -100), GS, 4);
    //                InstantiateSquare(6, new Vector3(-120, 100), GS, 4);

    //                break;
    //            case 23:
    //                InstantiateEnemy(72, new Vector3(120, -60), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 100), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, -60), YFox);
    //                break;
    //            case 24:
    //                InstantiateEnemy(72, new Vector3(0, -120), YFox);
    //                InstantiateEnemy(72, new Vector3(0, -30), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 60), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 150), YFox);
    //                InstantiateEnemy(5, new Vector3(120, -120), GS);
    //                InstantiateEnemy(5, new Vector3(120, -30), GS);
    //                InstantiateEnemy(5, new Vector3(120, 60), GS);
    //                InstantiateEnemy(5, new Vector3(120, 150), GS);
    //                InstantiateEnemy(5, new Vector3(-120, -120), GS);
    //                InstantiateEnemy(5, new Vector3(-120, -30), GS);
    //                InstantiateEnemy(5, new Vector3(-120, 60), GS);
    //                InstantiateEnemy(5, new Vector3(-120, 150), GS);
    //                break;
    //            case 25:
    //                InstantiateEnemy(72, new Vector3(0, -60), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 30), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, 120), YFox);
    //                InstantiateEnemy(72, new Vector3(120, 120), YFox);
    //                InstantiateSquare(6, new Vector3(-80, -15), GS, 3);
    //                InstantiateSquare(6, new Vector3(80, -15), GS, 3);
    //                break;
    //            case 26:
    //                InstantiateEnemy(72, new Vector3(0, -60), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 80), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, 80), YFox);
    //                InstantiateEnemy(72, new Vector3(120, 80), YFox);
    //                InstantiateSquare(6, new Vector3(-80, -15), GS, 3);
    //                InstantiateSquare(6, new Vector3(80, -15), GS, 3);
    //                break;
    //            case 27:
    //                InstantiateEnemy(72, new Vector3(-60, 120), YFox);
    //                InstantiateEnemy(72, new Vector3(60, 120), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, 80), YFox);
    //                InstantiateEnemy(72, new Vector3(120, 80), YFox);
    //                break;
    //            case 28:
    //                InstantiateEnemy(72, new Vector3(0, -60 - 100), YFox);
    //                InstantiateEnemy(72, new Vector3(0, 30 - 100), YFox);
    //                InstantiateEnemy(72, new Vector3(-120, 120 - 100), YFox);
    //                InstantiateEnemy(72, new Vector3(120, 120 - 100), YFox);
    //                break;
    //            case 29:
    //                InstantiateSquare(71, new Vector3(0, 20), WFox, 10);
    //                break;
    //            case 30:
    //                InstantiateSquare(5, new Vector3(0, 20), GS, 10);
    //                break;
    //            case 31:
    //                InstantiateSquare(6, new Vector3(0, 20), GS, 10);
    //                break;
    //            case 32:
    //                InstantiateSquare(5, new Vector3(0, 20), GS, 10);
    //                break;
    //            case 33:
    //                InstantiateSquare(6, new Vector3(0, 20), GS, 10);
    //                break;
    //            case 34:
    //                InstantiateSquare(72, new Vector3(0, 20), YFox, 6);
    //                break;
    //            case 35:
    //                InstantiateSquare(72, new Vector3(0, 20), YFox, 7);
    //                break;
    //            case 36:
    //                InstantiateSquare(72, new Vector3(0, 20), YFox, 8);
    //                break;
    //            case 37:
    //                InstantiateSquare(72, new Vector3(0, 20), YFox, 9);
    //                break;
    //            case 38:
    //                InstantiateSquare(72, new Vector3(0, 20), YFox, 10);
    //                break;
    //            case 39:
    //                InstantiateEnemy(93, new Vector3(0, 100), NTB);
    //                break;

    //            default:
    //                break;
    //        }

    //    }
    //}


}
