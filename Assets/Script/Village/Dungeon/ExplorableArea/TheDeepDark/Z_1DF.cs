using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF1, "The Shallows", 49, 62, 0, true,"7-1");
        gameObject.AddComponent<M_clear>().awake(240);
        gameObject.AddComponent<M_hp>().awake(241, 0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(242);
        gameObject.AddComponent<M_noEQ>().awake(243);
        gameObject.AddComponent<M_material>().awake(244,ArtiCtrl.MaterialList.FishScales, 50000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 700;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Word spread across the continent about a strange breed of fish assaulting people in the waters to the south. You had to see this for yourself, so you ventured to the water’s edge and waded out into the water. Among the regular fish, you notice odd fish that seem to be far more aggressive and seem ready to attack anything that moves. The locals are calling them \"Devil Fish\" since they are both hideously ugly as well as having a taste for blood and have killed many people in the last month. It doesn't take long for these Devil Fish to begin gathering to attack you. You wonder if they'll make good sashimi.";
        if (!isDungeon)
        {
            rewardExplain = "- Fish Scales * 3\n- <color=green>Monster Fluid * 500</color>";
        }
        else
        {
            rewardExplain = "- Fish Scales * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FishScales,5);
        main.Log("Gain <color=green>Fish Scales * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MonsterFluid,100);
            main.Log("Gain <color=green>Monster Fluid * 100");
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
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 40));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, -20));
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 7);
                    if (rand == 1)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 0 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-120, 0 + 50));
                    }
                    else if (rand == 2)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 0 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(30, 90 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(30, -90 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(90, 30 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(90, -30 + 50));
                    }
                    else if (rand == 3)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                        }
                    }
                    else if (rand == 3)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, 100));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-120, 40));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, -20));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -80));
                    }
                    else if (rand == 4)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 100));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 40));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -20));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -80));
                    }
                    else if (rand == 5)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(160, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(80, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-80, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-160, 160));
                    }
                    else if (rand == 6)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 160), 3, 120);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    }
                    break;
            }
        }

    }
    int rand;
}
