using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider8, "Spider King's Court", 59, 31, 1800, true,"3-8");
        gameObject.AddComponent<M_clear>().awake(115);
        gameObject.AddComponent<M_capture>().awake(116, ENEMY.EnemyKind.PurpleSpider, 15);
        gameObject.AddComponent<M_onlyBase>().awake(117);
        gameObject.AddComponent<M_noEQ>().awake(118);
        gameObject.AddComponent<M_clearNum>().awake(119, 100);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 95;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The maze terminates in a large courtyard that has more webs than anywhere else. Very large and colorful spiders are perched around the yard, with one enormous spider resting in the center. Finally, a spider boss! Now you may have a chance at loot, you think to yourself. The largest spider hisses loudly, prompting the large, colorful spiders to race at you, venom dripping from their clattering fangs. It's too late to regret your hunger for treasure, and escape is impossible, so you'll have to eradicate these spiders and finish the job. Too bad no one lives here to pay your fee for a job well done.";
        if (!isDungeon)
        {
            rewardExplain = "- Spider Heart\n- <color=green>Webbed Core</color>\n- <color=green>New Challenge\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- Spider Heart";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SpiderHeart);
        main.Log("Gain <color=green>Spider Heart");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.WebbedCore);
            main.Log("Gain <color=green>Webbed Core");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDungeon3 = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Web Wide World\"<size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Deathpider\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

        }
        main.S.unleashDungeon3 = true;

    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    areaDifficultyFactor = 90;
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0));
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 0));
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSpiders), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 29:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 34:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 39:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 41:
                    areaDifficultyFactor += 1;
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20),8, 40);
                    break;
                case 43:
                    areaDifficultyFactor += 1;
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20),  8);
                    break;
                case 45:
                    areaDifficultyFactor += 1;
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20),  8);
                    break;
                case 47:
                    areaDifficultyFactor += 1;
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 8);
                    break;
                case 49:
                    areaDifficultyFactor += 1;
                    InstantiateSquare(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20),  8);
                    break;
                case 51:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 53:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 55:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 57:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;
                case 59:
                    areaDifficultyFactor += 1;
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    break;

                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareSpiders), new Vector3(-120, 60));
                    break;
            }
        }
    }


}
