using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static ALLY.Condition;
using static UsefulMethod;



public class PinkSpider : SPIDER//これがスパイーダクイーン
{
    private void Awake()
    {
        AwakeEnemy(15, 25, 2f, atkKind.both, true);
        initialAtk *= 2;
        initialMAtk *= 2;
        initialDef *= 1.5;
        initialMDef *= 1.5;
        enemyKind = EnemyKind.SpiderQueen;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 300f;

    }
    public override void SetAbnormal(Attack attack)
    {
        attack.abnormalDamage = Math.Max(main.ally.currentHp * 0.02, 300);
    }



}
