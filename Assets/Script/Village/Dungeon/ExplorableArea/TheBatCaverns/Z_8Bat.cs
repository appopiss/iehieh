using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8Bat : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.blackBatNum : main.S.hidden_blackBatNum;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batBlackCorridor, "Black Corridor",49, 23, 1800, true,"2-8");
        gameObject.AddComponent<M_clear>().awake(75);
        gameObject.AddComponent<M_other>().awake(76, () => MissionLocal.bat8(target,30), () => target >= 30);
        gameObject.AddComponent<M_onlyBase>().awake(77);    
        gameObject.AddComponent<M_clearNum>().awake(78,50);
        gameObject.AddComponent<M_capture>().awake(79,ENEMY.EnemyKind.BlackBat,25);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 50;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Having smashed the breeding ground for these unearthly bats, you discover one last area in the cave. The unnatural darkness you witnessed outside seems to be emanating from this place, making it incredibly difficult to see. Whatever cursed being entered this world from that dark ritual you witnessed signs of in the sanctuary must lie ahead, waiting for you. You shake off the sense of impending doom, knowing you've had past relationships that scared you worse than this.";
        if (!isDungeon)
        {
            rewardExplain = "- Intact Bat Head\n- <color=green>Bat Heart</color>\n- <color=green>New Challenge\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- Intact Bat Head";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.IntactBatHead);
        main.Log("Gain <color=green>Intact Bat Head");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BatHeart);
            main.Log("Gain <color=green>Bat Heart");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDungeon2 = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Endless Night\"<size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Golem\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

        }
        main.S.unleashDungeon2 = true;

    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    areaDifficultyFactor = 50;
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareBats, new Vector3(0, 0));
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 29:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 34:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 39:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 5, 80);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 6, 70);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 55);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 8, 45);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                    break;
                case 45:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 46:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 47:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 48:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;
                case 49:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 100));
                    break;

                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareBats), new Vector3(-120, 60));
                    break;
            }
        }
    }


}
