using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;

public class BlueBall : BALL
{
    private void Awake()
    {
        AwakeEnemy(50, 52, 2f, atkKind.both);
        initialHp *= 5f;
        initialAtk *= 5f;
        initialMAtk *= 0;
        initialDef *= 0f;
        initialMDef *= 1e99;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.BlueBlob;
        AttackRange = 80f;
        MoveSpeed = 2f;
    }
    private void Start()
    {
        StartEnemy();
    }


}
