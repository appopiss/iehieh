using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(5, 8, 0.5f,atkKind.mag);
        initialMAtk *= 0.5;
        initialMDef *= 0.5;
        attackType = AttackType.magic;
        enemyKind = EnemyKind.GreenBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1.5f;
        AttackRange = 150f;
    }

}
