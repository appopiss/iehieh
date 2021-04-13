using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_3Slime : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimePlains, "The Slime Plains", 19, 10, 0, true,"1-3");
        gameObject.AddComponent<M_clear>().MissionId = 10;
        gameObject.AddComponent<M_clearNum>().MissionId = 11;
        gameObject.GetComponent<M_clearNum>().clearNum = 100;
        gameObject.AddComponent<M_capture>().MissionId = 12;
        gameObject.GetComponent<M_capture>().requiredCaptureNum = 25;
        gameObject.GetComponent<M_capture>().TargetEnemy = ENEMY.EnemyKind.BlueSlime;
        gameObject.AddComponent<M_clearNum>().MissionId = 13;
        gameObject.GetComponents<M_clearNum>()[1].clearNum = 500;
        gameObject.AddComponent<M_material>().MissionId = 14;
        gameObject.GetComponent<M_material>().requiredMaterialNum = 5000;
        gameObject.GetComponent<M_material>().TargetMaterial = ArtiCtrl.MaterialList.MonsterFluid;
    }

	// Use this for initialization
	void Start () {
        StartDungeon();
        areaDifficultyFactor = 1;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Beyond the abandoned village is a large stretch of plains, or what would have been plains, had it not been entirely covered in pustule-ridden slime. There is no grass, and the bubbling trunks of liquified trees only slightly distract from the brainless blobs glopping about.";
        if (!isDungeon)
        {
            rewardExplain = "- Monster Fluid * 3\n- <color=green>Gooey Sludge</color>\n- <color=green>New Area</color>\n- <color=green>New Upgrades";
        }
        else
        {
            rewardExplain = "- Monster Fluid * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MonsterFluid,3);
        main.Log("Gain <color=green>Monster Fluid * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.GooeySludge);
            main.Log("Gain <color=green>Gooey Sludge");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.S.isUpgradeIcon11 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[1]));
        }
        main.S.isUpgradeIcon11 = true;

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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120,100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120,100));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 140));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 140));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 140));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -60), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 140));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 140), 3, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 3, 60);
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 140), 3, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 3, 60);
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 140), 3, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 3, 60);
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, -20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 140), 3, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 3, 60);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
