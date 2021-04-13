using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox6, "Dead Ends", 49, 49, 0, true,"5-6");
        gameObject.AddComponent<M_clear>().awake(185);
        gameObject.AddComponent<M_noEQ>().awake(186);
        gameObject.AddComponent<M_capture>().awake(187, ENEMY.EnemyKind.BlueFox, 100);
        gameObject.AddComponent<M_gold>().awake(188,500000);
        gameObject.AddComponent<M_noDmg>().awake(189);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 295;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "This tunnel network seems to have intentional dead ends, and you notice traces of ooze, bat guano, and webs throughout the tunnel. You sigh at the thought of having to fight all of them at once, but you at least prepare yourself for that possibility. You will have to keep pressing forward to try to find a tunnel that doesn't abruptly end, while fighting off whatever the foxes throw at you. You remember reading a story as a child about a girl getting lost in a rabbit hole, but that adventure seemed way cooler than this one.";
        if (!isDungeon)
        {
            rewardExplain = "- Fox Tail * 3\n- <color=green>Fox Eye</color>";
        }
        else
        {
            rewardExplain = "- Fox Tail * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FoxTail,3);
        main.Log("Gain <color=green>Fox Tail * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FoxEye);
            main.Log("Gain <color=green>Fox Eye");
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
                default:
                    rand = UnityEngine.Random.Range(0, 7);
                    if (rand == 0)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    }
                    else if (rand == 4)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 0));
                    }
                    else if (rand == 5)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 6)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonFoxes, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }
    int rand;

}
