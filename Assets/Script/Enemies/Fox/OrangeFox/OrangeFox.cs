using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class OrangeFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(25, 21, 1f, atkKind.mag);
        initialMAtk *= 1f;
        initialMDef *= 20;
        initialHp *= 1;
        enemyKind = EnemyKind.OrangeFox;
        FoxAwake(0.5);

    }
    private void Start()
    {
        StartEnemy();
    }
}
