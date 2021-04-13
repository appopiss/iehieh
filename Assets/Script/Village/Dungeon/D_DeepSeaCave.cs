using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_DeepSeaCave : DUNGEON
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
        AwakeDungeon(Main.Dungeon.deepSeaCave, "Deep Sea Cave", 39, 6);
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
            rewardExplain = "- EXP : 75000\n- GOLD : 10000\n- <color=green>New Contents";
        }
        else
        { 
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 71 ~ 90";
            rewardExplain = "- EXP : 75000\n- GOLD : 10000";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 10000;
        main.DeathPanel.gold += 10000;
        main.ally1.GetComponent<IDamagable>().currentExp += 75000;
        main.DeathPanel.exp += 75000;
        main.Log("<color=orange>Dungeon Clear !");
        main.Log("<color=green>EXP + 75000");
        main.Log("<color=green>Gold + 10000");


        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Lava Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[6]));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Devil Fish Zone\"<size=10> is Unleashed!", main.ZoneSpritesAry[4]));

            //main.TutorialController.ResetZone();
            //main.TutorialController.ShowZone();
            //StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"???\"<size=10> is Unleashed!"));
            //main.TutorialController.ResetChallenge();
            //main.TutorialController.ShowChallenge();
            //StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Distortion Slime\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[10]));
            //main.TutorialController.ResetCraftRank();
            //main.TutorialController.ShowCraftRank();
            //StartCoroutine(main.InstantiateLogText("<size=12>Craft Rank \"A\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));
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
    double[] BF = new double[] { 60000000, 1200, 0, 20000, 0, 500000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] GF = new double[] { 120000000, 1800, 0, 40000, 0, 1000000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] OF = new double[] { 180000000, 2400, 0, 60000, 0, 1500000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] PF = new double[] { 6000000000, 4200, 0, 100000, 0, 50000000000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] RF = new double[] { 270000000, 1400, 0, 60000, 0, 30000000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] SF = new double[] { 60000000, 2400, 0, 30000, 0, 30000000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] YF = new double[] { 1500000000, 3600, 0, 10000, 0, 500000000 };

    public void InstantiateEnemy(int enemyIndex, Vector3 position, double[] Status = null)
    {
        ENEMY game;
        game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
        if (Status != null)
        {
            game.InputStatus = Status;
        }
        switch (enemyIndex)
        {
            case 43:
                game.InputStatus = BF;
                break;
            case 44:
                game.InputStatus = GF;
                break;
            case 45:
                game.InputStatus = OF;
                break;
            case 46:
                game.InputStatus = PF;
                break;
            case 47:
                game.InputStatus = RF;
                break;
            case 48:
                game.InputStatus = SF;
                break;
            case 49:
                game.InputStatus = YF;
                break;
            default:
                break;
        }
    }


    //public override void InstantiateEnemies(int dungeonFloorNum)
    //{
    //    if (main.GameController.currentDungeon == dungeon)
    //    {
    //        switch (dungeonFloorNum)
    //        {
    //            case 0:
    //                InstantiateEnemy(43, new Vector3(120, 160));
    //                InstantiateEnemy(43, new Vector3(60, 100));
    //                InstantiateEnemy(43, new Vector3(0, 40));
    //                InstantiateEnemy(43, new Vector3(-60, -20));
    //                break;
    //            case 1:
    //                InstantiateEnemy(43, new Vector3(-120, 160));
    //                InstantiateEnemy(43, new Vector3(-60, 100));
    //                InstantiateEnemy(43, new Vector3(-0, 40));
    //                InstantiateEnemy(43, new Vector3(60, -20));
    //                break;
    //            case 2:
    //                InstantiateEnemy(44, new Vector3(120, 160));
    //                InstantiateEnemy(44, new Vector3(60, 100));
    //                InstantiateEnemy(44, new Vector3(0, 40));
    //                InstantiateEnemy(44, new Vector3(-60, -20));
    //                break;
    //            case 3:
    //                InstantiateEnemy(44, new Vector3(-120, 160));
    //                InstantiateEnemy(44, new Vector3(-60, 100));
    //                InstantiateEnemy(44, new Vector3(-0, 40));
    //                InstantiateEnemy(44, new Vector3(60, -20));
    //                break;
    //            case 4:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                break;
    //            case 5:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                break;
    //            case 6:
    //                InstantiateEnemy(43, new Vector3(120+30, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60 + 15, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60 + 15, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60-15, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60-15, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120-30, 0 + 50));
    //                break;
    //            case 7:
    //                InstantiateEnemy(44, new Vector3(120 + 30, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60 + 15, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60 + 15, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60 - 15, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60 - 15, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(-120 - 30, 0 + 50));
    //                break;
    //            case 8:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(43, new Vector3(30, 90 + 50));
    //                InstantiateEnemy(43, new Vector3(30, -90 + 50));
    //                InstantiateEnemy(43, new Vector3(90, 30 + 50));
    //                InstantiateEnemy(43, new Vector3(90, -30 + 50));
    //                break;
    //            case 9:
    //                InstantiateEnemy(44, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(30, 90 + 50));
    //                InstantiateEnemy(44, new Vector3(30, -90 + 50));
    //                InstantiateEnemy(44, new Vector3(90, 30 + 50));
    //                InstantiateEnemy(44, new Vector3(90, -30 + 50));
    //                break;
    //            case 10:
    //                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(120, 60 + 50));
    //                break;
    //            case 11:
    //                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 50));
    //                InstantiateEnemy(44, new Vector3(120, 50));
    //                break;
    //            case 12:
    //                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(120, 60 + 50));
    //                break;
    //            case 13:
    //                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(120, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 50));
    //                InstantiateEnemy(44, new Vector3(120, 50));
    //                break;
    //            case 14:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                break;
    //            case 15:
    //                InstantiateEnemy(44, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(-120, 0 + 50));
    //                break;
    //            case 16:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                break;
    //            case 17:
    //                InstantiateEnemy(44, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(-120, 0 + 50));
    //                break;
    //            case 18:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(-120, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 90 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -90 + 50));
    //                break;
    //            case 19:
    //                InstantiateEnemy(44, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(44, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(0, 0 + 50));
    //                InstantiateEnemy(43, new Vector3(0, 90 + 50));
    //                InstantiateEnemy(43, new Vector3(0, -90 + 50));
    //                break;
    //            case 20:
    //                InstantiateEnemy(45, new Vector3(0, 160));
    //                break;
    //            case 21:
    //                InstantiateEnemy(43, new Vector3(0, 160));
    //                InstantiateEnemy(45, new Vector3(-60, 100));
    //                InstantiateEnemy(43, new Vector3(-120, 40));
    //                break;
    //            case 22:
    //                InstantiateEnemy(44, new Vector3(0, 160));
    //                InstantiateEnemy(45, new Vector3(-120, 40));
    //                InstantiateEnemy(44, new Vector3(0, -80));
    //                break;
    //            case 23:
    //                InstantiateEnemy(43, new Vector3(0, 160));
    //                InstantiateEnemy(44, new Vector3(-60, 100));
    //                InstantiateEnemy(45, new Vector3(-120, 40));
    //                InstantiateEnemy(44, new Vector3(-60, -20));
    //                InstantiateEnemy(43, new Vector3(0, -80));
    //                break;
    //            case 24:
    //                InstantiateEnemy(43, new Vector3(0, 160));
    //                InstantiateEnemy(44, new Vector3(60, 100));
    //                InstantiateEnemy(45, new Vector3(120, 40));
    //                InstantiateEnemy(44, new Vector3(60, -20));
    //                InstantiateEnemy(43, new Vector3(0, -80));
    //                break;
    //            case 25:
    //                InstantiateEnemy(44, new Vector3(0, 160));
    //                InstantiateEnemy(45, new Vector3(60, 100));
    //                InstantiateEnemy(44, new Vector3(120, 40));
    //                InstantiateEnemy(45, new Vector3(60, -20));
    //                InstantiateEnemy(44, new Vector3(0, -80));
    //                break;
    //            case 26:
    //                InstantiateEnemy(43, new Vector3(0, 160));
    //                InstantiateEnemy(45, new Vector3(60, 100));
    //                InstantiateEnemy(44, new Vector3(120, 40));
    //                InstantiateEnemy(45, new Vector3(60, -20));
    //                InstantiateEnemy(43, new Vector3(0, -80));
    //                break;
    //            case 27:
    //                InstantiateEnemy(44, new Vector3(0, 160));
    //                InstantiateEnemy(43, new Vector3(60, 100));
    //                InstantiateEnemy(44, new Vector3(120, 40));
    //                InstantiateEnemy(43, new Vector3(60, -20));
    //                InstantiateEnemy(44, new Vector3(0, -80));
    //                break;
    //            case 28:
    //                InstantiateEnemy(44, new Vector3(0, 160));
    //                InstantiateEnemy(43, new Vector3(60, 100));
    //                InstantiateEnemy(45, new Vector3(120, 40));
    //                InstantiateEnemy(43, new Vector3(60, -20));
    //                InstantiateEnemy(44, new Vector3(0, -80));
    //                break;
    //            case 29:
    //                InstantiateEnemy(45, new Vector3(160, 160));
    //                InstantiateEnemy(45, new Vector3(80, 160));
    //                InstantiateEnemy(45, new Vector3(0, 160));
    //                InstantiateEnemy(45, new Vector3(-80, 160));
    //                InstantiateEnemy(45, new Vector3(-160, 160));
    //                break;
    //            case 30:
    //                InstantiateEnemy(47, new Vector3(120, 160));
    //                InstantiateEnemy(45, new Vector3(60, 100));
    //                InstantiateEnemy(44, new Vector3(0, 40));
    //                InstantiateEnemy(43, new Vector3(-60, -20));
    //                break;
    //            case 31:
    //                InstantiateEnemy(47, new Vector3(-120, 160));
    //                InstantiateEnemy(47, new Vector3(-60, 100));
    //                InstantiateEnemy(45, new Vector3(-0, 40));
    //                InstantiateEnemy(44, new Vector3(60, -20));
    //                break;
    //            case 32:
    //                InstantiateEnemy(47, new Vector3(120, 160));
    //                InstantiateEnemy(47, new Vector3(60, 100));
    //                InstantiateEnemy(47, new Vector3(0, 40));
    //                InstantiateEnemy(45, new Vector3(-60, -20));
    //                break;
    //            case 33:
    //                InstantiateEnemy(47, new Vector3(-120, 160));
    //                InstantiateEnemy(47, new Vector3(-60, 100));
    //                InstantiateEnemy(47, new Vector3(-0, 40));
    //                InstantiateEnemy(47, new Vector3(60, -20));
    //                break;
    //            case 34:
    //                InstantiateEnemy(43, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(44, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(45, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(47, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(47, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(45, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
    //                break;
    //            case 35:
    //                InstantiateEnemy(44, new Vector3(120, 0 + 50));
    //                InstantiateEnemy(45, new Vector3(60, 60 + 50));
    //                InstantiateEnemy(48, new Vector3(60, -60 + 50));
    //                InstantiateEnemy(47, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(48, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(47, new Vector3(-60, 60 + 50));
    //                InstantiateEnemy(45, new Vector3(-60, -60 + 50));
    //                InstantiateEnemy(44, new Vector3(-120, 0 + 50));
    //                break;
    //            case 36:
    //                InstantiateEnemy(47, new Vector3(120 + 30, 0 + 50));
    //                InstantiateEnemy(48, new Vector3(60 + 15, 60 + 50));
    //                InstantiateEnemy(47, new Vector3(60 + 15, -60 + 50));
    //                InstantiateEnemy(48, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(47, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(48, new Vector3(-60 - 15, 60 + 50));
    //                InstantiateEnemy(47, new Vector3(-60 - 15, -60 + 50));
    //                InstantiateEnemy(48, new Vector3(-120 - 30, 0 + 50));
    //                break;
    //            case 37:
    //                InstantiateEnemy(48, new Vector3(120 + 30, 0 + 50));
    //                InstantiateEnemy(47, new Vector3(60 + 15, 60 + 50));
    //                InstantiateEnemy(48, new Vector3(60 + 15, -60 + 50));
    //                InstantiateEnemy(47, new Vector3(0, 120 + 50));
    //                InstantiateEnemy(48, new Vector3(0, -120 + 50));
    //                InstantiateEnemy(47, new Vector3(-60 - 15, 60 + 50));
    //                InstantiateEnemy(48, new Vector3(-60 - 15, -60 + 50));
    //                InstantiateEnemy(47, new Vector3(-120 - 30, 0 + 50));
    //                break;
    //            case 38:
    //                InstantiateEnemy(49, new Vector3(0, 160));
    //                break;
    //            case 39:
    //                InstantiateEnemy(46, new Vector3(0, 0),PF);
    //                break;


    //            default:
    //                break;
    //        }

    //    }
    //}


}
