using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(11, 16, 0.5f, atkKind.both);
        initialAtk *= 0.5;
        initialMAtk *= 0.5;
        initialDef *= 0.25;
        initialMDef *= 0.25;
        enemyKind = EnemyKind.GreenSpider;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;
        MoveSpeed = 6f;

    }
}
