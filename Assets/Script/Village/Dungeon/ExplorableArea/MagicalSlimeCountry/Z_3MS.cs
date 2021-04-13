using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS3, "Slime City", 39, 55, 0, true,"6-3");
        gameObject.AddComponent<M_clear>().awake(210);
        gameObject.AddComponent<M_time>().awake(211, 30);
        gameObject.AddComponent<M_onlyBase>().awake(212);
        gameObject.AddComponent<M_onlyPhy>().awake(213);
        gameObject.AddComponent<M_gold>().awake(214,2000000);
        
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 360;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The walls of the city from a distance looked remarkable, but the closer you get the more disturbed you become. Partially dissolved skeletons litter the landscape around the walls, some even hanging over the edge of the walls. Suddenly, a gurgling sound can be heard from all around you as slimes bubble up from the ground, again attempting to pelt you with magic and acidic goop. Yup, definitely something curse-y going on here.";
        if (!isDungeon)
        {
            rewardExplain = "- Enchanted Cloth\n- <color=green>Enchanted Cloth * 10</color>";
        }
        else
        {
            rewardExplain = "- Enchanted Cloth";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.EnchantedCloth);
        main.Log("Gain <color=green>Enchanted Cloth");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.EnchantedCloth,10);
            main.Log("Gain <color=green>Enchanted Cloth * 10");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 6, 60);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 7, 55);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 8, 40);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }


    }
}
