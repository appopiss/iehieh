using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;

public class BlueCatBoss : ENEMY
{
    private void Awake()
    {
        AwakeEnemy(25, 8, 1f);
    }
    private void Start()
    {
        StartEnemy();
    }

    public override void Attacking()
    {
        if (CanAttack())
        {
          StartCoroutine(main.InstantiateAnimation(main.animationObject[8], targetEnemyPosition, initialAtk,0,SKILL.DamageKind.physical));
        }
    }

    public override IEnumerator Move()
    {
        while (true)
        {

            switch (condition)
            {
                case MoveMode:
                    Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
                    //thisRect.anchoredPosition += normalize(moveDistance) * 3.0f;
                    if (vectorAbs(moveDistance) <= 50)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.1f);
                    break;
                case BattleMode:
                    yield return new WaitForSeconds(AttackSpeed());
                    Attacking();
                    break;
            }
          
        }
    }

}
