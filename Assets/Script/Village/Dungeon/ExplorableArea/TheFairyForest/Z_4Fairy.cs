using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Fairy : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairy4, "Wild Overgrowth", 0, 38, 900, true,"4-4");
        gameObject.AddComponent<M_clear>().awake(135);
        gameObject.AddComponent<M_noDmg>().awake(136);
        gameObject.AddComponent<M_capture>().awake(137, ENEMY.EnemyKind.BlackFairy, 10);
        gameObject.AddComponent<M_time>().awake(138, 2f);
        gameObject.AddComponent<M_timeOver>().awake(139, 5*60);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 100;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The path ends into a wild overgrowth that appears to form some type of wall. Slashing through the overgrowth reveals a maze-like system beyond it. The fairies here seem stronger overall than the ones you've encountered previously, and now you've got to find your way through a maze on top of that. It appears that the flora isn't attacking you, though, so there's at least that bonus!";
        if (!isDungeon)
        {
            rewardExplain = "- Blood of Fairy\n- <color=green>Fairy Heart</color>\n-<color=green> New Upgrades";
        }
        else
        {
            rewardExplain = "- Blood of Fairy";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BloodOfFairy);
        main.Log("Gain <color=green>Blood of Fairy");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FairyHeart);
            main.Log("Gain <color=green>Fairy Heart");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.TutorialController.isUpgradeIcon9 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unlocked!", main.UpCrystalSpriteAry[6]));

        }
        main.TutorialController.isUpgradeIcon9 = true;


    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFairy), new Vector3(0, 100));
                    InstantiateSeven(ENEMY.MonsterTable.RareFairy, new Vector3(0, -120));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
