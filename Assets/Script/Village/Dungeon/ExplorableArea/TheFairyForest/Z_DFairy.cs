using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DFairy: DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairyD, "The Fairies Realm", 999999, 43, 3600, false,"4");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 90);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "As the Fairy Queens lay dead on the floor, the trees behind their thrones part to reveal a doorway containing a familiar swirling vortex of green. Stepping through you find yourself in a seemingly peaceful wood. Fairies are everywhere, doing whatever it is that fairies do with their spare time. When they notice you standing there, gawking at them, they gently set aside what they were doing and then charge at you. That's it, there's no redeeming fairies in your mind anymore. They're just bloodthirsty monsters no different than slimes or man-eating bats. Perhaps you can find something valuable while you're here because you're quickly learning that this world is messed up and nothing is sacred.";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 30) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
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
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 90);
            if (dungeonFloorNum < 25)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 20), 4 , 80);
                else if (rand >= 2500 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 4, 80);
                else if (rand >= 8500 && rand < 9500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 4, 80);
                else if (rand >= 9500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 4, 80);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 25 && dungeonFloorNum < 50)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 20), 5, 70);
                else if (rand >= 2500 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 70);
                else if (rand >= 5000 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 5, 70);
                else if (rand >= 8500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 5, 70);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 50 && dungeonFloorNum < 75)
            {
                if (rand < 500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 20), 6, 60);
                else if (rand >= 500 && rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 60);
                else if (rand >= 2500 && rand < 6500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 6, 60);
                else if (rand >= 6500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 6, 60);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 75 && dungeonFloorNum < 100)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 7, 50);
                else if (rand >= 1000 && rand < 6000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 50);
                else if (rand >= 6000 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 7, 50);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 100 && dungeonFloorNum < 150)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 8, 45);
                else if (rand >= 1000 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 8, 45);
                else if (rand >= 5000 && rand < 9995)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 8, 45);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 150 && dungeonFloorNum < 200)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 9, 40);
                else if (rand >= 1000 && rand < 3000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 9, 40);
                else if (rand >= 3000 && rand < 9990)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 20), 9, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
            else
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 10, 40);
                else if (rand >= 1000 && rand < 2000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 0), 10, 40);
                else if (rand >= 2000 && rand < 9985)
                    InstantiateSquare(ENEMY.MonsterTable.RareFairy, new Vector3(0, 0), 10, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 20));
            }
        }
    }



}
