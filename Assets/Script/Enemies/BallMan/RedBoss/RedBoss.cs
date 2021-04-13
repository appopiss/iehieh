using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedBoss : ENEMY
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
        if (targetEnemy.GetComponent<ALLY>().currentHp > 0)
        {
            StartCoroutine(main.InstantiateAnimation(main.animationObject[19], targetEnemyPosition, initialMAtk, 0, SKILL.DamageKind.magical));
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
                    //  thisRect.anchoredPosition += normalize(moveDistance) * 3.0f;
                    if (vectorAbs(moveDistance) <= 150)
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
