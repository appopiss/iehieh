﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class MBlueSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(30, 32, 1f, atkKind.both);
        initialAtk *= 0;
        initialDef *= 100;
        initialMDef *= 0;
        attackType = AttackType.magic;
        AttackRange = 150f;
        enemyKind = EnemyKind.MBlueslime;
    }
    private void Start()
    {
        StartEnemy();
    }
    int rand;
    public override sealed void Attacking()
    {
        rand = UnityEngine.Random.Range(0, 10000);
        if (CanAttack())
        {
            if (rand < 490)
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.atkDown));
            }
            else if (rand >= 499 && rand < 500)
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.defDown));
            }
            else
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
            }
        }
    }
    public override void SetAbnormal(Attack attack)
    {
        attack.abnormalDamage = 0.25;
    }

}
