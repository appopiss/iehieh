using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB1, "The Warp Station", 9, 71, 0, true, "8-1");
        gameObject.AddComponent<M_clear>().awake(280);
        gameObject.AddComponent<M_hp>().awake(281, 0.95f);
        gameObject.AddComponent<M_noEQ>().awake(282);
        gameObject.AddComponent<M_noDmg>().awake(283);
        gameObject.AddComponent<M_time>().awake(284, 5);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 1300;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Rubbery Blob\n- <color=green>Miniature Sword</color>\n- <color=green>Unleash Hidden Area</color>";
        }
        else
        {
            rewardExplain = "- Rubbery Blob";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RubberyBlob, 1);
        main.Log("Gain <color=green>Rubbery Blob");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 1);
            main.Log("Gain <color=green>Miniature Sword");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
        if (!main.S.isUnleashedHidden)
        {
            main.S.isUnleashedHidden = true;
            main.ZoneCtrl.ActivateHidden();
        }
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    areaDifficultyFactor = 1300;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 5, 80);
                    break;
                case 1:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 5, 80);
                    break;
                case 2:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 5, 80);
                    break;
                case 3:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 5, 80);
                    break;
                case 4:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 5:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 6:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 7:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 8:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 6, 60);
                    break;
                case 9:
                    areaDifficultyFactor += 20;
                    InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 30), 7, 50);
                    break;
                default:
                    break;
            }
        }

    }
}
