using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DMS: DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MSD, "The Persistent Tower", 999999, 61, 4800, false,"6");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 150);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Having defeated the Wizard Slime, a stairwell expands out from the walls, leading up higher into the tower. How strange, because you were already at the top of the tower, or so you thought. The stairs lead up to another floor, with another set of stairs leading up further. You cannot proceed further up the stairs until you deal with the slimes that seem to have been awaiting your arrival. Could this tower go on forever? You wonder if this was how they reached the gods to drain their essence, or if this is just another part of the twisted curse that has befallen this place. You snagged a bottle of brandy from the first floor, so you're good to climb for hours!";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 50) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
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
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 150);
            if (dungeonFloorNum < 25)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 20), 4 , 80);
                else if (rand >= 2500 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 4, 80);
                else if (rand >= 8500 && rand < 9500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 4, 80);
                else if (rand >= 9500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 80);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 25 && dungeonFloorNum < 50)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 20), 5, 70);
                else if (rand >= 2500 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 5, 70);
                else if (rand >= 5000 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 5, 70);
                else if (rand >= 8500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 70);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 50 && dungeonFloorNum < 75)
            {
                if (rand < 500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 20), 6, 60);
                else if (rand >= 500 && rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 6, 60);
                else if (rand >= 2500 && rand < 6500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 6, 60);
                else if (rand >= 6500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 6, 60);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 75 && dungeonFloorNum < 100)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 7, 50);
                else if (rand >= 1000 && rand < 6000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 7, 50);
                else if (rand >= 6000 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 7, 50);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 100 && dungeonFloorNum < 150)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 8, 45);
                else if (rand >= 1000 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 8, 45);
                else if (rand >= 5000 && rand < 9995)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 8, 45);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 150 && dungeonFloorNum < 200)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 9, 40);
                else if (rand >= 1000 && rand < 3000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 9, 40);
                else if (rand >= 3000 && rand < 9990)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 9, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
            else
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0), 10, 40);
                else if (rand >= 1000 && rand < 2000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 10, 40);
                else if (rand >= 2000 && rand < 9985)
                    InstantiateSquare(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 0), 10, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 20));
            }
        }
    }



}
