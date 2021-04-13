using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_DSpider: DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spiderD, "The Web Wide World", 999999, 34, 3000, false,"3");
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
        dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 70);
        isDungeon = true;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "As the giant spider rolls over onto its back, legs cringing and curling up into its body, the giant web where it once stood swirls and contorts into a swirling vortex. You dread the thought of where this portal could lead, but you're feeling pretty confident after slaying that spider boss. The portal leads to a giant system of complex webs. If there is a sky here, you cannot see it because thousands of layers of webs cascade above you, and it is the same situation beneath you as well. Everything is connected by webs, which are occupied by their builders and who have felt the vibrations of your arrival. Thankfully the webs are not very sticky, and are sturdy enough to hold your weight. If this is where all of those spiders came from, then you'd be doing the world a favor by getting rid of as many as you can before you head back home.";
        rewardExplain = "- Monster Level : " + (dungeonLevelFactor + 20) + " ( increased according to your Level )\n- Max Wave reached : " + (maxDungeonFloorNum);
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
            dungeonLevelFactor = Math.Min(Math.Max(main.ally.Level() - 50, 0), 70);
            if (dungeonFloorNum < 25)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 20), 4 , 80);
                else if (rand >= 2500 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 4, 80);
                else if (rand >= 8500 && rand < 9500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 4, 80);
                else if (rand >= 9500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 80);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 25 && dungeonFloorNum < 50)
            {
                if (rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 20), 5, 70);
                else if (rand >= 2500 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 5, 70);
                else if (rand >= 5000 && rand < 8500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 5, 70);
                else if (rand >= 8500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 70);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 50 && dungeonFloorNum < 75)
            {
                if (rand < 500)
                    InstantiateSquare(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 20), 6, 60);
                else if (rand >= 500 && rand < 2500)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 60);
                else if (rand >= 2500 && rand < 6500)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 6, 60);
                else if (rand >= 6500 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 6, 60);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 75 && dungeonFloorNum < 100)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 7, 50);
                else if (rand >= 1000 && rand < 6000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 7, 50);
                else if (rand >= 6000 && rand < 9999)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 7, 50);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 100 && dungeonFloorNum < 150)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 8, 45);
                else if (rand >= 1000 && rand < 5000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 8, 45);
                else if (rand >= 5000 && rand < 9995)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 8, 45);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else if (dungeonFloorNum >= 150 && dungeonFloorNum < 200)
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 9, 40);
                else if (rand >= 1000 && rand < 3000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 9, 40);
                else if (rand >= 3000 && rand < 9990)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 9, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
            else
            {
                if (rand < 1000)
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 10, 40);
                else if (rand >= 1000 && rand < 2000)
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 10, 40);
                else if (rand >= 2000 && rand < 9985)
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 0), 10, 40);
                else
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 20));
            }
        }
    }



}
