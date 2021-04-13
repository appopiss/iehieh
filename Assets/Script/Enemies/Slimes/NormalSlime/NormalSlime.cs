using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class NormalSlime : SLIME
{
    private void Awake()
    {
        AwakeEnemy(1,1,1.0f);
        initialDef = 0;
    }
    private void Start()
    {        
        StartEnemy();
    }
}
