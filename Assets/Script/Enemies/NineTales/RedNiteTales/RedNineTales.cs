using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class RedNineTales : ENEMY
{
    private void Awake()
    {
        AwakeEnemy(8, 4, 0.5f);


    }
    private void Start()
    {
        StartEnemy();
    }


}
