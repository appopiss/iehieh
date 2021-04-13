using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Bat : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batRuinedTemple, "Ruined Temple",24, 18, 0, true,"2-3");
        gameObject.AddComponent<M_clear>().awake(50);
        gameObject.AddComponent<M_onlyBase>().awake(51);
        gameObject.AddComponent<M_material>().awake(52,ArtiCtrl.MaterialList.Herb,500);
        gameObject.AddComponent<M_noEQ>().awake(53);
        gameObject.AddComponent<M_time>().awake(54,30);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 1;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "This cave seemed strange the moment you stepped into it, but having ventured a little deeper in you see what appears to be ancient, man-made structures like columns and walls, although they all appear to be worn and degraded to the point they are slowly crumbling apart. From the looks of it, this appears to be an ancient temple. Large, cracked braziers flicker to life at your presence and then burst forth into large flames, illuminating the hall and nearly giving you a heart attack. At least the path is lit, but you're concerned this place is more cursed than you initially thought. The shrill sound of bat shrieks can be heard all around, so it's clear they have infested in this ruined place. You could have been somewhere relaxing today, but instead you're here fighting man-eating bats and spelunking in ruined temples... Mother warned you to make better life choices.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Tooth\n- <color=green>Bat Feet</color>\n- <color=green>New Upgrades";
        }
        else
        {
            rewardExplain = "- Bat Tooth";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatTooth);
        main.Log("Gain <color=green>Bat Tooth");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BatFeet);
            main.Log("Gain <color=green>Bat Feet");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.isUpgradeIcon10 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[5]));
        }
        main.TutorialController.isUpgradeIcon10 = true;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 4, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 4, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 4, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 4, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 4, 80);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, -40), 3, 80);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, -40), 3, 80);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, -40), 3, 80);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, -40), 3, 80);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 4, 80);
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, -40), 3, 80);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 80));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 180),7,60);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 180),7,60);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 180),7,60);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 180),7,60);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 180),7,60);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
