using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class WhiteFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(30, 35, 5f, atkKind.mag);
        FoxAwake(0.05);
        initialMAtk *= 10f;
        initialMDef *= 1000;
        initialHp *= 2;
        enemyKind = EnemyKind.WhiteFox;

    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 500f;
        MoveSpeed = 0;
    }
}
