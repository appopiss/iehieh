using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB2, "The Warp Train", 9, 72, 0, true, "8-2");
        gameObject.AddComponent<M_clear>().awake(285);
        gameObject.AddComponent<M_noDmg>().awake(286);
        gameObject.AddComponent<M_gold>().awake(287, 1000000);
        gameObject.AddComponent<M_material>().awake(287, ArtiCtrl.MaterialList.RubberyBlob, 5000);
        gameObject.AddComponent<M_time>().awake(289, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob * 2\n- <color=green>Miniature Sword * 2</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob * 2";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 2);
        main.Log("Gain <color=green>Rubbery Blob * 2");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 2);
            main.Log("Gain <color=green>Miniature Sword * 2");
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
                    areaDifficultyFactor = 1500;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                case 6:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 8, 40);
                    break;
                default:
                    break;
            }
        }

    }
}
