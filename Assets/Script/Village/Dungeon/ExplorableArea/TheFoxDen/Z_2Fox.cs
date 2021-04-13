using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox2, "Winding Tunnels", 34, 45, 0, true,"5-2");
        gameObject.AddComponent<M_clear>().awake(165);
        gameObject.AddComponent<M_clearNum>().awake(166, 500);
        gameObject.AddComponent<M_noDmg>().awake(167);
        gameObject.AddComponent<M_capture>().awake(168, ENEMY.EnemyKind.OrangeFox, 150);
        gameObject.AddComponent<M_gold>().awake(169, 500000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 175;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The passage opens into a series of various tunnels. The foxes that inhabit these tunnels seem to favor certain ones over others, so you decide from that which ones to follow. You finally notice that these foxes have multiple tails, and you're fairly certain you've read some folklore about it, but cannot recall it at this time. It's very difficult to decide where to go next, as you swear your entire sense of equilibrium has been distorted, witnessing foxes walking on the ceiling, while others walk on the walls. They are also pretty aggressive, you've learned, and attack on you on sight. You swear you can hear them talking to one another, but you don't understand the language they are speaking so you can't be entirely sure. The only thing you are sure of is that this feels like a trippy dream, but no amount of pinching yourself has woken you up.";
        if (!isDungeon)
        {
            rewardExplain = "- Fox Tail\n- <color=green>Fox Ear</color>";
        }
        else
        {
            rewardExplain = "- Fox Tail";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FoxTail);
        main.Log("Gain <color=green>Fox Tail");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FoxEar);
            main.Log("Gain <color=green>FoxEar");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
    }
    int rand;
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 30), 6, 60);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 30), 7, 55);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 4, 100);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 80), 4, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }


}
