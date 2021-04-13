using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedSlime : SLIME
{

    private void Awake()
    {
        AwakeEnemy(3,4,1.0f);
        initialAtk *= 2;
        initialDef *= 0.5;
        enemyKind = EnemyKind.RedSlime;
    }
    private void Start()
    {
        StartEnemy();
    }

}
