using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DBat : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batD, "The Endless Night", 999999, 33, 2400, false,"2");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0),50);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Upon defeating the Vampire Bat that had been plaguing the villagers, a swirling vortex of pure darkness formed before you. Nothing can be seen within it, but the curse of eternal night appears to be flowing forth from this portal. Stepping through you find yourself in a forest, very similar to the one where you started this venture, except that it appears endless, and the canopy above surrenders very little light to flow down to the forest floor. Hoards of bats can be heard shrieking from every direction. The portal remains open behind you, but it may be best to try to destroy as many of these things as possible before returning to your own world. If only bat viscera could be used as currency back in your world, you'd be rich!";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 10) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
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
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 50);
            if (dungeonFloorNum < 25)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 4 , 80);
                else if (rand >= 2500 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 4, 80);
                else if (rand >= 8500 && rand < 9500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 4, 80);
                else if (rand >= 9500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 80);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 25 && dungeonFloorNum < 50)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 5, 70);
                else if (rand >= 2500 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 70);
                else if (rand >= 5000 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 5, 70);
                else if (rand >= 8500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 70);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 50 && dungeonFloorNum < 75)
            {
                if (rand < 500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 6, 60);
                else if (rand >= 500 && rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 6, 60);
                else if (rand >= 2500 && rand < 6500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 6, 60);
                else if (rand >= 6500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 6, 60);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 75 && dungeonFloorNum < 100)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 7, 50);
                else if (rand >= 1000 && rand < 6000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 7, 50);
                else if (rand >= 6000 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 50);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 100 && dungeonFloorNum < 150)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 8, 45);
                else if (rand >= 1000 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 8, 45);
                else if (rand >= 5000 && rand < 9995)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 8, 45);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 150 && dungeonFloorNum < 200)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 9, 40);
                else if (rand >= 1000 && rand < 3000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 9, 40);
                else if (rand >= 3000 && rand < 9990)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
            else
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 10, 40);
                else if (rand >= 1000 && rand < 2000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 10, 40);
                else if (rand >= 2000 && rand < 9985)
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 0), 10, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 20));
            }
        }
    }



}
