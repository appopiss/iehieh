using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_SlimeSecretBase : DUNGEON
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
        AwakeDungeon(Main.Dungeon.slimeSecretBase, "Slime Secret Base", 39, 5);
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
            rewardExplain = "- EXP : 50000\n- GOLD : 5000\n- <color=green>New Contents";
        }
        else
        {
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 51 ~ 70";
            rewardExplain = "- EXP : 50000\n- GOLD : 5000";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 5000;
        main.DeathPanel.gold += 5000;
        main.ally1.GetComponent<IDamagable>().currentExp += 50000;
        main.DeathPanel.exp += 50000;
        main.Log("<color=orange>Dungeon Clear !");
        main.Log("<color=green>EXP + 50000");
        main.Log("<color=green>Gold + 5000");


        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Deep Sea Cave\"<size=10> is Unleashed!", main.ChallengeSpriteAry[5]));
            //main.TutorialController.ResetChallenge();
            //main.TutorialController.ShowChallenge();
            //StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Montblango\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[9]));
            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Deathpider\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[8]));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Fox Zone\"<size=10> is Unleashed!", main.ZoneSpritesAry[3]));
            //main.TutorialController.ResetCraftRank();
            //main.TutorialController.ShowCraftRank();
            //StartCoroutine(main.InstantiateLogText("<size=12>Craft Rank \"B\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));

            //main.TutorialController.ResetZone();
            //main.TutorialController.ShowZone();
            //StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"???\"<size=10> is Unleashed!"));

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
    double[] NSlime = new double[] { 750000, 3800 / 5, 0, 0, 0, 2000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] BSlime = new double[] { 1500000, 5200 / 5, 0, 1000, 1000, 4000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] NMSlime = new double[] { 750000, 0, 3600 / 8, 0, 0, 2000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] YSlime = new double[] { 750000, 3650 / 5, 0, 10, 10, 5000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] GMSlime = new double[] { 1500000, 4200 / 5, 4200 / 8, 1000, 1000, 5000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] PSlime = new double[] { 30000000, 8000 / 5, 0, 3000, 3000, 500000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] OSlime = new double[] { 1500000, 3000 / 5, 3000 / 6, 0, 0, 10000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] GSpider = new double[] { 1500000, 4000 / 5, 4000 / 7, 0, 0, 10000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    double[] USlime = new double[] { 150000000, 10000 / 8, 10000 / 8, 500, 500, 1000000 };

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(0, new Vector3(0, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(150, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-150, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(80, 160), NSlime);
                    InstantiateEnemy(0, new Vector3(-80, 160), NSlime);
                    InstantiateEnemy(0, new Vector3(0, -20), NSlime);
                    break;
                case 1:
                    InstantiateEnemy(0, new Vector3(0, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(180, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-180, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 120), NSlime);
                    break;
                case 2:
                    InstantiateEnemy(0, new Vector3(0, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(180, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(-180, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(60, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(120, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-60, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-120, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 120), NSlime);
                    break;
                case 3:
                    InstantiateEnemy(0, new Vector3(0, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 0), NSlime);
                    InstantiateEnemy(0, new Vector3(60, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(120, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-60, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(-120, 60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-180, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(90, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-90, 120), NSlime);
                    InstantiateEnemy(0, new Vector3(-60, -60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, -60), NSlime);
                    InstantiateEnemy(0, new Vector3(60, -60), NSlime);
                    InstantiateEnemy(0, new Vector3(0, -120), NSlime);
                    break;
                case 4:
                    InstantiateEnemy(1, new Vector3(0, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -120), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(60, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(60, -90), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, -90), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(120, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(120, -120), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, -120), BSlime);
                    break;
                case 5:
                    InstantiateEnemy(1, new Vector3(0, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -120), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(60, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(60, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(60, -90), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(-60, -90), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(120, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(120, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(120, -120), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 180), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 120), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 60), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, -60), BSlime);
                    InstantiateEnemy(1, new Vector3(-120, -120), BSlime);
                    InstantiateEnemy(1, new Vector3(180, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(180, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(180, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(180, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(180, -90), BSlime);
                    InstantiateEnemy(1, new Vector3(-180, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-180, 90), BSlime);
                    InstantiateEnemy(1, new Vector3(-180, 30), BSlime);
                    InstantiateEnemy(1, new Vector3(-180, -30), BSlime);
                    InstantiateEnemy(1, new Vector3(-180, -90), BSlime);
                    break;
                case 6:
                    InstantiateEnemy(1, new Vector3(0, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(0, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(0, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(50, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(50, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(50, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(50, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(50, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(50, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(50, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(50, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(100, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(100, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(100, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(100, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(100, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(100, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(100, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(100, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(150, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(150, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(150, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(150, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(150, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(150, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(150, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(150, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(-50, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(-100, -150), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, 200), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, 150), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, 100), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, 50), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, 0), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, -50), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, -100), BSlime);
                    InstantiateEnemy(1, new Vector3(-150, -150), BSlime);
                    break;
                case 7:
                    InstantiateEnemy(2, new Vector3(25, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -175), NMSlime);
                    break;
                case 8:
                    InstantiateEnemy(2, new Vector3(0, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(0, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(25, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(50, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(75, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(100, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(125, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(150, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(175, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-25, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-50, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-75, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-100, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-125, -175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, 200), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, 150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, 100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, 50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, 0), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, -50), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, -100), NMSlime);
                    InstantiateEnemy(2, new Vector3(-150, -150), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 175), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, 25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -25), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -75), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -125), NMSlime);
                    InstantiateEnemy(2, new Vector3(-175, -175), NMSlime);
                    break;
                case 9:
                    for (int i = 0; i < 7; i++)
                    {
                        InstantiateEnemy(0, new Vector3(0, -175 + 50 * i), NSlime);
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        InstantiateEnemy(1, new Vector3(25 + 25 * i, -150 + 25 * i), BSlime);
                        InstantiateEnemy(2, new Vector3(-25 - 25 * i, -150 + 25 * i), NMSlime);
                    }
                    InstantiateEnemy(7, new Vector3(0, 170), PSlime);
                    break;

                case 10:
                    for (int i = 0; i < 8; i++)
                    {
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)), NSlime);
                    }
                    break;
                case 11:
                    for (int i = 0; i < 8; i++)
                    {
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)), BSlime);
                    }
                    break;
                case 12:
                    for (int i = 0; i < 8; i++)
                    {
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)), NMSlime);
                    }
                    break;
                case 13:
                    for (int i = 0; i < 8; i++)
                    {
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)), YSlime);
                    }
                    break;
                case 14:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 15:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 16:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 17:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 18:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 19:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), YSlime);
                        InstantiateEnemy(10, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), YSlime);
                    }
                    break;
                case 20:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), GMSlime);
                    }
                    break;
                case 21:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), GMSlime);
                    }
                    break;
                case 22:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), GMSlime);
                    }
                    break;
                case 23:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), GMSlime);
                    }
                    break;
                case 24:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), GMSlime);
                    }
                    break;
                case 25:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), OSlime);
                    }
                    break;
                case 26:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), OSlime);
                    }
                    break;
                case 27:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), OSlime);
                    }
                    break;
                case 28:
                    for (int i = 0; i < 12; i++)
                    {
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)), OSlime);
                    }
                    break;
                case 29:
                    InstantiateEnemy(12, new Vector3(0, -100), GSpider);
                    InstantiateEnemy(12, new Vector3(40, -90), GSpider);
                    InstantiateEnemy(12, new Vector3(80, -70), GSpider);
                    InstantiateEnemy(12, new Vector3(120, -40), GSpider);
                    InstantiateEnemy(12, new Vector3(160, 0), GSpider);
                    InstantiateEnemy(12, new Vector3(-40, -90), GSpider);
                    InstantiateEnemy(12, new Vector3(-80, -70), GSpider);
                    InstantiateEnemy(12, new Vector3(-120, -40), GSpider);
                    InstantiateEnemy(12, new Vector3(-160, 0), GSpider);
                    InstantiateEnemy(13, new Vector3(0, -40), GSpider);
                    InstantiateEnemy(13, new Vector3(40, -30), GSpider);
                    InstantiateEnemy(13, new Vector3(80, -10), GSpider);
                    InstantiateEnemy(13, new Vector3(120, 20), GSpider);
                    InstantiateEnemy(13, new Vector3(160, 60), GSpider);
                    InstantiateEnemy(13, new Vector3(-40, -30), GSpider);
                    InstantiateEnemy(13, new Vector3(-80, -10), GSpider);
                    InstantiateEnemy(13, new Vector3(-120, 20), GSpider);
                    InstantiateEnemy(13, new Vector3(-160, 60), GSpider);
                    InstantiateEnemy(12, new Vector3(0, 20), GSpider);
                    InstantiateEnemy(12, new Vector3(40, 30), GSpider);
                    InstantiateEnemy(12, new Vector3(80, 50), GSpider);
                    InstantiateEnemy(12, new Vector3(120, 80), GSpider);
                    InstantiateEnemy(12, new Vector3(-40, 30), GSpider);
                    InstantiateEnemy(12, new Vector3(-80, 50), GSpider);
                    InstantiateEnemy(12, new Vector3(-120, 80), GSpider);
                    InstantiateEnemy(10, new Vector3(0, 150), PSlime);
                    break;
                case 30:
                    for (int i = 0; i < 14; i++)
                    {
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)), NSlime);
                        InstantiateEnemy(0, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)), NSlime);
                    }
                    break;
                case 31:
                    for (int i = 0; i < 14; i++)
                    {
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)), BSlime);
                        InstantiateEnemy(1, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)), BSlime);
                    }
                    break;
                case 32:
                    for (int i = 0; i < 14; i++)
                    {
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)), NMSlime);
                        InstantiateEnemy(2, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)), NMSlime);
                    }
                    break;
                case 33:
                    for (int i = 0; i < 14; i++)
                    {
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)), YSlime);
                        InstantiateEnemy(3, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)), YSlime);
                    }
                    break;
                case 34:
                    for (int i = 0; i < 14; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)), GMSlime);
                    }
                    break;
                case 35:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), GMSlime);
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 0 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 1 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 2 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 3 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 4 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 5 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 6 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 7 * 320 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 320 / (9 - 1), -140 + 8 * 320 / (9 - 1)), GMSlime);
                    }
                    break;
                case 36:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), GMSlime);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 0 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 1 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 2 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 3 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 4 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 5 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 6 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 7 * 340 / (9 - 1)), GMSlime);
                        InstantiateEnemy(6, new Vector3(-160 + i * 340 / (9 - 1), -140 + 8 * 340 / (9 - 1)), GMSlime);
                    }
                    break;
                case 37:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), OSlime);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 0 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 1 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 2 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 3 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 4 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 5 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 6 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 7 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-160 + i * 340 / (9 - 1), -140 + 8 * 340 / (9 - 1)), OSlime);
                    }
                    break;
                case 38:
                    for (int i = 0; i < 10; i++)
                    {
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)), OSlime);
                        InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)), OSlime);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 0 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 1 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 2 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 3 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 4 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 5 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 6 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 7 * 340 / (9 - 1)), OSlime);
                        InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 8 * 340 / (9 - 1)), OSlime);
                    }
                    break;
                case 39:
                    InstantiateEnemy(14, new Vector3(0, 100), USlime);
                    break;
                default:
                    break;
            }

        }
    }


}
