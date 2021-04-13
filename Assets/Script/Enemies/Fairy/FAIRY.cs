using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class FAIRY : ENEMY {


    public override void Attacking()
    {
        if (CanAttack())
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            if (rand < 100)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical, Main.Debuff.atkDown));
            }
            else if (rand >= 100 && rand < 200)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical, Main.Debuff.defDown));
            }
            else
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
            }
        }
    }

    public override void SetAbnormal(Attack attack)
    {
        attack.abnormalDamage = 0.25;//25%の意味
    }
}
