using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider3, "Webbed Foyer",34, 26, 0, true,"3-3");
        gameObject.AddComponent<M_clear>().awake(90);
        gameObject.AddComponent<M_spendTime>().awake(91,8*60*60);
        gameObject.AddComponent<M_material>().awake(92, ArtiCtrl.MaterialList.Berry, 1000);
        gameObject.AddComponent<M_noEQ>().awake(93);
        gameObject.AddComponent<M_time>().awake(94, 25);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 45;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The inside is as unsurprisingly dilapidated as the outside, only there are more webs inside than out. A grand staircase would have welcomed you to the second floor, except that it was entirely collapsed. It's highly possible the second floor will be unexplorable, else you could potentially fall through and injure yourself. Setting your sights on the nearest downstairs doorway, the current inhabitants of the Mansion come out to greet you, fangs dripping with venom. You try to picture them in servants clothing, but it still doesn't make it any less creepy.";
        if (!isDungeon)
        {
            rewardExplain = "- Spider Fang\n- <color=green>Spider Leg</color>\n- <color=green>New Upgrades";
        }
        else
        {
            rewardExplain = "- Spider Fang";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SpiderFang);
        main.Log("Gain <color=green>Spider Fang");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderLeg);
            main.Log("Gain <color=green>Spider Leg");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.isUpgradeIcon7 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[2]));
        }
        main.TutorialController.isUpgradeIcon7 = true;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(40, -100));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(40, -100));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(40, -100));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonSpiders), new Vector3(40, -100));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 5, 80);
                    break;
                case 25:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 5, 80);
                    break;
                case 26:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 5, 80);
                    break;
                case 27:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 5, 80);
                    break;
                case 28:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 7, 40);
                    break;
                case 29:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 7, 40);
                    break;
                case 30:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 7, 40);
                    break;
                case 31:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -60), 7, 40);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(-100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(-100, -100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(100, -100), 3, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 7, 50);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(-100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(-100, -100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonSpiders, new Vector3(100, -100), 3, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 0), 7, 50);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20), 5, 70);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
