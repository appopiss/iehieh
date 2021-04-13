using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF2, "Coral Cave", 54, 63, 0, true,"7-2");
        gameObject.AddComponent<M_clear>().awake(245);
        gameObject.AddComponent<M_time>().awake(246, 90);
        gameObject.AddComponent<M_capture>().awake(247, ENEMY.EnemyKind.OrangeDevilFish,500);
        gameObject.AddComponent<M_gold>().awake(248, 2000000);
        gameObject.AddComponent<M_noDmg>().awake(249);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 750;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Having slain a number of the Devil Fish, you followed the coast out to a unique looking cave. Colorful and incredible coral covers the entire exterior of the cave, suggesting that this location was once underwater. The devil fish seem to use this cave as a feeding ground for when fish get trapped during the low tide. They aren't picky, though, and they turn their sights on you. Maybe wading out into the deeper water was a bad idea.";
        if (!isDungeon)
        {
            rewardExplain = "- Fish Scales * 5\n- <color=green>Monster Fluid * 1000</color>";
        }
        else
        {
            rewardExplain = "- Fish Scales * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FishScales,5);
        main.Log("Gain <color=green>Fish Scales * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MonsterFluid,1000);
            main.Log("Gain <color=green>Monster Fluid * 1000");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 30), 6, 60);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 7, 55);
                    break;
                case 49:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 7, 55);
                    break;
                case 54:
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 30), 7, 55);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 7);
                    if (rand == 1)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(120, 0 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(0, 120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(0, -120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(-60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(-60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(-120, 0 + 50));
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
                            InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
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
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(60, 100));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(120, 40));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(60, -20));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonDevilFish), new Vector3(0, -80));
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
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 3, 120);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }


}
