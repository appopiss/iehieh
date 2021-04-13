using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_SpiderRuin : DUNGEON
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
        AwakeDungeon(Main.Dungeon.spiderRuin, "Spider Ruin", 24, 3);
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
            rewardExplain = "- EXP : 5000\n- GOLD : 2000\n- <color=green>New Contents";
        }
        else
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 26 ~ 35";
            rewardExplain = "- EXP : 5000\n- GOLD : 2000";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 2000;
        main.DeathPanel.gold += 2000;
        main.ally1.GetComponent<IDamagable>().currentExp += 5000;
        main.DeathPanel.exp += 5000;

        main.Log("<color=orange>Dungeon Clear !");
        main.Log("<color=green>EXP + 5000");
        main.Log("<color=green>Gold + 2000");

        if (!isDungeon)
        {
            isDungeon = true;
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"Dark Ritual\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[5]));
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Fox Home\"<size=10> is Unleashed!", main.ChallengeSpriteAry[1]));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Bat Zone\"<size=10> is Unleashed!", main.ZoneSpritesAry[1]));
            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Golem\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[6]));


            main.TutorialController.isUpgradeIcon7 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[2]));

            //main.TutorialController.ResetZone();
            //main.TutorialController.ShowZone();
            //StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Fox Zone\"<size=10> is Unleashed!",main.ZoneSpritesAry[3]));
            //main.TutorialController.ResetChallenge();
            //main.TutorialController.ShowChallenge();
            //StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Bananoon\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[7]));

        }
        main.TutorialController.isUpgradeIcon7 = true;

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

    //normalSpider
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] NSpider = new double[] { 10000, 40, 20, 5, 0, 1000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] BSpider = new double[] { 30000, 60, 30, 10, 0, 2000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] YSpider = new double[] { 10000, 20, 40, 0, 5, 1000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] GSpider = new double[] { 30000, 30, 60, 0, 10, 2000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] PSpider = new double[] { 800000, 50, 50, 100, 100, 10000 };

    double[] NB = new double[] { 5000, 20, 20, 0, 0, 500 };
    double[] BB = new double[] { 10000, 40, 40, 10, 10, 500 };

    //public override void InstantiateEnemies(int dungeonFloorNum)
    //{
    //    if (main.GameController.currentDungeon == dungeon)
    //    {
    //        switch (dungeonFloorNum)
    //        {
    //            case 0:
    //                InstantiateEnemy(58, new Vector3(-100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(-60, 80), NSpider);
    //                InstantiateEnemy(58, new Vector3(60, 80), NSpider);
    //                InstantiateEnemy(58, new Vector3(-120, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(120, 0), NSpider);
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(15, new Vector3(-180 + i * 60, -80), NB);
    //                }
    //                break;
    //            case 1:
    //                InstantiateEnemy(58, new Vector3(0, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 80), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
    //                InstantiateEnemy(59, new Vector3(140, 20), BSpider);
    //                InstantiateEnemy(59, new Vector3(-140, 20), BSpider);
    //                InstantiateEnemy(59, new Vector3(80, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(-80, 100), BSpider);
    //                InstantiateEnemy(16, new Vector3(-120, 140), BB);
    //                InstantiateEnemy(16, new Vector3(120, 140), BB);
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(17, new Vector3(-180 + i * 60, -80), NB);
    //                }
    //                break;
    //            case 2:
    //                InstantiateEnemy(60, new Vector3(-160, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(-120, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(-80, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(-40, 40), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(40, 40), YSpider);
    //                InstantiateEnemy(60, new Vector3(80, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(120, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 160), YSpider);
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(16, new Vector3(-180 + i * 60, -80), BB);
    //                }
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(17, new Vector3(-180 + i * 60, -40), NB);
    //                }
    //                break;
    //            case 3:
    //                InstantiateEnemy(60, new Vector3(-160, 160), YSpider);
    //                InstantiateEnemy(61, new Vector3(-120, 100), GSpider);
    //                InstantiateEnemy(60, new Vector3(-80, 40), YSpider);
    //                InstantiateEnemy(61, new Vector3(-40, -20), GSpider);
    //                InstantiateEnemy(60, new Vector3(0, -80), YSpider);
    //                InstantiateEnemy(61, new Vector3(40, -20), GSpider);
    //                InstantiateEnemy(60, new Vector3(80, 40), YSpider);
    //                InstantiateEnemy(61, new Vector3(120, 100), GSpider);
    //                InstantiateEnemy(60, new Vector3(160, 160), YSpider);
    //                InstantiateEnemy(18, new Vector3(0, 160), BB);
    //                InstantiateEnemy(18, new Vector3(0, 110), BB);
    //                InstantiateEnemy(18, new Vector3(0, 60), BB);
    //                InstantiateEnemy(18, new Vector3(-120, -50), BB);
    //                InstantiateEnemy(18, new Vector3(120, -50), BB);
    //                break;
    //            case 4:
    //                InstantiateEnemy(58, new Vector3(-150, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 75), NSpider);
    //                InstantiateEnemy(58, new Vector3(150, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(-100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(-160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 150), NSpider);
    //                break;
    //            case 5:
    //                InstantiateEnemy(60, new Vector3(-150, 0), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 75), YSpider);
    //                InstantiateEnemy(60, new Vector3(150, 0), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 0), YSpider);
    //                InstantiateEnemy(60, new Vector3(100, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(-100, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(-160, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 150), YSpider);
    //                break;
    //            case 6:
    //                InstantiateEnemy(59, new Vector3(-150, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 75), BSpider);
    //                InstantiateEnemy(59, new Vector3(150, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(100, 160), BSpider);
    //                InstantiateEnemy(59, new Vector3(160, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(-100, 160), BSpider);
    //                InstantiateEnemy(59, new Vector3(-160, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 150), BSpider);
    //                break;
    //            case 7:
    //                InstantiateEnemy(61, new Vector3(-150, 0), GSpider);
    //                InstantiateEnemy(61, new Vector3(0, 75), GSpider);
    //                InstantiateEnemy(61, new Vector3(150, 0), GSpider);
    //                InstantiateEnemy(61, new Vector3(0, 0), GSpider);
    //                InstantiateEnemy(61, new Vector3(100, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(160, 100), GSpider);
    //                InstantiateEnemy(61, new Vector3(-100, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(-160, 100), GSpider);
    //                InstantiateEnemy(61, new Vector3(0, 150), GSpider);
    //                break;
    //            case 8:
    //                InstantiateEnemy(58, new Vector3(130, -60), NSpider);
    //                InstantiateEnemy(58, new Vector3(-130, -60), NSpider);
    //                InstantiateEnemy(59, new Vector3(60, -90), BSpider);
    //                InstantiateEnemy(59, new Vector3(-60, -90), BSpider);
    //                InstantiateEnemy(58, new Vector3(-120, -120), NSpider);
    //                InstantiateEnemy(58, new Vector3(120, -120), NSpider);
    //                InstantiateEnemy(58, new Vector3(100, 30), NSpider);
    //                InstantiateEnemy(58, new Vector3(-100, 30), NSpider);
    //                InstantiateEnemy(59, new Vector3(0, -30), BSpider);
    //                InstantiateEnemy(58, new Vector3(40, 90), NSpider);
    //                InstantiateEnemy(58, new Vector3(-40, 90), NSpider);
    //                InstantiateEnemy(59, new Vector3(140, 160), BSpider);
    //                InstantiateEnemy(59, new Vector3(-140, 160), BSpider);
    //                break;
    //            case 9:
    //                InstantiateEnemy(60, new Vector3(130, -60), YSpider);
    //                InstantiateEnemy(60, new Vector3(-130, -60), YSpider);
    //                InstantiateEnemy(61, new Vector3(60, -90), GSpider);
    //                InstantiateEnemy(61, new Vector3(-60, -90), GSpider);
    //                InstantiateEnemy(60, new Vector3(-120, -120), YSpider);
    //                InstantiateEnemy(60, new Vector3(120, -120), YSpider);
    //                InstantiateEnemy(60, new Vector3(100, 30), YSpider);
    //                InstantiateEnemy(60, new Vector3(-100, 30), YSpider);
    //                InstantiateEnemy(61, new Vector3(0, -30), GSpider);
    //                InstantiateEnemy(60, new Vector3(40, 90), YSpider);
    //                InstantiateEnemy(60, new Vector3(-40, 90), YSpider);
    //                InstantiateEnemy(61, new Vector3(140, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(-140, 160), GSpider);
    //                break;
    //            case 10:
    //                InstantiateEnemy(59, new Vector3(100, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(-100, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 100), BSpider);
    //                InstantiateEnemy(59, new Vector3(150, 150), BSpider);
    //                InstantiateEnemy(59, new Vector3(-150, 150), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 50), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, -50), BSpider);
    //                break;
    //            case 11:
    //                InstantiateEnemy(58, new Vector3(-150, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 75), NSpider);
    //                InstantiateEnemy(58, new Vector3(150, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(-100, 160), NSpider);
    //                InstantiateEnemy(58, new Vector3(-160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 150), NSpider);
    //                break;
    //            case 12:
    //                for (int i = 0; i < 7; i++)
    //                {
    //                    InstantiateEnemy(60, new Vector3(-180 + i * 60, 0), YSpider);
    //                }
    //                for (int i = 0; i < 2; i++)
    //                {
    //                    InstantiateEnemy(59, new Vector3(-100 + i * 200, 160), BSpider);
    //                }
    //                break;
    //            case 13:
    //                for (int i = 0; i < 9; i++)
    //                {
    //                    InstantiateEnemy(60, new Vector3(-160 + i * 40, 0), YSpider);
    //                }
    //                for (int i = 0; i < 5; i++)
    //                {
    //                    InstantiateEnemy(58, new Vector3(-160 + i * 80, 60), NSpider);
    //                    InstantiateEnemy(59, new Vector3(-160 + i * 80, 120), BSpider);
    //                }
    //                break;
    //            case 14:
    //                InstantiateEnemy(61, new Vector3(0, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(100, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(160, 100), GSpider);
    //                InstantiateEnemy(61, new Vector3(-100, 160), GSpider);
    //                InstantiateEnemy(61, new Vector3(-160, 100), GSpider);
    //                break;
    //            case 15:
    //                InstantiateEnemy(60, new Vector3(0, 80), YSpider);
    //                InstantiateEnemy(60, new Vector3(100, 80), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 20), YSpider);
    //                InstantiateEnemy(60, new Vector3(-100, 80), YSpider);
    //                InstantiateEnemy(60, new Vector3(-160, 20), YSpider);
    //                InstantiateEnemy(59, new Vector3(0, 160), BSpider);
    //                InstantiateEnemy(60, new Vector3(100, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(-100, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(-160, 100), YSpider);
    //                break;
    //            case 16:
    //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(40, 10), NSpider);
    //                InstantiateEnemy(58, new Vector3(80, 30), NSpider);
    //                InstantiateEnemy(58, new Vector3(120, 60), NSpider);
    //                InstantiateEnemy(58, new Vector3(160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(-40, 10), NSpider);
    //                InstantiateEnemy(58, new Vector3(-80, 30), NSpider);
    //                InstantiateEnemy(58, new Vector3(-120, 60), NSpider);
    //                InstantiateEnemy(58, new Vector3(-160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(0, 120), NSpider);
    //                InstantiateEnemy(58, new Vector3(40, 130), NSpider);
    //                InstantiateEnemy(58, new Vector3(80, 150), NSpider);
    //                InstantiateEnemy(58, new Vector3(120, 180), NSpider);
    //                InstantiateEnemy(58, new Vector3(-40, 130), NSpider);
    //                InstantiateEnemy(58, new Vector3(-80, 150), NSpider);
    //                InstantiateEnemy(58, new Vector3(-120, 180), NSpider);
    //                break;
    //            case 17:
    //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
    //                InstantiateEnemy(58, new Vector3(40, 10), NSpider);
    //                InstantiateEnemy(58, new Vector3(80, 30), NSpider);
    //                InstantiateEnemy(58, new Vector3(120, 60), NSpider);
    //                InstantiateEnemy(58, new Vector3(160, 100), NSpider);
    //                InstantiateEnemy(58, new Vector3(-40, 10), NSpider);
    //                InstantiateEnemy(58, new Vector3(-80, 30), NSpider);
    //                InstantiateEnemy(58, new Vector3(-120, 60), NSpider);
    //                InstantiateEnemy(58, new Vector3(-160, 100), NSpider);
    //                InstantiateEnemy(59, new Vector3(0, 120), BSpider);
    //                InstantiateEnemy(59, new Vector3(40, 130), BSpider);
    //                InstantiateEnemy(59, new Vector3(80, 150), BSpider);
    //                InstantiateEnemy(59, new Vector3(120, 180), BSpider);
    //                InstantiateEnemy(59, new Vector3(-40, 130), BSpider);
    //                InstantiateEnemy(59, new Vector3(-80, 150), BSpider);
    //                InstantiateEnemy(59, new Vector3(-120, 180), BSpider);
    //                break;
    //            case 18:
    //                InstantiateEnemy(60, new Vector3(0, 0), YSpider);
    //                InstantiateEnemy(60, new Vector3(40, 10), YSpider);
    //                InstantiateEnemy(60, new Vector3(80, 30), YSpider);
    //                InstantiateEnemy(60, new Vector3(120, 60), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(-40, 10), YSpider);
    //                InstantiateEnemy(60, new Vector3(-80, 30), YSpider);
    //                InstantiateEnemy(60, new Vector3(-120, 60), YSpider);
    //                InstantiateEnemy(60, new Vector3(-160, 100), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 60), YSpider);
    //                InstantiateEnemy(60, new Vector3(40, 70), YSpider);
    //                InstantiateEnemy(60, new Vector3(80, 90), YSpider);
    //                InstantiateEnemy(60, new Vector3(120, 120), YSpider);
    //                InstantiateEnemy(60, new Vector3(160, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(-40, 70), YSpider);
    //                InstantiateEnemy(60, new Vector3(-80, 90), YSpider);
    //                InstantiateEnemy(60, new Vector3(-120, 120), YSpider);
    //                InstantiateEnemy(60, new Vector3(-160, 160), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 120), YSpider);
    //                InstantiateEnemy(60, new Vector3(40, 130), YSpider);
    //                InstantiateEnemy(60, new Vector3(80, 150), YSpider);
    //                InstantiateEnemy(60, new Vector3(120, 180), YSpider);
    //                InstantiateEnemy(60, new Vector3(-40, 130), YSpider);
    //                InstantiateEnemy(60, new Vector3(-80, 150), YSpider);
    //                InstantiateEnemy(60, new Vector3(-120, 180), YSpider);
    //                InstantiateEnemy(60, new Vector3(0, 180), YSpider);
    //                break;
    //            case 19:
    //                InstantiateSquare(58, new Vector3(0, 20), NSpider, 10);
    //                break;
    //            case 20:
    //                InstantiateSquare(59, new Vector3(0, 20), BSpider, 10);
    //                break;
    //            case 21:
    //                InstantiateSquare(60, new Vector3(0, 20), YSpider, 10);
    //                break;
    //            case 22:
    //                InstantiateSquare(61, new Vector3(0, 20), GSpider, 10);
    //                break;
    //            case 23:
    //                InstantiateSquare(61, new Vector3(-100, 100), GSpider, 4);
    //                InstantiateSquare(61, new Vector3(100, 100), GSpider, 4);
    //                InstantiateSquare(61, new Vector3(100, -100), YSpider, 4);
    //                InstantiateSquare(60, new Vector3(-100, -100), YSpider, 4);
    //                InstantiateEnemy(59, new Vector3(0, 160), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 120), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 80), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 40), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, -40), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, -80), BSpider);
    //                InstantiateEnemy(59, new Vector3(-160, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(-120, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(-80, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(-40, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(0, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(40, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(80, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(120, 0), BSpider);
    //                InstantiateEnemy(59, new Vector3(160, 0), BSpider);
    //                break;
    //            case 24:
    //                InstantiateEnemy(61, new Vector3(0, -100), GSpider);
    //                InstantiateEnemy(61, new Vector3(40, -90), GSpider);
    //                InstantiateEnemy(61, new Vector3(80, -70), GSpider);
    //                InstantiateEnemy(61, new Vector3(120, -40), GSpider);
    //                InstantiateEnemy(61, new Vector3(160, 0), GSpider);
    //                InstantiateEnemy(61, new Vector3(-40, -90), GSpider);
    //                InstantiateEnemy(61, new Vector3(-80, -70), GSpider);
    //                InstantiateEnemy(61, new Vector3(-120, -40), GSpider);
    //                InstantiateEnemy(61, new Vector3(-160, 0), GSpider);
    //                InstantiateEnemy(61, new Vector3(0, -40), GSpider);
    //                InstantiateEnemy(61, new Vector3(40, -30), GSpider);
    //                InstantiateEnemy(61, new Vector3(80, -10), GSpider);
    //                InstantiateEnemy(61, new Vector3(120, 20), GSpider);
    //                InstantiateEnemy(61, new Vector3(160, 60), GSpider);
    //                InstantiateEnemy(61, new Vector3(-40, -30), GSpider);
    //                InstantiateEnemy(61, new Vector3(-80, -10), GSpider);
    //                InstantiateEnemy(61, new Vector3(-120, 20), GSpider);
    //                InstantiateEnemy(61, new Vector3(-160, 60), GSpider);
    //                InstantiateEnemy(61, new Vector3(0, 20), GSpider);
    //                InstantiateEnemy(61, new Vector3(40, 30), GSpider);
    //                InstantiateEnemy(61, new Vector3(80, 50), GSpider);
    //                InstantiateEnemy(61, new Vector3(120, 80), GSpider);
    //                InstantiateEnemy(61, new Vector3(-40, 30), GSpider);
    //                InstantiateEnemy(61, new Vector3(-80, 50), GSpider);
    //                InstantiateEnemy(61, new Vector3(-120, 80), GSpider);
    //                InstantiateEnemy(64, new Vector3(0, 150), PSpider);
    //                break;

    //            default:
    //                break;
    //        }

    //    }
    //}


}
