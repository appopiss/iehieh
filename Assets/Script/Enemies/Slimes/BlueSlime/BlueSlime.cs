using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlueSlime : SLIME
{

    private void Awake()
    {
        AwakeEnemy(1,2,1.0f);
        enemyKind = EnemyKind.BlueSlime;
    }
    private void Start()
    {
        StartEnemy();
    }
}
