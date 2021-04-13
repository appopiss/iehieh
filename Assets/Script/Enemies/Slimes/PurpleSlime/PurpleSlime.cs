using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class PurpleSlime : SLIME
{

    private void Awake()
    {
        AwakeEnemy(4,5,1f);
        initialDef *= 1.5;
        initialHp *= 3;
        enemyKind = EnemyKind.PurpleSlime;
    }
    private void Start()
    {
        StartEnemy();
    }
    public override void Dead()
    {

        if (main.GameController.currentDungeon == Main.Dungeon.Z_slimeCastle)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.purpleSlimeNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_purpleSlimeNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }


}
