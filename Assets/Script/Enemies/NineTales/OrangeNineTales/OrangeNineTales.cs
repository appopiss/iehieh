using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class OrangeNineTales : ENEMY
{
    private void Awake()
    {
        AwakeEnemy(25, 8, 1f);



    }
    private void Start()
    {
        StartEnemy();
    }

}
