using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class YellowSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(10, 15, 1f, atkKind.both);
        enemyKind = EnemyKind.YellowSpider;
        initialAtk *= 0.5;
        initialMAtk *= 1;
        initialDef *= 0.25;
        initialMDef *= 0.25;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;
        MoveSpeed = 3f;

    }

}
