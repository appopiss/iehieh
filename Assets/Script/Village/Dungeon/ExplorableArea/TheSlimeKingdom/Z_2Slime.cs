using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Slime : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimeVillage, "The Slime Village", 14, 9, 0, true,"1-2");
        gameObject.AddComponent<M_clear>().MissionId = 5;
        gameObject.AddComponent<M_hp>().MissionId = 6;
        gameObject.GetComponent<M_hp>().HP = 0.95f;
        gameObject.AddComponent<M_clearNum>().MissionId = 7;
        gameObject.GetComponent<M_clearNum>().clearNum = 400;
        gameObject.AddComponent<M_capture>().MissionId = 8;
        gameObject.GetComponent<M_capture>().TargetEnemy = ENEMY.EnemyKind.NormalSlime;
        gameObject.GetComponent<M_capture>().requiredCaptureNum = 10;
        gameObject.AddComponent<M_spendTime>().MissionId = 9;
        gameObject.GetComponent<M_spendTime>().requiredSpendTime = 3600 * 8;
    }

	// Use this for initialization
	void Start () {
        StartDungeon();
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "An old abandoned village once stood here, but it is now overrun with oozing slimes. You hear a lot of sloshing sounds as the slimes mindlessly meander the town. At least the air quality here is better, though it still is far from pleasant.";
        if (!isDungeon)
        {
            rewardExplain = "- Ooze Stained Cloth\n- <color=green>Gooey Sludge</color>\n- <color=green>New Content \"QUEST\"</color>\n- <color=green>New Upgrades";
        }
        else
        {
            rewardExplain = "- Ooze Stained Cloth";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.OozeStainedCloth);
        main.Log("Gain <color=green>Ooze Stained Cloth");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.GooeySludge);
            main.Log("Gain <color=green>Gooey Sludge");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.ResetMenu();
            main.TutorialController.ShowMenu();
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"QUEST\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));
            main.TutorialController.isUpgradeIcon5 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStatusSpriteAry[6]));
        }
        main.TutorialController.isUpgradeIcon5 = true;
        //StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Bat Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 100), 3, 120);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 5, 60);
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 0));
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 5, 60);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 60));
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20));
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20));
                    break;
                case 9:
                    InstantiateNine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20));
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 5, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 100), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 3, 100);
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 5, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 100), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 3, 100);
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 5, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 100), 4, 90);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 3, 110);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
