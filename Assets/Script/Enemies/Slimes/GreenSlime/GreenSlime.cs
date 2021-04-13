using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenSlime : SLIME
{

    private void Awake()
    {
        AwakeEnemy(2, 3, 1.0f);
        initialDef *= 0.5;
        enemyKind = EnemyKind.GreenSlime;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1.5f;
    }

}
