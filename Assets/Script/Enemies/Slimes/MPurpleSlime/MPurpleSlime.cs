using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class MPurpleSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(42, 45, 2.5f, atkKind.both);
        initialHp *= 1.5;
        initialAtk *= 0;
        initialMAtk *= 5;
        initialDef *= 2000;
        initialMDef *= 0;
        attackType = AttackType.magic;
        AttackRange = 150f;
        MoveSpeed = 1.5f;
        enemyKind = EnemyKind.MPurpleSlime;
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
        attack.abnormalDamage = 0.000001;
    }

}
