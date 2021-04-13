using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class OrangeBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(6, 9, 0.5f);
        initialAtk *= 0.5;
        initialDef *= 0.5;
        enemyKind = EnemyKind.OrangeBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 2f;
    }
}
