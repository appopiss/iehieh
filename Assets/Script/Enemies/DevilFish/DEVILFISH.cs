using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEVILFISH : ENEMY
{
    // Start is called before the first frame update
    void Start()
    {
        AttackRange = 200f;
        dodgeRate = 500;
        phyDodgeRate = 7500;
    }

    public override void Attacked()
    {
        if(phyDodgeRate>=500)
        phyDodgeRate -= 50;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attacking()
    {
        if (CanAttack())
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            if (rand < 500)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical,Main.Debuff.atkDown));
            }
            else if(rand>=500 && rand < 1000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical, Main.Debuff.mAtkDown));
            }
            else if(rand>=1000 && rand < 1500)
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
        attack.abnormalDamage = 0.25;//10%の意味
    }

}
