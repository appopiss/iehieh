using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB6, "The Brain", 9, 76, 0, true, "8-6");
        gameObject.AddComponent<M_clear>().awake(305);
        gameObject.AddComponent<M_material>().awake(306, ArtiCtrl.MaterialList.MiniatureSword, 1000);
        gameObject.AddComponent<M_noDmg>().awake(307);
        gameObject.AddComponent<M_noEQ>().awake(308);
        gameObject.AddComponent<M_time>().awake(309, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 2200;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob * 50\n- <color=green>Miniature Sword * 50</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob * 50";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 50);
        main.Log("Gain <color=green>Rubbery Blob * 50");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 50);
            main.Log("Gain <color=green>Miniature Sword * 50");
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
                    areaDifficultyFactor = 2200;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 6:
                    areaDifficultyFactor += 50;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 7, 60);
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 6, 60);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 9, 35);
                    break;
                default:
                    break;
            }
        }

    }
}
