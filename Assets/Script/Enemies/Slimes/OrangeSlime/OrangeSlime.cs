using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class OrangeSlime : SLIME
{

    private void Awake()
    {
        AwakeEnemy(2,2,0.5f);
        initialDef = 0;
        enemyKind = EnemyKind.OrangeSlime;

    }
    private void Start()
    {
        StartEnemy();
    }

}
