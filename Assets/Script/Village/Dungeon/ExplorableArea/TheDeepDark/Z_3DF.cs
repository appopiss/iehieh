using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF3, "Ancient Shipwreck", 59, 64, 0, true,"7-3");
        gameObject.AddComponent<M_clear>().awake(250);
        gameObject.AddComponent<M_onlyBase>().awake(251);
        gameObject.AddComponent<M_time>().awake(252, 35);
        gameObject.AddComponent<M_material>().awake(253,ArtiCtrl.MaterialList.FishTeeth,200);
        gameObject.AddComponent<M_noEQ>().awake(254); 
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 800;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Since you've clearly got your heart set on facing death constantly, a local wisewoman saw it fit to cast an underwater breathing spell on you, to at least give you a chance at surviving where it seemed you were headed next. Delving deeper into the water, you swim across an ancient shipwreck. Could it be loaded with sunken treasures of a bygone era, no. Instead it's swarming with the devil fish who dart out to eat your flesh. You wonder if their scales hold any value, with your mind completely stuck on finding something valuable down here.";
        if (!isDungeon)
        {
            rewardExplain = "- Fish Scales * 10 \n- <color=green>Monster Fluid * 2000</color>";
        }
        else
        {
            rewardExplain = "- Fish Scales * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FishScales,10);
        main.Log("Gain <color=green>Fish Scales * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MonsterFluid,2000);
            main.Log("Gain <color=green>Monster Fluid * 2000");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 6, 60);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 7, 55);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 8, 40);
                    break;
                case 49:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 9, 40);
                    break;
                case 59:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 30), 6, 60);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -80));
                    }
                    break;
            }
        }


    }
}
