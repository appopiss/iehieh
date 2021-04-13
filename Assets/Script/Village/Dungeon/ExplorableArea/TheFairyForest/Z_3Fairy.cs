using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Fairy : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairy3, "Hidden Path", 34, 37, 0, true,"4-3");
        gameObject.AddComponent<M_clear>().awake(130);
        gameObject.AddComponent<M_onlyBase>().awake(131);
        gameObject.AddComponent<M_material>().awake(132, ArtiCtrl.MaterialList.MagicSeed, 1000);
        gameObject.AddComponent<M_noEQ>().awake(133);
        gameObject.AddComponent<M_time>().awake(134, 25);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 85;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Having slain even more fairies, and destroying every image of them you carried with you from childhood, you discover a hidden path in the woods where the last group emerged from. Peering down the path, it appears to have some sort of magical shroud effect, which you conclude may prevent it from being accidentally discovered. Good thing they gave it away by coming right out of it for you. There are no other sounds on this path, as though the songs of the birds cannot penetrate the shroud, except for the slight, rapid sound of Fairy wings. This could be an ambush, but you've no other choice but to explore it. The thought then occurs to you... what if Unicorns aren't as nice as you thought? No, you won't let them take that away from you!";
        if (!isDungeon)
        {
            rewardExplain = "- Fairy Wing\n- <color=green>Fairy Coin</color>";
        }
        else
        {
            rewardExplain = "- Fairy Wing";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FairyWing);
        main.Log("Gain <color=green>Fairy Wing");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FairyCoin);
            main.Log("Gain <color=green>Fairy Coin");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            //main.TutorialController.isUpgradeIcon7 = true;
            //main.TutorialController.ResetUpgradeIcon();
            //main.TutorialController.ShowUpgradeIcon();
            //StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[2]));
        }
        //main.TutorialController.isUpgradeIcon7 = true;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 5, 80);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 5, 80);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 5, 80);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 5, 80);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(40, -100));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(40, -100));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(40, -100));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(40, -100));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 5, 80);
                    break;
                case 25:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 5, 80);
                    break;
                case 26:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 5, 80);
                    break;
                case 27:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 5, 80);
                    break;
                case 28:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 7, 40);
                    break;
                case 29:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 7, 40);
                    break;
                case 30:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 7, 40);
                    break;
                case 31:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 7, 40);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(-100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(-100, -100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(100, -100), 3, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 7, 50);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(-100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(100, 100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(-100, -100), 3, 50);
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(100, -100), 3, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 7, 50);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, 20), 5, 70);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
