using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;
using UnityEngine.UI;
using TMPro;



public class BigSlime : SLIME
{

    float attackSpeed;
    bool isAttackedByNotBase;

    private void Awake()
    {
        AwakeEnemy(1,1, 2f,atkKind.phys,true);
        enemyKind = EnemyKind.BigSlime;
    }

        private void Update()
    {
    }

    private void Start()
    {
        StartEnemy();
        AttackRange = 120f;
    }

    public override IEnumerator Move()
    {
        while (true)
        {

            switch (condition)
            {
                case MoveMode:
                    Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
                    ActualMove(0.4f);
                    if (vectorAbs(moveDistance) <= 100)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.05f);
                    break;
                case BattleMode:
                    yield return new WaitForSeconds(AttackSpeed());
                    Attacking();
                    break;
            }

        }
    }

    public override void Dead()
    {
        if (main.quests[(int)ACHIEVEMENT.QuestList.PetheticMan].isSeen[2] && !main.S.isPoppy && UnityEngine.Random.Range(0, 10000) < 100)
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.PoppyWinstonNeckless] += 1;
            main.Log("Gained <color=green>" + ArtiCtrl.MaterialList.PoppyWinstonNeckless);
        }

        if (!isAttackedByNotBase && main.GameController.currentDungeon == Main.Dungeon.slimeHideout)
        {
            if(!main.ZoneCtrl.isHidden)
                main.S.bigSlimeNumByBase += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_bigSlimeNumByBase += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }
    }

    public override void Attacked()
    {
        if (!main.missionCondition.isOnlyBase())
        {
            isAttackedByNotBase = true;
        }
    }
}