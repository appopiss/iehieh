using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class NormalWood : WOOD
{
    private void Awake()
    {
        AwakeEnemy(25, 8, 1f);

        if (main.GameController.battleMode == GameController.BattleMode.dungeon)
        {
            switch (main.GameController.currentDungeon)
            {
                case Main.Dungeon.sacredFairyCave:
                    initialHp = 50;
                    currentHp = 50;
                    initialAtk = 10;
                    initialDef = 5;
                    initialGold = 100;
                    break;
                default:
                    initialHp = 10;
                    currentHp = 10;
                    initialAtk = 3;
                    initialGold = 20;
                    break;

            }
        }
        else
        {
            switch (main.GameController.floorNum)
            {
                default:
                    initialHp = 2000;
                    currentHp = 2000;
                    initialAtk = 35;
                    initialGold = 1000;
                    break;
            }
        }
    }
    private void Start()
    {
        StartEnemy();
    }


}
