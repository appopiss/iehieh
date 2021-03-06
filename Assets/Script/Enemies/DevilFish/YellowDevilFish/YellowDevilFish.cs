using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;

using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using MathNet.Numerics.Distributions;



public class YellowDevilFish : DEVILFISH
{
    private void Awake()
    {
        AwakeEnemy(47, 51, 0.1f);
        initialAtk *= 0.25;
        initialHp *= 0.5f;
        initialDef *= 0.5f;
        attackType = AttackType.pyshical;
        enemyKind = EnemyKind.YellowDevilFish;
    }
    private void Start()
    {
        StartEnemy();
        StartCoroutine(Attack());
        thisRect.rotation = new Quaternion(0, 180f, 0, 0);
    }

    float yFactor;
    public override void ActualMove(float factor = 1.0f)
    {
        thisRect.anchoredPosition += new Vector2(1 * factor, yFactor)
            * Convert.ToInt32(!isDebuff[(int)Main.Debuff.freeze]) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.cold]) * 0.5f) * canMove();
    }

    public override IEnumerator Move()
    {
        yFactor = -4;
        while (true)
        {
            if (thisRect.anchoredPosition.x <= -100)
            {
                thisRect.rotation = new Quaternion(0, 180f, 0, 0);
            }
            if (thisRect.anchoredPosition.x >= 100)
            {
                thisRect.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (thisRect.anchoredPosition.y >= 180)
            {
                yFactor = -4;
            }
            else if (thisRect.anchoredPosition.y <= -180)
            {
                yFactor = 4;
            }

            //switch (condition)
            //{
            //    case MoveMode:

            if (thisRect.rotation == new Quaternion(0, 180f, 0, 0))
            {
                ActualMove(8f);
            }
            else
            {
                ActualMove(-8f);
            }
            yield return new WaitForSeconds(0.05f);
            //    break;
            //case BattleMode:
            //    yield return new WaitForSeconds(AttackSpeed());
            //    Attacking();
            //    break;
        }

    }

    public IEnumerator Attack()
    {
        while (true)
        {
            Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
            if (vectorAbs(moveDistance) <= 200)
            {
                Attacking();
            }
            yield return new WaitForSeconds(AttackSpeed());
        }
    }
}
