using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;
using UnityEngine.UI;
using TMPro;



public class RedFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(24, 20, 0.5f, atkKind.phys);
        initialAtk *= 0.5f;
        initialDef *= 10;
        initialHp *= 1.5;
        enemyKind = EnemyKind.RedFairy;
    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 50f;
        MoveSpeed = 2.5f;

    }

}
