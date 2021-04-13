using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static ALLY.Condition;
using static UsefulMethod;



public class MetalSlime : SLIME
{
    float escapeChance;

    private void Awake()
    {
        AwakeEnemy(1, 1, 1.5f, atkKind.both);
        attackType = AttackType.pyshical;
    }
    private void Start()
    {
        enemyKind = EnemyKind.MetalSlime;
        StartEnemy();
        dodgeRate = (int)Math.Min(9200 + 20*(difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * (level + dungeonLevelFactor) , 9750);
        initialDef = 1e300d;
        initialMDef = 1e300d;
    }
    public override double HP()
    {
        return 3 + dungeonLevelFactor / 10;
    }
    public override double EXP()
    {
        double exp = 0;
        if (main.ally.Level() < 1000)
            exp = Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp() * 1000), main.ally.RequiredExp() * 0.1);
        else if (main.ally.Level() < 2000)
            exp = Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp() * 100), main.ally.RequiredExp() * 0.1);
        else if (main.ally.Level() < 3000)
            exp = Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp() * 50), main.ally.RequiredExp() * 0.1);
        else if (main.ally.Level() < 3300)
            exp =Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp() * 10), main.ally.RequiredExp() * 0.1);
        else if (main.ally.Level() < 3500)
            exp = Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp()), main.ally.RequiredExp() * 0.1);
        else
            exp = Math.Max(Math.Min(100000 * level * (dungeonLevelFactor + 1) * (areaDifficultyFactor * 5 + 1) * (dungeonDifficultyFactor + 1), main.ally.RequiredExp()), main.ally.RequiredExp() * 0.1);
        //IEBBonus
        exp *= (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.expgain]);
        //DLC
        exp *= main.ExpGainDLCFactor();

        exp = Math.Min(exp, 1e306);

        //exp = Math.Min(exp, main.ally.RequiredExp() * 100);
        return exp;
    }
    public override void Attacked()
    {
        int rand = UnityEngine.Random.Range(0, 10000);
        if (rand <= 9000)
            return;
        else if (rand <= 9900)          
            GetAscendPoint(0);
        else if (rand <= 10000)
            GetAscendPoint(1);
    }
    public override IEnumerator Move()
    {
        while (UnityEngine.Random.Range(0,10000)>250)
        {
            switch (condition)
            {
                case MoveMode:
                    Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
                    ActualMove(MoveSpeed);
                    if (vectorAbs(moveDistance) <= AttackRange)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.05f);
                    break;
                case BattleMode:
                    yield return new WaitUntil(() => !isChanting);
                    Attacking();
                    break;
            }

        }

        Vector2 randomVec = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
        for (int i = 0; i < 40; i++)
        {
            thisRect.anchoredPosition += normalize(randomVec) * 10;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

    public override void Dead()
    {
        if (main.GameController.currentDungeon == Main.Dungeon.Z_slimeCastle)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.metalSlimeNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_metalSlimeNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();

        }
        if (main.GameController.currentDungeon == Main.Dungeon.Z_batBreedingGrounds)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.metalSlimeNum2 += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_metalSlimeNum2 += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }

}
