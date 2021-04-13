using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class BlackFlameTiger : ENEMY
{
    private void Awake()
    {
        AwakeEnemy(25, 8, 1f);
    }

}
