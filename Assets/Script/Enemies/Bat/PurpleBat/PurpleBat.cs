using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class PurpleBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(8, 11, 1f,atkKind.both);
        initialAtk *= 1;
        initialMAtk *= 1;
        initialDef *= 0.5;
        initialMDef *= 0.5;
        enemyKind = EnemyKind.PurpleBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1f;
    }
    public override void Attacking()
    {
        int rand = UnityEngine.Random.Range(0, 10000);
        if (CanAttack())
        {
            if (rand <= 5000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
            }
            else
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
            }
        }
    }
}
