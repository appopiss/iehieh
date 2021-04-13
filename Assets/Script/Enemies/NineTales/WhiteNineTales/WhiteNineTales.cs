using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class WhiteNineTales : NINETALES
{
    private void Awake()
    {
        AwakeEnemy(35, 40, 1f, atkKind.mag,true);
        enemyKind = EnemyKind.WhiteNineTailedFox;
        initialMAtk *= 1.5f;
        initialMDef *= 5000;
        initialHp *= 5;

    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 0;
        AttackRange = 1000;
    }
}
