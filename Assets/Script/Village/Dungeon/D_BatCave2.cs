using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_BatCave2 : DUNGEON
{
    //public override DateTime dungeonPlayTime
    //{
    //    get { return DateTime.FromBinary(Convert.ToInt64(main.S.dungeonPlayTime[idDungeon])); }
    //    set { main.S.dungeonPlayTime[idDungeon] = value.ToBinary().ToString(); }
    //}

    // Use this for initialization
    void Awake() {
        AwakeDungeon(Main.Dungeon.deepSeaCave, "Deep Sea Cave", 39, 8, 7200);
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
            rewardExplain = "- EXP : 500.0K\n- GOLD : 100.0B\n- New Contents";
        }
        else
        { 
            explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 51 ~ 70";
            rewardExplain = "- EXP : 500.0K\n- GOLD : 100.0B";
        }
    }

    public override void GetReward()
    {
        main.SR.gold += 7000;
        main.DeathPanel.gold += 100000000000;
        main.ally1.GetComponent<IDamagable>().currentExp += 500000;
        main.DeathPanel.exp += 500000;
        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"???\"<size=10> is Unlocked!"));
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"???\"<size=10> is Unlocked!"));
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
    public double[] BF = new double[] { 50000, 50, 0, 1000, 0, 5000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] GF = new double[] { 100000, 100, 0, 2000, 0, 10000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] OF = new double[] { 150000, 150, 0, 3000, 0, 15000 };
    [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
    public double[] PF = new double[] { 2000000, 300, 0, 5000, 0, 50000 };

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            main.GameController.floorNum3 = 0;
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(43, new Vector3(120, 160));
                    InstantiateEnemy(43, new Vector3(60, 100));
                    InstantiateEnemy(43, new Vector3(0, 40));
                    InstantiateEnemy(43, new Vector3(-60, -20));
                    break;
                case 1:
                    InstantiateEnemy(43, new Vector3(-120, 160));
                    InstantiateEnemy(43, new Vector3(-60, 100));
                    InstantiateEnemy(43, new Vector3(-0, 40));
                    InstantiateEnemy(43, new Vector3(60, -20));
                    break;
                case 2:
                    InstantiateEnemy(44, new Vector3(120, 160));
                    InstantiateEnemy(44, new Vector3(60, 100));
                    InstantiateEnemy(44, new Vector3(0, 40));
                    InstantiateEnemy(44, new Vector3(-60, -20));
                    break;
                case 3:
                    InstantiateEnemy(44, new Vector3(-120, 160));
                    InstantiateEnemy(44, new Vector3(-60, 100));
                    InstantiateEnemy(44, new Vector3(-0, 40));
                    InstantiateEnemy(44, new Vector3(60, -20));
                    break;
                case 4:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    break;
                case 5:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    break;
                case 6:
                    InstantiateEnemy(43, new Vector3(120+30, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60 + 15, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60 + 15, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60-15, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60-15, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120-30, 0 + 50));
                    break;
                case 7:
                    InstantiateEnemy(44, new Vector3(120 + 30, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60 + 15, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60 + 15, -60 + 50));
                    InstantiateEnemy(44, new Vector3(0, 120 + 50));
                    InstantiateEnemy(44, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60 - 15, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60 - 15, -60 + 50));
                    InstantiateEnemy(44, new Vector3(-120 - 30, 0 + 50));
                    break;
                case 8:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(43, new Vector3(30, 90 + 50));
                    InstantiateEnemy(43, new Vector3(30, -90 + 50));
                    InstantiateEnemy(43, new Vector3(90, 30 + 50));
                    InstantiateEnemy(43, new Vector3(90, -30 + 50));
                    break;
                case 9:
                    InstantiateEnemy(44, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(0, 120 + 50));
                    InstantiateEnemy(44, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(30, 90 + 50));
                    InstantiateEnemy(44, new Vector3(30, -90 + 50));
                    InstantiateEnemy(44, new Vector3(90, 30 + 50));
                    InstantiateEnemy(44, new Vector3(90, -30 + 50));
                    break;
                case 10:
                    InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(120, 60 + 50));
                    break;
                case 11:
                    InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 50));
                    InstantiateEnemy(44, new Vector3(120, 50));
                    break;
                case 12:
                    InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(120, 60 + 50));
                    break;
                case 13:
                    InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(120, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 50));
                    InstantiateEnemy(44, new Vector3(120, 50));
                    break;
                case 14:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    break;
                case 15:
                    InstantiateEnemy(44, new Vector3(120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(0, 120 + 50));
                    InstantiateEnemy(44, new Vector3(0, -120 + 50));
                    InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(-120, 0 + 50));
                    break;
                case 16:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    break;
                case 17:
                    InstantiateEnemy(44, new Vector3(120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(0, 120 + 50));
                    InstantiateEnemy(44, new Vector3(0, -120 + 50));
                    InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(-120, 0 + 50));
                    break;
                case 18:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(0, 120 + 50));
                    InstantiateEnemy(43, new Vector3(0, -120 + 50));
                    InstantiateEnemy(44, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(-120, 0 + 50));
                    InstantiateEnemy(43, new Vector3(0, 0 + 50));
                    InstantiateEnemy(44, new Vector3(0, 90 + 50));
                    InstantiateEnemy(44, new Vector3(0, -90 + 50));
                    break;
                case 19:
                    InstantiateEnemy(44, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(0, 120 + 50));
                    InstantiateEnemy(44, new Vector3(0, -120 + 50));
                    InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(0, 0 + 50));
                    InstantiateEnemy(43, new Vector3(0, 90 + 50));
                    InstantiateEnemy(43, new Vector3(0, -90 + 50));
                    break;
                case 20:
                    InstantiateEnemy(45, new Vector3(0, 160));
                    break;
                case 21:
                    InstantiateEnemy(43, new Vector3(0, 160));
                    InstantiateEnemy(45, new Vector3(-60, 100));
                    InstantiateEnemy(43, new Vector3(-120, 40));
                    break;
                case 22:
                    InstantiateEnemy(44, new Vector3(0, 160));
                    InstantiateEnemy(45, new Vector3(-120, 40));
                    InstantiateEnemy(44, new Vector3(0, -80));
                    break;
                case 23:
                    InstantiateEnemy(43, new Vector3(0, 160));
                    InstantiateEnemy(44, new Vector3(-60, 100));
                    InstantiateEnemy(45, new Vector3(-120, 40));
                    InstantiateEnemy(44, new Vector3(-60, -20));
                    InstantiateEnemy(43, new Vector3(0, -80));
                    break;
                case 24:
                    InstantiateEnemy(43, new Vector3(0, 160));
                    InstantiateEnemy(44, new Vector3(60, 100));
                    InstantiateEnemy(45, new Vector3(120, 40));
                    InstantiateEnemy(44, new Vector3(60, -20));
                    InstantiateEnemy(43, new Vector3(0, -80));
                    break;
                case 25:
                    InstantiateEnemy(44, new Vector3(0, 160));
                    InstantiateEnemy(45, new Vector3(60, 100));
                    InstantiateEnemy(44, new Vector3(120, 40));
                    InstantiateEnemy(45, new Vector3(60, -20));
                    InstantiateEnemy(44, new Vector3(0, -80));
                    break;
                case 26:
                    InstantiateEnemy(43, new Vector3(0, 160));
                    InstantiateEnemy(45, new Vector3(60, 100));
                    InstantiateEnemy(44, new Vector3(120, 40));
                    InstantiateEnemy(45, new Vector3(60, -20));
                    InstantiateEnemy(43, new Vector3(0, -80));
                    break;
                case 27:
                    InstantiateEnemy(44, new Vector3(0, 160));
                    InstantiateEnemy(43, new Vector3(60, 100));
                    InstantiateEnemy(44, new Vector3(120, 40));
                    InstantiateEnemy(43, new Vector3(60, -20));
                    InstantiateEnemy(44, new Vector3(0, -80));
                    break;
                case 28:
                    InstantiateEnemy(44, new Vector3(0, 160));
                    InstantiateEnemy(43, new Vector3(60, 100));
                    InstantiateEnemy(45, new Vector3(120, 40));
                    InstantiateEnemy(43, new Vector3(60, -20));
                    InstantiateEnemy(44, new Vector3(0, -80));
                    break;
                case 29:
                    InstantiateEnemy(45, new Vector3(160, 160));
                    InstantiateEnemy(45, new Vector3(80, 160));
                    InstantiateEnemy(45, new Vector3(0, 160));
                    InstantiateEnemy(45, new Vector3(-80, 160));
                    InstantiateEnemy(45, new Vector3(-160, 160));
                    break;
                case 30:
                    InstantiateEnemy(47, new Vector3(120, 160));
                    InstantiateEnemy(45, new Vector3(60, 100));
                    InstantiateEnemy(44, new Vector3(0, 40));
                    InstantiateEnemy(43, new Vector3(-60, -20));
                    break;
                case 31:
                    InstantiateEnemy(47, new Vector3(-120, 160));
                    InstantiateEnemy(47, new Vector3(-60, 100));
                    InstantiateEnemy(45, new Vector3(-0, 40));
                    InstantiateEnemy(44, new Vector3(60, -20));
                    break;
                case 32:
                    InstantiateEnemy(47, new Vector3(120, 160));
                    InstantiateEnemy(47, new Vector3(60, 100));
                    InstantiateEnemy(47, new Vector3(0, 40));
                    InstantiateEnemy(45, new Vector3(-60, -20));
                    break;
                case 33:
                    InstantiateEnemy(47, new Vector3(-120, 160));
                    InstantiateEnemy(47, new Vector3(-60, 100));
                    InstantiateEnemy(47, new Vector3(-0, 40));
                    InstantiateEnemy(47, new Vector3(60, -20));
                    break;
                case 34:
                    InstantiateEnemy(43, new Vector3(120, 0 + 50));
                    InstantiateEnemy(44, new Vector3(60, 60 + 50));
                    InstantiateEnemy(45, new Vector3(60, -60 + 50));
                    InstantiateEnemy(47, new Vector3(0, 120 + 50));
                    InstantiateEnemy(47, new Vector3(0, -120 + 50));
                    InstantiateEnemy(45, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                    break;
                case 35:
                    InstantiateEnemy(44, new Vector3(120, 0 + 50));
                    InstantiateEnemy(45, new Vector3(60, 60 + 50));
                    InstantiateEnemy(48, new Vector3(60, -60 + 50));
                    InstantiateEnemy(47, new Vector3(0, 120 + 50));
                    InstantiateEnemy(48, new Vector3(0, -120 + 50));
                    InstantiateEnemy(47, new Vector3(-60, 60 + 50));
                    InstantiateEnemy(45, new Vector3(-60, -60 + 50));
                    InstantiateEnemy(44, new Vector3(-120, 0 + 50));
                    break;
                case 36:
                    InstantiateEnemy(47, new Vector3(120 + 30, 0 + 50));
                    InstantiateEnemy(48, new Vector3(60 + 15, 60 + 50));
                    InstantiateEnemy(47, new Vector3(60 + 15, -60 + 50));
                    InstantiateEnemy(48, new Vector3(0, 120 + 50));
                    InstantiateEnemy(47, new Vector3(0, -120 + 50));
                    InstantiateEnemy(48, new Vector3(-60 - 15, 60 + 50));
                    InstantiateEnemy(47, new Vector3(-60 - 15, -60 + 50));
                    InstantiateEnemy(48, new Vector3(-120 - 30, 0 + 50));
                    break;
                case 37:
                    InstantiateEnemy(48, new Vector3(120 + 30, 0 + 50));
                    InstantiateEnemy(47, new Vector3(60 + 15, 60 + 50));
                    InstantiateEnemy(48, new Vector3(60 + 15, -60 + 50));
                    InstantiateEnemy(47, new Vector3(0, 120 + 50));
                    InstantiateEnemy(48, new Vector3(0, -120 + 50));
                    InstantiateEnemy(47, new Vector3(-60 - 15, 60 + 50));
                    InstantiateEnemy(48, new Vector3(-60 - 15, -60 + 50));
                    InstantiateEnemy(47, new Vector3(-120 - 30, 0 + 50));
                    break;
                case 38:
                    InstantiateEnemy(49, new Vector3(0, 160));
                    break;
                case 39:
                    InstantiateEnemy(46, new Vector3(0, 0),PF);
                    break;


                default:
                    break;
            }

        }
    }


}
