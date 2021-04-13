using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Slime : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.activeSkillAt15 : main.S.hidden_activeSkillAt15;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimePools, "The Slime Pools", 29, 12, 0, true,"1-5");
        gameObject.AddComponent<M_clear>().awake(20);
        gameObject.AddComponent<M_clearNum>().awake(21, 200);
        gameObject.AddComponent<M_capture>().awake(22, ENEMY.EnemyKind.OrangeSlime, 20);
        gameObject.AddComponent<M_clearNum>().awake(23, 2000);
        gameObject.AddComponent<M_other>().awake(24,
            () => MissionLocal.slime5(target,250),
            () => target >=250
            );
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 7;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Having emerged from the Pit, you want nothing more than to loose a sigh of relief after that ordeal, but then your eyes behold a terrifying sight as they feel the tinge from the acidic air you now struggle to breathe. Small, murky pools of sludge expand off to the horizon, spawning more and more wretched slimes of various hue. You squint as you step forward, wondering how long you can hold your breath.";
        if (!isDungeon)
        {
            rewardExplain = "- Monster Fluid * 5\n- <color=green>Oil of Slime</color>\n- <color=green>New Content \"REBIRTH\"</color>";
        }
        else
        {
            rewardExplain = "- Monster Fluid * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MonsterFluid,5);
        main.Log("Gain <color=green>Monster Fluid * 5");
        if (!isDungeon)
        {
            isDungeon = true;
            main.TutorialController.ResetMenu();
            main.TutorialController.ShowMenu();
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"REBIRTH\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[0]));

            getMaterial(ArtiCtrl.MaterialList.OilOfSlime);
            main.Log("Gain <color=green>Oil of Slime");
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
        //StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Bat Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
    }

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 4, 100);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 4, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 4, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 40), 4, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 25:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 26:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 27:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 28:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 29:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }



}
