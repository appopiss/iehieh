using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider4, "Dank Dining Hall", 0, 27, 900, true,"3-4");
        gameObject.AddComponent<M_clear>().awake(95);
        gameObject.AddComponent<M_hp>().awake(96, 0.8f);
        gameObject.AddComponent<M_capture>().awake(97, ENEMY.EnemyKind.SpiderQueen, 25);
        gameObject.AddComponent<M_material>().awake(98, ArtiCtrl.MaterialList.SpiderHeart, 50);
        gameObject.AddComponent<M_once>().awake(99);

    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 55;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "What was once a long dining hall, where great feasts were enjoyed, is now just a shadow of what it once was. The table is still set with plates and goblets and even silverware, but under a thick drape of sticky webs. More spiders descend from the ceiling and crawl in from the exterior windows, meaning you will have to pass on trying to loot the dinnerware and focus on remaining off the menu.";
        if (!isDungeon)
        {
            rewardExplain = "- Venom Soaked Cloth\n- <color=green>Spider Heart</color>\n- <color=green>New Content \"Dark Ritual\"</color>";
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
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"Dark Ritual\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[5]));
            getMaterial(ArtiCtrl.MaterialList.SpiderHeart);
            main.Log("Gain <color=green>Spider Heart");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDarkRitual = true;
            main.TutorialController.ResetMenu();
            main.TutorialController.ShowMenu();

        }
        main.S.unleashDarkRitual = true;

    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossSpiders), new Vector3(0, 100));
                    InstantiateSeven(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -120));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
