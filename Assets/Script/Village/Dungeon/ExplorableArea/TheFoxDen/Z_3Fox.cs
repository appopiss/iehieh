using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox3, "Dizzying Tunnel", 39, 46, 0, true,"5-3");
        gameObject.AddComponent<M_clear>().awake(170);
        gameObject.AddComponent<M_onlyBase>().awake(171);
        gameObject.AddComponent<M_material>().awake(172, ArtiCtrl.MaterialList.Herb, 10000);
        gameObject.AddComponent<M_noEQ>().awake(173);
        gameObject.AddComponent<M_time>().awake(174, 25);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 200;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The last tunnel that you entered seems to open into a gigantic spiral. Foxes can be seen walking all around the tunnel, though you find you are struggling to even stand from the dizziness it is causing you. The foxes seem surprised that you have made it this deep into their den, and rush to attack you. You aren't sure if they are multiplying or you are just seeing double as the dizziness you feel is overwhelming. You can't even think of something humorous because you're so dizzy right now.";
        if (!isDungeon)
        {
            rewardExplain = "- Fox Pelt * 3\n- <color=green>Fox Tail * 10</color>";
        }
        else
        {
            rewardExplain = "- Fox Pelt * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FoxPelt,3);
        main.Log("Gain <color=green>Fox Pelt * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FoxTail,10);
            main.Log("Gain <color=green>Fox Tail * 10");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            //main.TutorialController.isUpgradeIcon7 = true;
            //main.TutorialController.ResetUpgradeIcon();
            //main.TutorialController.ShowUpgradeIcon();
            //StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[2]));
        }
        //main.TutorialController.isUpgradeIcon7 = true;
    }
    int rand;
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {

            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
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
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 30), 8, 40);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFoxes, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
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
}
