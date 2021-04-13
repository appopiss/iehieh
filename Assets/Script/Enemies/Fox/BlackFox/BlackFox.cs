using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlackFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(30, 35, 1f, atkKind.mag);
        FoxAwake(0.0000001);
        initialMAtk *= 1f;
        initialMDef *= 100;
        initialHp *= 1.5;
        enemyKind = EnemyKind.BlackFox;

    }
    private void Start()
    {
        StartEnemy();
    }
}
