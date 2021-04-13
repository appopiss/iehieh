using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox7, "The Right Path", 54, 50, 0, true,"5-7");
        gameObject.AddComponent<M_clear>().awake(190);
        gameObject.AddComponent<M_material>().awake(191, ArtiCtrl.MaterialList.BlackPearl,5);
        gameObject.AddComponent<M_capture>().awake(192, ENEMY.EnemyKind.BlackFox, 50);
        gameObject.AddComponent<M_noDmg>().awake(193);
        gameObject.AddComponent<M_clearNum>().awake(194, 5000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 350;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Exhausted from the dead ends, you lean against a wall and it moves, plummeting you to the floor as it gives way. The wall falls with a light splat, as it looks like some sort of thick paper painted to look like a dirt wall. What is going on here?! You turn around to see two foxes giggling to each other and pointing towards you. As you stand and shake yourself off, they turn and realize you discovered their ploy and let loose a loud yelp. Foxes then come raging down the revealed path to take you out. Their numbers are greater than anything you've faced yet, so you know you must be nearing the end. You wonder for a moment if you can just punch a hole back out of this place.";
        if (!isDungeon)
        {
            rewardExplain = "- Intact Nine Tail\n- <color=green>White Fox Pelt</color>";
        }
        else
        {
            rewardExplain = "- Intact Nine Tail";   
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.IntactNineTail);
        main.Log("Gain <color=green>Intact Nine Tail");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.WhiteFoxPelt);
            main.Log("Gain <color=green>White Fox Pelt");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 20), 2, 200);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 20), 2, 200);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 20), 2, 200);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 20), 2, 200);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 20), 2, 200);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 40), 2, 200);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 40), 2, 200);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 40), 2, 200);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 40), 2, 200);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 40), 2, 200);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140), 2, 300);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140), 2, 300);
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140), 2, 300);
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140), 2, 300);
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140), 2, 300);
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 320);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 360);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 360);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 360);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 360);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -160), 2, 360);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 360);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 360);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 360);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 360);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 360);
                    break;
                case 45:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 46:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 47:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 48:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 49:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 50:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 51:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 52:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 53:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                case 54:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 90), 2, 360);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
