using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4Bat : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batTempleAntechamber, "Temple Antechamber",0, 19, 900, true,"2-4");
        gameObject.AddComponent<M_clear>().awake(55);
        gameObject.AddComponent<M_hp>().awake(56,0.8f);
        gameObject.AddComponent<M_capture>().awake(57, ENEMY.EnemyKind.BlackBat, 25);
        gameObject.AddComponent<M_material>().awake(58, ArtiCtrl.MaterialList.BatFeet, 100);
        gameObject.AddComponent<M_timeOver>().awake(59, 180);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 5;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You enter a small room that appears to lead into the main sanctuary of the temple. The room is fairly unremarkable, though it could have been much fancier long ago when this place wasn't a ruined mess. Looking up you can see that the ceiling stretches off into the darkness, but you can catch tiny reflections of light peering down at you. You notice with each step into this room that the door on the opposite side of the room seems to stay just as far away as it did before. This place is definitely cursed and the bats here have noticed you now. You're going to have to run toward the door, no matter how far it moves away, you've just got to move faster. If you ever find the skull of the idiot who created the spell on this room, you're going to smash it, put it back together, and then smash it again.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Feet\n- <color=green>Intact Bat Head</color>\n- <color=green>New Content \"Slime Bank\"";
        }
        else
        {
            rewardExplain = "- Bat Feet";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatFeet);
        main.Log("Gain <color=green>Bat Feet");
        if (!isDungeon)
        {
            isDungeon = true;
            main.S.unleashBank = true;
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"Slime Bank\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[5]));
            getMaterial(ArtiCtrl.MaterialList.IntactBatHead);
            main.Log("Gain <color=green>Intact Bat Head");
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
        main.S.unleashBank = true;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossBats), new Vector3(0, 80));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
