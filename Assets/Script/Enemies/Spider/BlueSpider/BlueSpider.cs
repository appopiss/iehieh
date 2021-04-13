using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(10, 15, 1f, atkKind.both);
        enemyKind = EnemyKind.BlueSpider;
        initialAtk *= 1;
        initialMAtk *= 0.5;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;

    }


}
