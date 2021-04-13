using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class MOrangeSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(37, 40, 2f, atkKind.both);
        initialAtk *= 0;
        initialMAtk *= 2.5;
        initialDef *= 500;
        initialMDef *= 0;
        attackType = AttackType.magic;
        AttackRange = 150f;
        MoveSpeed = 1f;
        enemyKind = EnemyKind.MOrangeSlime;
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
        attack.abnormalDamage = 0.0001;
    }
}
