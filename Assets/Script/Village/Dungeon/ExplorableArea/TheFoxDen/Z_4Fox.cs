using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox4, "Guard Room", 0, 47, 900, true, "5-4");
        gameObject.AddComponent<M_clear>().awake(175);
        gameObject.AddComponent<M_hp>().awake(176, 0.95f);
        gameObject.AddComponent<M_capture>().awake(177, ENEMY.EnemyKind.WhiteNineTailedFox, 50);
        gameObject.AddComponent<M_material>().awake(178, ArtiCtrl.MaterialList.FoxCore, 10);
        gameObject.AddComponent<M_timeOver>().awake(179, 600);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 225;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The dizziness suddenly wears off as you make your way into a large room. The room itself is unremarkable. Just big dirt walls with an oddly unspecific ambient light source. There is definitely some twisted magic in this place. The room appears occupied by a different type of fox than those you've encountered thus far. They snarl at you as you enter the room and speak in your language \"Human...here ? Tricksy little human.Your destiny ends here!\" and they prepare to attack you. You chuckle at their words and think to yourself that those are bold words for this not even being a boss level.";
        if (!isDungeon)
        {
            rewardExplain = "- Intact Nine Tail\n- <color=green>White Fox Pelt\n- Reincarnation Challenge Boss";
        }
        else
        {
            rewardExplain = "- Intact Nine Tail";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.IntactNineTail);
        main.Log("Gain <color=green>Intact Nine Tail");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.WhiteFoxPelt);
            main.Log("Gain <color=green>White Fox Pelt");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Montblango\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

        }


    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateSeven(ENEMY.MonsterTable.RareFoxes, new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossFoxes), new Vector3(0, 0));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
