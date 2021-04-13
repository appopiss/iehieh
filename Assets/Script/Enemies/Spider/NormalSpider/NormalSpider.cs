using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class NormalSpider : SPIDER
{
    private void Awake()
    {
        AwakeEnemy(9,13, 1f,atkKind.both);
        initialAtk *= 1;
        initialMAtk *= 0.5;
        initialDef *= 0.25;
        initialMDef *= 0.25;
        enemyKind = EnemyKind.NormalSpider;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;

    }


}
