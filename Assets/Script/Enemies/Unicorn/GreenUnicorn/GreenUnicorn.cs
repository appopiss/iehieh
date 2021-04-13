using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class GreenUnicorn : UNICORN
{
    private void Awake()
    {
        AwakeEnemy(25, 8, 1f);

    }


}
