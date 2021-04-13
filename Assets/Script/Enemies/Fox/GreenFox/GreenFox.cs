using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(27, 25, 1.5f, atkKind.mag);
        initialMAtk *= 1f;
        initialMDef *= 100;
        initialHp *= 1.5;
        enemyKind = EnemyKind.GreenFox;
        FoxAwake(0.25);

    }
    private void Start()
    {
        StartEnemy();
    }
}
