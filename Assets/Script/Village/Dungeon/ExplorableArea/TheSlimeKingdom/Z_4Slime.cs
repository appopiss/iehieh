using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Slime : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimePits, "The Slime Pits", 0, 11, 900, true,"1-4");
        gameObject.AddComponent<M_clear>().awake(15);
        gameObject.AddComponent<M_hp>().awake(16,0.75f);
        gameObject.AddComponent<M_capture>().awake(17, ENEMY.EnemyKind.SlimeBoss, 10);
        gameObject.AddComponent<M_time>().awake(18,2.0f);
        gameObject.AddComponent<M_clearNum>().awake(19,300);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 0;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "With the plains behind you, there is an enormous chasm before you that leaves you no other choice but to trek down into it and climb out on the other side. The walls are slick with iridescent slime, which makes it difficult to traverse, and you can tell already that you won't be leaving this area unscathed. The sounds from below indicate there are numerous slimes that must be dealt with before you will be able to re-emerge again.";
        if (!isDungeon)
        {
            rewardExplain = "- Oil of Slime\n- <color=green>Ancient Coin</color>\n- <color=green>New Upgrades";
        }
        else
        {
            rewardExplain = "- Oil of Slime";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.OilOfSlime);
        main.Log("Gain <color=green>Oil of Slime");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.AncientCoin);
            main.Log("Gain <color=green>Ancient Coin");
            isDungeon = true;
            //main.skillSetController.UnleashSkillSlot();
            //StartCoroutine(main.InstantiateLogText("Extra Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
            //main.TutorialController.SkillSlot();
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.isUpgradeIcon8 = true;//S1
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unlocked!", main.UpStatusSpriteAry[0]));
        }
        main.TutorialController.isUpgradeIcon8 = true;//S1
        //StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Bat Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
    }

    double[] BigSlime = new double[] { 30000, 30, 0, 0, 0, 100, 300 };
    double[] BossSlime = new double[] { 200, 1, 0, 0, 0, 30, 30 };

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                //case 0:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 60), BigSlime);
                //    break;
                case 0:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 0), BigSlime);
                    break;

                //case 0:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                //    break;
                //case 1:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                //    break;
                //case 2:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                //    break;
                //case 3:
                //    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                //    break;
                //case 4:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 60), BigSlime);
                //    break;
                ////case 4:
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                ////    break;
                //case 5:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                //    break;
                //case 6:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                //    break;
                //case 7:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                //    break;
                //case 8:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 9:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 60), BigSlime);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 60), BigSlime);
                //    break;
                ////case 9:
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                ////    break;
                //case 10:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 11:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 12:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 13:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 14:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 0), BigSlime);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 120), BigSlime);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 120), BigSlime);
                //    break;

                ////case 14:
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                ////    break;
                //case 15:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 16:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 17:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 18:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 19:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 60),BossSlime);
                //    break;
                ////case 19:
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                ////    break;
                //case 20:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 40);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 21:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 40);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 22:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 40);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 23:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 40);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                //case 24:
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 100), BossSlime);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 0), BigSlime);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 0), BigSlime);
                //    break;
                ////case 24:
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 8, 40);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 6, 60);
                ////    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 7, 40);
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSlimes), new Vector3(120, 60));
                ////    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSlimes), new Vector3(-120, 60));
                ////    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }



}
