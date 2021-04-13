using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;
using static UsefulMethod;



public class YellowBat : BAT
{
    private void Awake()
    {
        AwakeEnemy(4, 7, 0.5f,atkKind.mag);
        initialMAtk *= 0.5;
        initialMDef *= 0.5;
        attackType = AttackType.magic;
        enemyKind = EnemyKind.YellowBat;
    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 1.5f;
        AttackRange = 150f;
    }
    public override void Dead()
    {
        if (main.GameController.currentDungeon == Main.Dungeon.Z_batCollapsedSanctuary)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.yellowBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_yellowBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }

}
