using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(7, 10, 1.5f);
        initialAtk *= 0.75;
        initialDef *= 0.5;
        enemyKind = EnemyKind.RedBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1f;
    }

}
