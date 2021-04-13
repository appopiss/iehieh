﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueCatBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(55, 55, 1f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0;
        initialDef *= 0f;
        initialMDef *= 1e99;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.BlueCatBlob;
        AttackRange = 80f;
        MoveSpeed = 3f;
    }
    private void Start()
    {
        StartEnemy();
    }


}
