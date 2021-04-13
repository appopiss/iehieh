using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB7, "The Heart", 9, 77, 0, true, "8-7");
        gameObject.AddComponent<M_clear>().awake(310);
        gameObject.AddComponent<M_hp>().awake(311, 0.95f);
        gameObject.AddComponent<M_noEQ>().awake(312);
        gameObject.AddComponent<M_capture>().awake(313, ENEMY.EnemyKind.RedRabbitBlob, 50);
        gameObject.AddComponent<M_time>().awake(314, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 2400;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob * 200\n- <color=green>Miniature Sword * 200</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob * 200";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 200);
        main.Log("Gain <color=green>Rubbery Blob * 200");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 200);
            main.Log("Gain <color=green>Miniature Sword * 200");
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
                    areaDifficultyFactor = 2400;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 9, 35);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 9, 35);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 9, 35);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 9, 35);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 6:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 50);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 7, 50);                    break;
                default:
                    break;
            }
        }

    }
}
