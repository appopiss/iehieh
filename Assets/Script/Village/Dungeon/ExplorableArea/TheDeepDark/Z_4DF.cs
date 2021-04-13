using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF4, "Submerged City", 0, 65, 900, true,"7-4");
        gameObject.AddComponent<M_clear>().awake(255);
        gameObject.AddComponent<M_clearNum>().awake(256, 100);
        gameObject.AddComponent<M_noEQ>().awake(257);
        gameObject.AddComponent<M_time>().awake(258, 1);
        gameObject.AddComponent<M_gold>().awake(259, 40000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 875;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Swimming further out and even deeper, you discover the remains of a submerged city. It appears to have been fairly affluent, with beautiful statues and impressive columns everywhere. However, the inhabitants that once dwelled here are gone and the Devil Fish infestation of these waters has moved in. There's practically no time to go looting the sunken city because the Devil Fish attacks are relentless. It almost reminds you of all your adoring fans back home, except there aren't any and you just like to imagine that there are. Man, that's depressing.";
        if (!isDungeon)
        {
            rewardExplain = "- Fish Tail\n- <color=green>Small Treasure Chest";
        }
        else
        {
            rewardExplain = "- Fish Tail";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FishTail);
        main.Log("Gain <color=green>Fish Tail");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SmallTreasureChest);
            main.Log("Gain <color=green>Small Treasure Chest");
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
                    InstantiateSeven(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossDevilFish), new Vector3(0, 100));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
