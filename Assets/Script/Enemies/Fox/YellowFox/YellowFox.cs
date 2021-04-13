using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class YellowFox : FOX
{
    private void Awake()
    {
        AwakeEnemy(26, 23, 0.5f, atkKind.mag);
        initialMAtk *= 0.75f;
        initialMDef *= 15;
        initialHp *= 0.5;
        enemyKind = EnemyKind.YellowFox;
        FoxAwake(0.5);

    }
    private void Start()
    {
        StartEnemy();
    }
}
