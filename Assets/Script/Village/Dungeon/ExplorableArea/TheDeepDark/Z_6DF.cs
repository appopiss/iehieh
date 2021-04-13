using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_6DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF6, "Dark Trench", 69, 67, 0, true,"7-6");
        gameObject.AddComponent<M_clear>().awake(265);
        gameObject.AddComponent<M_noEQ>().awake(266);
        gameObject.AddComponent<M_noDmg>().awake(267);
        gameObject.AddComponent<M_material>().awake(268,ArtiCtrl.MaterialList.DevilFishCore,10);
        gameObject.AddComponent<M_onlyBase>().awake(269);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 1050;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You're swimming in the dark, fighting off fish that are trying to eat you. There's absolutely nothing to note here because you can't see anything. You just know that you're now underground, underwater, and you're swimming ever deeper. You are trying to recall at what point this ever sounded like a good idea.";
        if (!isDungeon)
        {
            rewardExplain = "- Sharp Fin * 10\n- <color=green>Monster Fluid * 4000</color>";
        }
        else
        {
            rewardExplain = "- Sharp Fin * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SharpFin,10);
        main.Log("Gain <color=green>Sharp Fin * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.GlowingSludge);
            main.Log("Gain <color=green>Monster Fluid * 4000");
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
                        InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140));
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -140));
                    }
                    else if (rand == 4)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 6, 60);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0));
                    }
                    else if (rand == 5)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -80));
                    }
                    else if (rand == 6)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 5, 80);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }
    int rand;

}
