using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueRabbitBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(55, 60, 1f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0;
        initialDef *= 0f;
        initialMDef *= 1e99;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.BlueRabbitBlob;
        AttackRange = 80f;
        MoveSpeed = 4f;
    }
    private void Start()
    {
        StartEnemy();
    }

}
