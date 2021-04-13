using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DDF: DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DFD, "The Infinite Depths", 999999, 70, 5400, false,"7");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 250);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Having slain whatever it was that attacked you in the deep and lonely darkness of the sea, a light finally appears. Oh yes, a portal opening. You did it, you slew a boss! The blue light casts light across the cavern around you. You can see the corpse of the mighty fish that you slew. You kind of wish that someone else was around to give you props for the incredible feat you just accomplished, but you are very much alone. Screw it, you say, as you dive through the portal. A brilliant ocean expands off in every direction. Finally, you can see again, but all that you see here are more and more Devil Fish, wanting to chomp your flesh and bones. But you just took down their boss blind, deaf, and under immense amounts of actual pressure. You have an inflated sense confidence to handle this situation before returning to your world. Hey, you found a new sense!";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 60) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
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
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 250);
            if (dungeonFloorNum < 25)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 20), 4 , 80);
                else if (rand >= 2500 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 4, 80);
                else if (rand >= 8500 && rand < 9500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 4, 80);
                else if (rand >= 9500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 4, 80);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 25 && dungeonFloorNum < 50)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 20), 5, 70);
                else if (rand >= 2500 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 5, 70);
                else if (rand >= 5000 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 5, 70);
                else if (rand >= 8500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 5, 70);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 50 && dungeonFloorNum < 75)
            {
                if (rand < 500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 20), 6, 60);
                else if (rand >= 500 && rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 6, 60);
                else if (rand >= 2500 && rand < 6500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 6, 60);
                else if (rand >= 6500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 6, 60);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 75 && dungeonFloorNum < 100)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 7, 50);
                else if (rand >= 1000 && rand < 6000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 7, 50);
                else if (rand >= 6000 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 7, 50);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 100 && dungeonFloorNum < 150)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 8, 45);
                else if (rand >= 1000 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 8, 45);
                else if (rand >= 5000 && rand < 9995)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 8, 45);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 150 && dungeonFloorNum < 200)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 9, 40);
                else if (rand >= 1000 && rand < 3000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20), 9, 40);
                else if (rand >= 3000 && rand < 9990)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 20), 9, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
            else
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0), 10, 40);
                else if (rand >= 1000 && rand < 2000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 10, 40);
                else if (rand >= 2000 && rand < 9985)
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 0), 10, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 20));
            }
        }
    }



}
