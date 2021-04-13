using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6Bat : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batUnderTemple, "The Under Temple",39, 21, 0, true,"2-6");
        gameObject.AddComponent<M_clear>().awake(65);
        gameObject.AddComponent<M_clearNum>().awake(66, 100);
        gameObject.AddComponent<M_capture>().awake(67,ENEMY.EnemyKind.GreenBat,50);
        gameObject.AddComponent<M_onlyPhy>().awake(68);
        gameObject.AddComponent<M_gold>().awake(69, 500000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 25;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Having descended down the passage near the altar, you enter a place that makes your skin crawl the moment you step foot into it. Cages line the room that are absolutely full of bones, and they don't look to be animal bones at that. A smashed doorway at the opposite end of the room looks as though some magical blast destroyed it. Nothing about this place is settling well with you, but you've committed to seeing this through, so whatever lies ahead will lay dead at your feet before this day is over. That's what you keep telling yourself, anyways.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Feet\n- <color=green>Bat Heart</color>";
        }
        else
        {
            rewardExplain = "- Bat Feet";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatFeet);
        main.Log("Gain <color=green>Bat Feet");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BatHeart);
            main.Log("Gain <color=green>Bat Heart");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 3, 40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 3, 40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 3, 40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 3, 40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 90), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 90), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 90), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 90), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 90), 2, 320);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
