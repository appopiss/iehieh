using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class SkyFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(30, 35, 0.1f, atkKind.mag);
        FoxAwake(0.5);
        initialMAtk *= 0.2f;
        initialMDef *= 20;
        initialHp *= 1.5;
        enemyKind = EnemyKind.SkyFox;

    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 80f;
        MoveSpeed = 7.5f;
    }
}
