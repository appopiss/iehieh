using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class MGreenSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(35, 38, 0.75f, atkKind.both);
        initialAtk *= 0;
        initialMAtk *= 0.75;
        initialDef *= 200;
        initialMDef *= 0;
        attackType = AttackType.magic;
        AttackRange = 150f;
        MoveSpeed = 3f;
        enemyKind = EnemyKind.MGreenSlime;
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
        attack.abnormalDamage = 0.005;
    }

}
