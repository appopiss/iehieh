using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6Fairy : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairy6, "Mushroom Glade", 49, 40, 0, true,"4-6");
        gameObject.AddComponent<M_clear>().awake(145);
        gameObject.AddComponent<M_gold>().awake(146,300000);
        gameObject.AddComponent<M_onlyPhy>().awake(147);
        gameObject.AddComponent<M_capture>().awake(148, ENEMY.EnemyKind.OrangeFairy, 100);
        gameObject.AddComponent<M_time>().awake(149,25);
    }

	// Use this for initialization
	void Start () {
        StartDungeon();
        areaDifficultyFactor = 130;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You're not entirely sure you can believe what you are seeing here. Mushrooms of all varieties and sizes paint the landscape. It appears that at least one part of the folklore was right, that fairies live in mushrooms. Maybe the spores have driven them all crazy with bloodlust? Yeah! Once you finish destroying all of these crazed fairies you make a plan to come back and destroy all of these mushrooms so that the fairies can calm down and you can have tea together. Except that you've slain a bunch of their kin, so they'll probably never agree to tea with you. Oh well, you're more an ale and steak person now anyways.";
        if (!isDungeon)
        {
            rewardExplain = "- Carved Idol * 5\n- <color=green>Ancient Coin * 3</color>";
        }
        else
        {
            rewardExplain = "- Carved Idol * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol,5);
        main.Log("Gain <color=green>Carved Idol * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.AncientCoin,3);
            main.Log("Gain <color=green>Ancient Coin * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareFairy, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
