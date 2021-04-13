using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class PurpleFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(29, 30, 2.5f, atkKind.mag);
        FoxAwake(0.1);
        initialMAtk *= 3f;
        initialMDef *= 200;
        initialHp *= 1.5;
        enemyKind = EnemyKind.PurpleFox;

    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 300f;
    }
}
