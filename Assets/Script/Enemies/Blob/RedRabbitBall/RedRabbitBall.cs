using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedRabbitBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(55, 60, 1f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0f;
        initialDef *= 1e99;
        initialMDef *= 0;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.RedRabbitBlob;
        AttackRange = 80f;
        MoveSpeed = 4f;
    }
    private void Start()
    {
        StartEnemy();
    }
}
