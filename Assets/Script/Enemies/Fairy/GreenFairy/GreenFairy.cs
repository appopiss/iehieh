using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(21, 18, 0.1f, atkKind.phys);
        initialAtk *= 0.1f;
        initialDef *= 2;
        enemyKind = EnemyKind.GreenFairy;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 50f;
        MoveSpeed = 5f;

    }

}
