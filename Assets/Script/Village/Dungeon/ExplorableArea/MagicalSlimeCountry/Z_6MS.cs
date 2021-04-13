using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS6, "Slime University", 49, 58, 0, true,"6-6");
        gameObject.AddComponent<M_clear>().awake(225);
        gameObject.AddComponent<M_noEQ>().awake(226);
        gameObject.AddComponent<M_onlyBase>().awake(227);
        gameObject.AddComponent<M_noDmg>().awake(228);
        gameObject.AddComponent<M_time>().awake(229, 30);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 550;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Further down the acid eroded street you see what appears to have one been a prestigious facility. Enough of the signs on the building remain intact for you to discern this was a University. These are the kinds of places that draw people from all over the world to study. The inside of the building drips with ooze and there's absolutely nothing valuable left. Anything that may have been valuable or useful in any way has been dissolved or wrecked by the acidic sludge of the slimes. Unless you consider bone bits valuable, then there are tons of those. More slimes are upon you before you realize it. You’ll have to end your brief term at University to kill these slimes. You didn't even get to drink a beer while you were here.";
        if (!isDungeon)
        {
            rewardExplain = "- Oil of Slime * 5\n- <color=green>Glowing Sludge</color>";
        }
        else
        {
            rewardExplain = "- Oil of Slime * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.OilOfSlime,5);
        main.Log("Gain <color=green>Oil of Slime * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.GlowingSludge);
            main.Log("Gain <color=green>Glowing Sludge");
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
                default:
                    rand = UnityEngine.Random.Range(0, 7);
                    if (rand == 0)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -140));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonFairy, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareSpiders, new Vector3(0, -140));
                    }
                    else if (rand == 4)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 5)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 6)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSpiders, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }
    int rand;

}
