using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider6, "Squirming Poolside",49, 29, 0, true,"3-6");
        gameObject.AddComponent<M_clear>().awake(105);
        gameObject.AddComponent<M_material>().awake(106, ArtiCtrl.MaterialList.AncientCoin,25);
        gameObject.AddComponent<M_capture>().awake(107, ENEMY.EnemyKind.GreenSpider, 50);
        gameObject.AddComponent<M_onlyPhy>().awake(108);
        gameObject.AddComponent<M_noDmg>().awake(109);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 70;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Emerging back outdoors, you gaze upon what was once a world-class pool, no doubt. However, whatever liquid is in the pool now can hardly be described as water, and it's pulsing in a way that seems very familiar to your earlier travels. Slimes. Black oozing globs bubble up and out of the pool, seeping their way towards you. Meanwhile, more spiders descend from the upstairs balcony and out of the Hedge Maze garden at the far side of the yard. You didn't realize that you had inadvertently signed up to be an exterminator here.";
        if (!isDungeon)
        {
            rewardExplain = "- Spider Blood * 5\n- <color=green>Spider Silk * 5</color>";
        }
        else
        {
            rewardExplain = "- Spider Blood * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SpiderBlood,5);
        main.Log("Gain <color=green>Spider Blood * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderSilk,5);
            main.Log("Gain <color=green>Spider Silk * 5");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
