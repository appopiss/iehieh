using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS5, "Slime School", 44, 57, 0, true,"6-5");
        gameObject.AddComponent<M_clear>().awake(220);
        gameObject.AddComponent<M_clearNum>().awake(221, 5000);
        gameObject.AddComponent<M_capture>().awake(222, ENEMY.EnemyKind.MPurpleSlime, 5);
        gameObject.AddComponent<M_time>().awake(223, 30);
        gameObject.AddComponent<M_noDmg>().awake(224);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 500;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You approach a building with a large sign above it that is mostly indecipherable, but you can make out \"S ho l\" with the letters that remain. You assume this was some sort of school. Venturing inside you find a disturbing number of smaller skeletons, also mostly dissolved. Whatever happened here seems to have killed the entire city at once, or at least that's your theory for now. No time to think further on it, though, as more slimes have emerged to try to kill you.";
        if (!isDungeon)
        {
            rewardExplain = "- Relic Stone * 10\n- Carved Idol * 10\n- <color=green>Ancient Coin * 5</color>";
        }
        else
        {
            rewardExplain = "- Relic Stone * 10\n- Carved Idol * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RelicStone,10);
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol,10);
        main.Log("Gain <color=green>Relic Stone * 10");
        main.Log("Gain <color=green>Carved Idol * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.AncientCoin,5);
            main.Log("Gain <color=green>Ancient Coin * 5");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 110), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 105), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -20));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 60));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -10), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 31:
                    Instantiate13(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 32:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 33:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 34:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40));
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 9, 40);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                        InstantiateFiveUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 1), 2, 80);
                    }
                    break;
            }
        }
    }
    int rand;

}
