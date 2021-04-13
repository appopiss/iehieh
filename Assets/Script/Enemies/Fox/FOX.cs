using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class FOX : ENEMY     {

    int rand;
    double debuffAmount;
    public void FoxAwake(double debuffAmount)
    {
        attackType = AttackType.magic;
        this.debuffAmount = debuffAmount;
        AttackRange = 80f;
        MoveSpeed = 2f;
    }
    public override sealed void Attacking()
    {
        rand = UnityEngine.Random.Range(0, 10000);
        if (CanAttack())
        {
            if (rand < 490)
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.mAtkDown));
            }
            else if (rand >= 490 && rand < 500)
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
        attack.abnormalDamage = debuffAmount;
    }

}
