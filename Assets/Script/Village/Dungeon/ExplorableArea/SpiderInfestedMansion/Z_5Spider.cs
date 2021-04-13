using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider5, "Ruined Kitchen",44, 28, 0, true,"3-5");
        gameObject.AddComponent<M_clear>().awake(100);
        gameObject.AddComponent<M_clearNum>().awake(101,100);
        gameObject.AddComponent<M_noEQ>().awake(102);
        gameObject.AddComponent<M_time>().awake(103, 35);
        gameObject.AddComponent<M_gold>().awake(104, 400000);

    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 60;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "An enormous kitchen, bigger than even those in the fancy taverns back in the city, lays in utter ruin now. You see bones scattered about the room... bones that look like they originated from humans. You're not sure what the spiders use this room for now, but you're determined to ensure that your bones do not end up joining those discarded remains. You notice a doorway leading down to an old wine cellar, but then spiders come pouring out so you decide it best to not explore down there. Meanwhile you've got a bunch of drunk spiders to deal with.";
        if (!isDungeon)
        {
            rewardExplain = "- Spider Fang * 2\n- <color=green>Spider Leg * 3</color>\n- <color=green>New Area</color>";
        }
        else
        {
            rewardExplain = "- Spider Fang * 2";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SpiderFang,2);
        main.Log("Gain <color=green>Spider Fang * 2");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderLeg,3);
            main.Log("Gain <color=green>SpiderLeg * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 110), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 105), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 60));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -10), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    break;
                case 31:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    break;
                case 32:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    break;
                case 33:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    break;
                case 34:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -150), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -150), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -150), 2, 320);
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 320);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40));
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 9, 40);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                        InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 1), 2, 80);
                    }
                    break;
            }
        }
    }


}
