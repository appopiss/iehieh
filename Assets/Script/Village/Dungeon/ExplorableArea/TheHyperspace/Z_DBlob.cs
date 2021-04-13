 using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DBlob : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_BBD, "The Hyperspace", 999999, 32, 6000, false, "8");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 100, 0), 500);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Placeholder";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 1) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
    }

    public override void GetReward()
    {
    }

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            dungeonDifficultyFactor = dungeonFloorNum / 5;
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 100, 0), 500);
            if (rand < 9000)
                InstantiateSquare(ENEMY.MonsterTable.CommonBall, new Vector3(0, 20), 10, 30);
            else
                InstantiateSquare(ENEMY.MonsterTable.RareBall, new Vector3(0, 20), 10, 30);
        }
    }



}
