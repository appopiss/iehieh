using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(27, 25, 1.25f, atkKind.mag);
        initialMAtk *= 1.25f;
        initialMDef *= 50;
        initialHp *= 1;
        enemyKind = EnemyKind.BlueFox;
        FoxAwake(0.25);

    }
    private void Start()
    {
        StartEnemy();
    }
}
