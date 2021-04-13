using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox5, "Secret Path", 44, 48, 0, true,"5-5");
        gameObject.AddComponent<M_clear>().awake(180);
        gameObject.AddComponent<M_clearNum>().awake(181, 500);
        gameObject.AddComponent<M_onlyBase>().awake(182);
        gameObject.AddComponent<M_time>().awake(183, 30);
        gameObject.AddComponent<M_noDmg>().awake(184);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 255;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "As the last of the guards fell, they pleaded \"Don't crawl under the chair over there! There is nothing to be found there... bleh\" and then they died. The room was basically a dead end, so you decided to try crawling under the chair. Even though you couldn't see a hole or anything, you suddenly found yourself crawling through a tunnel that once again widens to the point that you can stand again.There are more foxes here, and they shout in a tongue that you do not understand, but they seem very confused about how you discovered this route.You find it funny that you'd have never discovered this route if they hadn't forbidden you from looking for it.";
        if (!isDungeon)
        {
            rewardExplain = "- Relic Stone * 5\n- Carved Idol * 5\n- <color=green>Ancient Coin * 5</color>\n- <color=green>New Area</color>";
        }
        else
        {
            rewardExplain = "- Relic Stone * 5\n- Carved Idol * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RelicStone,5);
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol,5);
        main.Log("Gain <color=green>Relic Stone * 5");
        main.Log("Gain <color=green>Carved Idol * 5");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 110), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 105), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -20));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 60));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -10), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 9, 40);
                    break;
                case 31:
                    Instantiate13(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    break;
                case 32:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    break;
                case 33:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    break;
                case 34:
                    Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -150), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -150), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -150), 2, 320);
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 10), 2, 320);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        Instantiate13(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -40));
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 9, 40);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 20));
                        InstantiateFiveUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 120), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 1), 2, 80);
                    }
                    break;
            }
        }
    }
    int rand;

}
