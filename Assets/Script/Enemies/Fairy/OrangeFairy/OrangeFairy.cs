using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class OrangeFairy : FAIRY
{
    private void Awake()
    {
        AwakeEnemy(23, 19, 0.2f, atkKind.mag);
        initialMAtk *= 0.1f;
        initialMDef *= 1;
        enemyKind = EnemyKind.OrangeFairy;
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
        MoveSpeed = 2.5f;

    }


}
