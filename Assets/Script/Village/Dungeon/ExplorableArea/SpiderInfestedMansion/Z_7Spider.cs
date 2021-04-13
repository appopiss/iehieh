using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider7, "Hedge Maze Entry",54, 30, 0, true,"3-7");
        gameObject.AddComponent<M_clear>().awake(110);
        gameObject.AddComponent<M_clearNum>().awake(111, 150);
        gameObject.AddComponent<M_capture>().awake(112, ENEMY.EnemyKind.PurpleSpider, 50);
        gameObject.AddComponent<M_hp>().awake(113, 0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(114);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 80;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The Hedges in the maze are dead, meaning they have not overgrown very much, though what would have been overgrown is now shrouded with spider webs. The hedge won't support your weight to climb up or over them, but the giant spiders seem to traverse them easily. You hope that this venture is worth the effort, because so far you only have spider guts and slime ooze to show for risking limb and life here. The thought occurs to you to just burn the whole hedge down, but then it'd take hours or even days before the flames would die down for you to continue exploring, and anything valuable in the maze may be turned to ash. You resign to eradicating the spiders the old-fashioned way. Smashing them under your boot... you just need bigger boots.";
        if (!isDungeon)
        {
            rewardExplain = "- Venom Soaked Cloth\n- <color=green>Spider Heart</color>";
        }
        else
        {
            rewardExplain = "- Venom Soaked Cloth";   
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.VenomSoakedCloth);
        main.Log("Gain <color=green>Venom Soaked Cloth");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderHeart);
            main.Log("Gain <color=green>Spider Heart");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 2, 200);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 2, 200);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 2, 200);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 2, 200);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 20), 2, 200);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40), 2, 200);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40), 2, 200);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40), 2, 200);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40), 2, 200);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 40), 2, 200);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140), 2, 300);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140), 2, 300);
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140), 2, 300);
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140), 2, 300);
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140), 2, 300);
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 320);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 360);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 360);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 360);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 360);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -160), 2, 360);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 360);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 360);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 360);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 360);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 10), 2, 360);
                    break;
                case 45:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 46:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 47:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 48:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 49:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 50:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 51:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 52:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 53:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                case 54:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 90), 2, 360);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
