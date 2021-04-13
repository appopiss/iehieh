using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Blob : DUNGEON
{
    // Use this for initialization
    void Awake()
    {
        AwakeDungeon(Main.Dungeon.Z_BB4, "The Khaos", 0, 74, 900, true, "8-4");
        gameObject.AddComponent<M_clear>().awake(295);
        gameObject.AddComponent<M_noDmg>().awake(296);
        gameObject.AddComponent<M_material>().awake(297, ArtiCtrl.MaterialList.BallCore, 3);
        gameObject.AddComponent<M_spendTime>().awake(298, 60 * 60f);
        gameObject.AddComponent<M_time>().awake(299, 1);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 1900;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        if (!isDungeon)
        {
            rewardExplain = "- Miniature Sword * 10\n- <color=green>Ball Core</color>";
        }
        else
        {
            rewardExplain = "- Miniature Sword * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MiniatureSword, 10);
        main.Log("Gain <color=green>Miniature Sword * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BallCore, 1);
            main.Log("Gain <color=green> Ball Core");
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
                    InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 35);
                    break;
                default:
                    break;
            }
        }

    }
}
