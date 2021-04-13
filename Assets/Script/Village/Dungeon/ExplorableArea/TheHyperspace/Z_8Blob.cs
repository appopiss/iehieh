using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB8, "The Core", 9, 78, 1800, true, "8-8");
        gameObject.AddComponent<M_clear>().awake(315);
        gameObject.AddComponent<M_noDmg>().awake(316);
        gameObject.AddComponent<M_material>().awake(317, ArtiCtrl.MaterialList.BallCore, 50);
        gameObject.AddComponent<M_capture>().awake(318, ENEMY.EnemyKind.BlueRabbitBlob, 50);
        gameObject.AddComponent<M_time>().awake(319, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 2600;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Miniature Sword * 500\n- <color=green>Ball Core * 5</color>";
        }
        else
        {
            rewardExplain = "- Miniature Sword * 500";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 500);
        main.Log("Gain <color=green>Miniature Sword * 500");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BallCore, 5);
            main.Log("Gain <color=green>Ball Core * 5");
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
                    areaDifficultyFactor = 2600;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 1:
                    areaDifficultyFactor += 25;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 25);
                    break;
                case 2:
                    areaDifficultyFactor += 25;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 20);
                    break;
                case 3:
                    areaDifficultyFactor += 25;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 15);
                    break;
                case 4:
                    areaDifficultyFactor += 25;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 10);
                    break;
                case 5:
                    areaDifficultyFactor += 50;//2750
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 5);
                    break;
                case 6:
                    areaDifficultyFactor += 50;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 4);
                    break;
                case 7:
                    areaDifficultyFactor += 50;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 3);
                    break;
                case 8:
                    areaDifficultyFactor += 50;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 2);
                    break;
                case 9:
                    areaDifficultyFactor += 100;//3000
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 0);
                    break;
                default:
                    break;
            }
        }

    }
}
