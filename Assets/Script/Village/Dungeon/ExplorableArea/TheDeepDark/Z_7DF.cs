using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF7, "Even Deeper", 74, 68, 0, true,"7-7");
        gameObject.AddComponent<M_clear>().awake(270);
        gameObject.AddComponent<M_hp>().awake(271,0.95f);
        gameObject.AddComponent<M_noDmg>().awake(272);
        gameObject.AddComponent<M_clearNum>().awake(273, 5000);
        gameObject.AddComponent<M_time>().awake(274, 30);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 1150;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "More darkness, more underwater death matches with man-eating fish. The darkness doesn't let up, and the water pressure feels like it's compressing your bones and organs like a sculptor works a ball of clay. Still, you are resilient enough to have survived this long! Good thing you didn't try to just hold your breath or you'd have been dead a long time ago.";
        if (!isDungeon)
        {
            rewardExplain = "- Fish Teeth * 3\n- <color=green>Monster Fluid * 8000</color>";
        }
        else
        {
            rewardExplain = "- Fish Teeth * 3";   
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FishTeeth,3);
        main.Log("Gain <color=green>Fish Teeth * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MonsterFluid,8000);
            main.Log("Gain <color=green>Monster Fluid * 8000");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 2, 200);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 2, 200);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 2, 200);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 2, 200);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 20), 2, 200);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 40), 2, 200);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 40), 2, 200);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 40), 2, 200);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 40), 2, 200);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 40), 2, 200);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140), 2, 300);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140), 2, 300);
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140), 2, 300);
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140), 2, 300);
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140), 2, 300);
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 320);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 360);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 360);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 360);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 360);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -160), 2, 360);
                    break;
                case 60:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 10), 2, 360);
                    break;
                case 61:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 10), 2, 360);
                    break;
                case 62:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 10), 2, 360);
                    break;
                case 63:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 10), 2, 360);
                    break;
                case 64:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 10), 2, 360);
                    break;
                case 65:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 66:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 67:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 68:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 69:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 70:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 71:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 72:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 73:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                case 74:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 90), 2, 360);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
