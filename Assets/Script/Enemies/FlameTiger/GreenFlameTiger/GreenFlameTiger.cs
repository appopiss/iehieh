using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenFlameTiger : ENEMY
{
    private void Awake()
    {
        AwakeEnemy(8, 4, 0.5f);


        switch (main.GameController.floorNum)
        {
            default:
                initialHp = 500;
                currentHp = 500;
                initialMAtk = 50;
                initialMDef = 0;
                initialGold = 800;
                break;
        }
    }
    private void Start()
    {
        StartEnemy();
    }

}
