using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB5, "The Eye", 9, 75, 0, true, "8-5");
        gameObject.AddComponent<M_clear>().awake(300);
        gameObject.AddComponent<M_hp>().awake(301, 0.95f);
        gameObject.AddComponent<M_spendTime>().awake(302, 3 * 60 * 60f);
        gameObject.AddComponent<M_gold>().awake(303, 2000000);
        gameObject.AddComponent<M_time>().awake(304, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob * 10\n- <color=green>Miniature Sword * 10</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 10);
        main.Log("Gain <color=green>Rubbery Blob * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 10);
            main.Log("Gain <color=green>Miniature Sword * 10");
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
                    areaDifficultyFactor = 2000;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 5, 80);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 4, 80);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 5, 80);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 4, 80);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 5, 80);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 4, 80);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 5, 80);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 4, 80);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 6, 70);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 5, 70);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 6, 70);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 5, 70);
                    break;
                case 6:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 6, 70);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 5, 70);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 6, 70);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 5, 70);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 6, 70);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 5, 70);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                default:
                    break;
            }
        }

    }
}
