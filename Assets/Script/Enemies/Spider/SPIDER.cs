using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class SPIDER : ENEMY {
    int rand;

    public override sealed void Attacking()
    {
        rand = UnityEngine.Random.Range(0, 10000);
        if (CanAttack())
        {
            if ( rand < 250)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical, Main.Debuff.poison));
            }
            else if (rand >=250 && rand < 500)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.poison));
            }
            else if (rand >=500 && rand < 750)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical, Main.Debuff.binding));
            }
            else if (rand >=750 && rand < 1000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.binding));
            }
            else if (rand>=1000 && rand < 5500)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
            }
            else if (rand>=5500 && rand < 10000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
            }
        }
    }

    public override void SetAbnormal(Attack attack)
    {
        attack.abnormalDamage = Math.Max(main.ally.currentHp * 0.015,150);
    }
}
