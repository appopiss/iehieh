using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_C : ENEMY
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
