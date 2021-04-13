using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS2, "Slime Grotto", 34, 54, 0, true,"6-2");
        gameObject.AddComponent<M_clear>().awake(205);
        gameObject.AddComponent<M_hp>().awake(206,0.95f);
        gameObject.AddComponent<M_spendTime>().awake(207, 12 * 60 * 60);
        gameObject.AddComponent<M_capture>().awake(208, ENEMY.EnemyKind.MYelllowSlime,100);
        gameObject.AddComponent<M_noDmg>().awake(209);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 300;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "So that river was actually a river of magical slime. That was irritating and wildly unexpected. After you beat the river into submission, you followed it to discover a grotto. City walls can be seen in the distance, but suddenly more slimes have emerged from the Grotto toward you, slinging all manner of magic in your direction. How in the world did slimes gain this kind of power?! Maybe this could be related to the curse that supposedly affected this place. You can't stop to think about it now, as you are focused more on dodging spells and slime attacks. Strangely, you feel thirstier now that you know you cannot fill your canteen here.";
        if (!isDungeon)
        {
            rewardExplain = "- Gooey Sludge * 3\n- <color=green>Enchanted Cloth * 5</color>";
        }
        else
        {
            rewardExplain = "- Gooey Sludge * 3";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.GooeySludge,3);
        main.Log("Gain <color=green>Gooey Sludge * 3");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.EnchantedCloth,5);
            main.Log("Gain <color=green>Enchanted Cloth * 5");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
    }
    int rand;
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 6, 60);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 30), 7, 55);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 4, 100);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 5, 80);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 80), 4, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }


}
