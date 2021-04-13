using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(28, 27, 2f, atkKind.mag);
        initialMAtk *= 7.5f;
        initialMDef *= 10;
        initialHp *= 0.5;
        enemyKind = EnemyKind.RedFox;
        FoxAwake(0.1);

    }
    private void Start()
    {
        StartEnemy();
    }
}
