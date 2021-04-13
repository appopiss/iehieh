using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB3, "The Warp Tunnel", 9, 73, 0, true, "8-3");
        gameObject.AddComponent<M_clear>().awake(290);
        gameObject.AddComponent<M_gold>().awake(291, 1000000);
        gameObject.AddComponent<M_capture>().awake(292, ENEMY.EnemyKind.RedBlob, 50);
        gameObject.AddComponent<M_material>().awake(293, ArtiCtrl.MaterialList.MiniatureSword, 10);
        gameObject.AddComponent<M_time>().awake(294, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 1700;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob * 3\n- <color=green>Miniature Sword * 3</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 3);
        main.Log("Gain <color=green>Rubbery Blob * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 3);
            main.Log("Gain <color=green>Miniature Sword * 3");
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
                    areaDifficultyFactor = 1700;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 8, 40);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 8, 40);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 8, 40);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 8, 40);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 9, 40);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 9, 40);
                    break;
                case 6:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 9, 40);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 9, 40);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 9, 40);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 10, 35);
                    break;
                default:
                    break;
            }
        }

    }
}
