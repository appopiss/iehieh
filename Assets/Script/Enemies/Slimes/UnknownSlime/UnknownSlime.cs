using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class UnknownSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(75, 21, 1f);
        enemyKind = EnemyKind.UnknownSlime;

    }
    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;
        AddDrop(ArtiCtrl.MaterialList.BlackPearl, BaseColorDrop()/5);
    }
}
