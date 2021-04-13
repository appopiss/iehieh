using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;

public class RedBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(50, 52, 2f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0f;
        initialDef *= 1e99;
        initialMDef *= 0;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.RedBlob;
        AttackRange = 80f;
        MoveSpeed = 2f;
    }
    private void Start()
    {
        StartEnemy();
    }
}
