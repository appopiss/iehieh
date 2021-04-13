using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class PurpleFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(23, 19, 1f, atkKind.mag);
        initialMAtk *= 0.5f;
        initialMDef *= 10;
        initialHp *= 2;
        enemyKind = EnemyKind.PurpleFairy;
        attackType = AttackType.magic;

    }


    public override void Attacking()
    {
        if (CanAttack())
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            if (rand < 200)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.mAtkDown));
            }
            else if (rand >= 200 && rand < 1000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.defDown));
            }
            else
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
            }
        }
    }

    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;
        MoveSpeed = 1.25f;

    }


}
