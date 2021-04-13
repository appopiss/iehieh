using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class YellowSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(1, 2, 0.5f);
        initialAtk = 5;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 3f;
    }
}
