using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Fairy : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairy5, "Strange Clearing", 44, 39, 0, true,"4-5");
        gameObject.AddComponent<M_clear>().awake(140);
        gameObject.AddComponent<M_clearNum>().awake(141, 200);
        gameObject.AddComponent<M_capture>().awake(142, ENEMY.EnemyKind.MetalSlime, 5);
        gameObject.AddComponent<M_clearNum>().awake(143, 1000);
        gameObject.AddComponent<M_noDmg>().awake(144);
    }

	// Use this for initialization
	void Start () {
        StartDungeon();
        areaDifficultyFactor = 115;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You've successfully slashed and hacked your way out of that awful labyrinthine overgrowth and you find yourself in a strange, open clearing. Some sort of magic has been cast here, because the grass doesn't crunch under your feet as you walk, but instead holds firm as though it were made of steel. You can tell walking through this magically preserved clearly will be like walking with jelly feet, as you struggle to find an even footing. Meanwhile, more fairies have emerged from the woods set on using you as paint for their next project. You do appreciate art, but not that which is painted with your blood.";
        if (!isDungeon)
        {
            rewardExplain = "- Relic Stone * 5\n- <color=green>Ancient Coin * 3</color>";
        }
        else
        {
            rewardExplain = "- Relic Stone * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RelicStone,5);
        main.Log("Gain <color=green>Relic Stone * 5");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 110), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 105), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 60));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -10), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 3, 40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 31:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 32:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 33:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 34:
                    Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 10), 2, 320);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 10), 2, 320);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFairy, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareFairy, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        Instantiate13(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -40));
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20));
                        InstantiateFiveUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 1), 2, 80);
                    }
                    break;
            }
        }
    }


}
