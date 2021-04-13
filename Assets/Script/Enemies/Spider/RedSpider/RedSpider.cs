using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(12, 18, 1f, atkKind.both);
        initialAtk *= 2;
        initialDef *= 0.5;
        enemyKind = EnemyKind.RedSpider;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;

    }


}
