using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF8, "Deepest Darkness", 79, 69, 1800, true,"7-8");
        gameObject.AddComponent<M_clear>().awake(275);
        gameObject.AddComponent<M_material>().awake(276, ArtiCtrl.MaterialList.FishTail, 1000);
        gameObject.AddComponent<M_time>().awake(277, 40);
        gameObject.AddComponent<M_noDmg>().awake(278);
        gameObject.AddComponent<M_onlyBase>().awake(279);
    }


    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 1300;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Finally, your senses kick on with a strange sensation of immense danger. A danger you haven't felt before. You have no idea what is going to happen, but you must keep on fighting. Perhaps you've finally reached the boss level. You pray so, because you're getting tired of all of this swimming and can't wait to sit on a beach and relax again. You pledge henceforth to do more beach sitting! Honestly doing laundry sounds good right now.";
        if (!isDungeon)
        {
            rewardExplain = "- Small Treasure Chest\n- <color=green>Devil Fish Core</color>\n- <color=green>New Challenge\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- Small Treasure Chest";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SmallTreasureChest);
        main.Log("Gain <color=green>Small Treasure Chest");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.DevilFishCore);
            main.Log("Gain <color=green>Devil Fish Core");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDungeon4 = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Persistent Tower of Slime\" <size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Octobaddie\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

        }
        main.S.unleashDungeon4 = true;

    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    areaDifficultyFactor = 1300;
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 0));
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonDevilFish), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 29:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 34:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 39:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 44:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 49:
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 51:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 53:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 55:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 57:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 59:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 61:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 63:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 65:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 67:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 69:
                    areaDifficultyFactor += 5;
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 60));
                    break;
                case 70:
                    areaDifficultyFactor += 5;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 100));
                    break;
                case 71:
                    areaDifficultyFactor += 5;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 0));
                    break;
                case 72:
                    areaDifficultyFactor += 5;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 0));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 0));
                    break;
                case 73:
                    areaDifficultyFactor += 5;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, 0));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, 0));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(-100, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(100, -100));
                    break;
                case 74:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 3, 100);
                    break;
                case 75:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 4, 100);
                    break;
                case 76:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 5, 80);
                    break;
                case 77:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 6, 60);
                    break;
                case 78:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 7, 55);
                    break;
                case 79:
                    areaDifficultyFactor += 5;
                    InstantiateSquare(ENEMY.MonsterTable.BossDevilFish, new Vector3(0, 30), 8, 45);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareDevilFish), new Vector3(-120, 60));
                    break;
            }
        }
    }


}
