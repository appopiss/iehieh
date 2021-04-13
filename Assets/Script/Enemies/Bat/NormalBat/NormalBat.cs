    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class NormalBat : BAT
{

    private void Awake()
    {
        AwakeEnemy(3, 6, 0.5f);
        initialAtk *= 0.5;
        initialDef *= 0.25;
        enemyKind = EnemyKind.NormalBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1f;
    }
    public override void Dead()
    {

        if (main.GameController.currentDungeon == Main.Dungeon.Z_batDarkForest)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.normalBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_normalBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }

}
