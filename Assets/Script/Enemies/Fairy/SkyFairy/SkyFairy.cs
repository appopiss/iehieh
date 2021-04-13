using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class SkyFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(15, 15,0.1f, atkKind.phys);
        initialAtk *= 0.1f;
        initialDef *= 0.5;
        enemyKind = EnemyKind.NormalFairy;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 50f;
        MoveSpeed = 4f;

    }


}
