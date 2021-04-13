using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class PurpleSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(14, 22, 1f, atkKind.both);
        initialDef *= 1.5;
        initialHp *= 3;
        enemyKind = EnemyKind.PurpleSpider;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 180f;

    }


}
