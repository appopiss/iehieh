using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8Slime : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.slimeBossNum : main.S.hidden_slimeBossNum;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimeThroneRoom, "Slime Throne Room", 49, 15, 1800, true,"1-8");
        gameObject.AddComponent<M_clear>().awake(35);
        gameObject.AddComponent<M_other>().MissionId = 36;
        gameObject.GetComponent<M_other>().otherText
            = () => MissionLocal.slime8(target,50);
        gameObject.GetComponent<M_other>().ClearCondition = () => target >= 50;
        gameObject.AddComponent<M_noEQ>().awake(37);
        gameObject.AddComponent<M_capture>().awake(38,ENEMY.EnemyKind.SlimeBoss,30);
        gameObject.AddComponent<M_clearNum>().awake(39,100);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 25;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "You've mucked your way all the way to what you imagine to be the throne room of this castle of slimes. Giant slimes seem to detect your presence and move in with their acidic hunger slurping at you. Beyond them you can see a large writhing mass at the back of the room, with a surprisingly shiny crown sitting atop it. Destroying that thing is clearly your goal, but you can't help but wonder if you are going to stink forever now.";
        if (!isDungeon)
        {
            rewardExplain = "- Slime Eye Ball\n- <color=green>Slime Crown</color>\n- <color=green>New Contents \"CHALLENGE\"\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- Slime Eye Ball";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SlimeEyeBall);
        main.Log("Gain <color=green>Slime Eye Ball");
        if (!isDungeon)
        {
            isDungeon = true;
            getMaterial(ArtiCtrl.MaterialList.SlimeCrown);
            main.Log("Gain <color=green>Slime Crown");
            main.TutorialController.ResetMenu();
            main.TutorialController.ShowMenu();

            main.S.unleashDungeon1 = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Slime Spawn Pools\"<size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"CHALLENGE\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));
        }
        isDungeon = true;
        main.S.unleashDungeon1 = true;
    }
    double[] BigSlime = new double[] { 5000, 20, 0, 0, 0, 100, 200 };
    double[] BossSlime = new double[] { 500, 5, 0, 0, 0, 30, 30 };
    double[] BossSlime2 = new double[] { 700, 6, 0, 0, 0, 35, 35 };
    double[] BossSlime3 = new double[] { 1000, 7, 0, 0, 0, 40, 40 };


    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 60), BigSlime);
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 60), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 60), BigSlime);
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 120), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 120), BigSlime);
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 0), BossSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 120), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 120), BigSlime);
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-120, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(120, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, -60), BigSlime);
                    break;
                case 29:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-150, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(150, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-50, -60), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(50, -60), BigSlime);
                    break;
                case 34:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-150, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(150, 0), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(-50, -60), BigSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(50, -60), BigSlime);
                    break;
                case 39:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    InstantiateFiveUnder(ENEMY.MonsterTable.BigSlime, new Vector3(0, -60), BigSlime);
                    break;
                case 40:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    break;
                case 41:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    break;
                case 42:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    break;
                case 43:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    break;
                case 44:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime);
                    break;
                case 45:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime2);
                    break;
                case 46:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime2);
                    break;
                case 47:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime3);
                    break;
                case 48:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(0, 100), BossSlime3);
                    break;
                case 49:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(-100, 50), BossSlime3);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSlimes), new Vector3(100, 50), BossSlime3);
                    break;

                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSlimes), new Vector3(-120, 60));
                    break;
            }
        }
    }



}
