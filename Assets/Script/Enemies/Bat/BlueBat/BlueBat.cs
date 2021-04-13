using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(4, 7, 0.75f);
        initialAtk *= 0.5;
        initialDef *= 0.5;
        enemyKind = EnemyKind.BlueBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1f;
    }
    public override void Attacking()
    {
        if (CanAttack())
        {
            StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
        }
    }
}
