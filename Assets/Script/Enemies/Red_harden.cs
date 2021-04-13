using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_harden : ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */
     
    private void Awake()
    {
        AwakeEnemy(8, 4, 0.5f);

    }
    private void Start()
    {
        StartEnemy();
    }

    public override void Attacked()
    {
        initialDef += 10;
    }

}
