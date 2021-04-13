using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox8, "Fox Queen's Chamber", 59, 51, 1800, true,"5-8");
        gameObject.AddComponent<M_clear>().awake(195);
        gameObject.AddComponent<M_hp>().awake(196, 0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(197);
        gameObject.AddComponent<M_noEQ>().awake(198);
        gameObject.AddComponent<M_noDmg>().awake(199);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 400;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "As you obliterate the last fox rushing at you, you see a large, well decorated room. Large, beautiful flags hang from the ceiling that appear to contain imagery of foxes with different numbers of tails. The one at the back of the room indicates a fox with nine-tails, under which you see a giant, white fox as depicted in the banner above it. Four brutishly large foxes emerge from the sides of the room to block your passage to the white fox. The white fox unleashes a voice in your mind shouting \"How dare you slay my children!You will perish a thousand times for what you have done!\" and then the brutish foxes leap at you. All of this because you were curious about a hole beneath a tree. At least this time the threats came from a legit boss.";
        if (!isDungeon)
        {
            rewardExplain = "- White Fox Pelt\n- <color=green>Fox Heart</color>\n- <color=green>New Challenge\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- White Fox Pelt";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.WhiteFoxPelt);
        main.Log("Gain <color=green>White Fox Pelt");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FoxHeart);
            main.Log("Gain <color=green>Fox Heart");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDungeon4 = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Fox Hole\" <size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Bananoon\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

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
                    areaDifficultyFactor = 400;
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0));
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 0));
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonFoxes), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 29:
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 34:
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 39:
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 41:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 43:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 45:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 47:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 49:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 51:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 53:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 55:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 57:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;
                case 59:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, -60));
                    break;

                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareFoxes), new Vector3(-120, 60));
                    break;
            }
        }
    }


}
