using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedCatBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(55, 55, 1f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0f;
        initialDef *= 1e99;
        initialMDef *= 0;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.RedCatBlob;
        AttackRange = 80f;
        MoveSpeed = 3f;
    }
    private void Start()
    {
        StartEnemy();
    }
}
