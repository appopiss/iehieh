using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS1, "Slime River", 29, 53, 0, true,"6-1");
        gameObject.AddComponent<M_clear>().awake(200);
        gameObject.AddComponent<M_hp>().awake(201, 0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(202);
        gameObject.AddComponent<M_noEQ>().awake(203);
        gameObject.AddComponent<M_material>().awake(204,ArtiCtrl.MaterialList.EnchantedCloth, 5000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 260;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Legends tell of an ancient country built around magic. Like all legends about ancient countries, thing did not end well. They royally angered some deity and the whole country was cursed. You recently got a tip of an area that strongly resembles places mentioned in the legends. Maybe you can confirm whether the legends are true or just the musing of some fool trying to impress a girl. When you finally arrive at the border of the area the tip told you about, you notice a sign that says \"BEWA\" and the rest of the sign is dissolved. There's a nearby river that you decide would be a good place to refill your water canteen, but as you get close the river comes alive and attacks you.";
        if (!isDungeon)
        {
            rewardExplain = "- Ooze Stained Cloth * 10\n- <color=green>Gooey Sludge * 20</color>";
        }
        else
        {
            rewardExplain = "- Ooze Stained Cloth * 10";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.OozeStainedCloth,10);
        main.Log("Gain <color=green>Ooze Stained Cloth * 10");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.GooeySludge,20);
            main.Log("Gain <color=green>Gooey Sludge * 20");
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
                    InstantiateHolLine(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 160), 3, 120);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 30), 6, 60);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 160), 3, 120);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 80), 4, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalMSlimes, new Vector3(0, 160), 3, 120);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }

    }
    int rand;
}
