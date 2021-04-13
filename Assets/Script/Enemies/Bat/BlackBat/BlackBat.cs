using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;



public class BlackBat : BAT
{
    public bool isClose;
    private void Awake()
    {
        AwakeEnemy(10, 12, 0.1f, atkKind.both, true);
        initialHp *= 15;
        initialAtk *= 0.15;
        initialMAtk *= 0.15;
        initialDef *= 5;
        initialMDef *= 5;
        enemyKind = EnemyKind.BlackBat;

    }
    private void Start()
    {
        StartEnemy();
        MoveSpeed = 7.5f;
    }
    int rand;
    public override void Attacking()
    {
        rand = UnityEngine.Random.Range(0, 10000);
        if(rand < 5000)
            StartCoroutine(I_AttackObject(main.animationObject[8], targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
        else
            StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
    }
    public override void Dead()
    {
        if (main.GameController.currentDungeon == Main.Dungeon.Z_batBlackCorridor)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.blackBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_blackBatNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }

}
