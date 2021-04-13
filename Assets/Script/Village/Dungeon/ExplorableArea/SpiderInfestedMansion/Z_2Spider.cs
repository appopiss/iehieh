using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider2, "Unwelcoming Entry",29, 25, 0, true,"3-2");
        gameObject.AddComponent<M_clear>().awake(85);
        gameObject.AddComponent<M_clearNum>().awake(86, 50);
        gameObject.AddComponent<M_onlyPhy>().awake(87);
        gameObject.AddComponent<M_onlyBase>().awake(88);
        gameObject.AddComponent<M_capture>().awake(89, ENEMY.EnemyKind.NormalSpider, 100);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 35;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Spiders, why did it have to be spiders? You didn't even notice the webs from the gate, but now that you approach the entry to the Mansion, they are literally everywhere around you. The small spiders pose no immediate threat, but the giant ones that emerge from every nook and cranny of this place are really freaking you out. The entry itself would be gorgeous, with large marble columns and steps, but the rate of decay of this place has left it looking like the place could collapse in the next couple of years. If it weren't for the possible treasure you could find inside, you'd probably burn the whole place down right now.";
        if (!isDungeon)
        {
            rewardExplain = "- Monster Fluid * 20\n- <color=green>Spider Silk * 3</color>";
        }
        else
        {
            rewardExplain = "- Monster Fluid * 20";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MonsterFluid,20);
        main.Log("Gain <color=green>Monster Fluid * 20");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderSilk,3);
            main.Log("Gain <color=green>Spider Silk * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 3, -40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150), 2, 320);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
