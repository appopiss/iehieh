using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;
using UnityEngine.UI;
using TMPro;



public class SlimeBoss : SLIME
{

    float attackSpeed;

    private void Awake()
    {
        AwakeEnemy(5,8, 1.25f,atkKind.phys,true);
        initialDef *= 0.5;
        initialHp *= 5;
        enemyKind = EnemyKind.SlimeBoss;
    }

        private void Update()
    {
    }

    private void Start()
    {
        StartEnemy();
        AttackRange = 150f;
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
                    if (vectorAbs(moveDistance) <= 150)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.05f);
                    break;
                case BattleMode:
                    yield return new WaitForSeconds(AttackSpeed());
                    Attacking();
                    //Debug.Log("Attacking!");
                    break;
            }

        }
    }

    public override void Dead()
    {
        if(main.quests[(int)ACHIEVEMENT.QuestList.PetheticMan].isSeen[2] && !main.S.isPoppy && UnityEngine.Random.Range(0, 10000) < 5000) 
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.PoppyWinstonNeckless] += 1;
            main.Log("Gained <color=orange>" + ArtiCtrl.MaterialList.PoppyWinstonNeckless);
            main.sound.MustPlaySound(main.sound.levelUpClip);
            main.S.isPoppy = true;
        }
        if (main.GameController.currentDungeon == Main.Dungeon.Z_slimeThroneRoom)
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.slimeBossNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
            else
                main.S.hidden_slimeBossNum += 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
        }

    }
}