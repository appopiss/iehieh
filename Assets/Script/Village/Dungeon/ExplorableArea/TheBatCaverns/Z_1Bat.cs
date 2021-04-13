using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1Bat : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.normalBatNum : main.S.hidden_normalBatNum;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batDarkForest, "The Dark Forest",14, 16, 0, true,"2-1");
        gameObject.AddComponent<M_clear>().awake(40);
        gameObject.AddComponent<M_material>().awake(41,ArtiCtrl.MaterialList.BatWing,500);
        gameObject.AddComponent<M_other>().awake(42, () => MissionLocal.bat1(target), () => target >= 2000);
        gameObject.AddComponent<M_gold>().awake(43,2500);
        gameObject.AddComponent<M_time>().awake(44,10);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = -2;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The forest before you has a seriously ominous feel to it. The sky above the forest looms with some sort of magical darkness, casting the forest into a state of perpetual night. Small silhouettes can be seen in the sky above, occasionally swooping down into the canopy of the trees. The local villages have reported being attacked at night by the unnatural species of bats that dwell within this forest, and you were tasked with putting a stop to it. You can't help but wonder why people would choose to live so close to a cursed place like this.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Pelt\n- <color=green>Bat Wing</color>\n- <color=green>New Upgrades</color>";
        }
        else
        {
            rewardExplain = "- Bat Pelt";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatPelt);
        main.Log("Gain <color=green>Bat Pelt");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BatWing);
            main.Log("Gain <color=green>Bat Wing");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.S.isUpgradeIcon4 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[1]));
        }
        main.S.isUpgradeIcon4 = true;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 120), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 100), 3, 120);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 40), 3, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 120), 5, 60);
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.NormalBats, new Vector3(0, 0));
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 120), 5, 60);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.NormalBats, new Vector3(0, 60));
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20));
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.NormalBats, new Vector3(0, -20));
                    break;
                case 9:
                    InstantiateNine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -20));
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -20));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -20));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 5, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 100), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -60), 3, 100);
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 5, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 100), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -60), 3, 100);
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 20), 5, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 100), 4, 90);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, -60), 3, 110);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalBats, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
