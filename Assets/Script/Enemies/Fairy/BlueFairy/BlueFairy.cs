using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(17, 16, 0.1f, atkKind.phys);
        initialAtk *= 0.1f;
        initialDef *= 2;
        enemyKind = EnemyKind.BlueFairy;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 50f;
        MoveSpeed = 4f;

    }



}
