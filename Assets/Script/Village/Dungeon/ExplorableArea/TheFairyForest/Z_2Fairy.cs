using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Fairy : DUNGEON
{
    // Use this for initialization
    void Awake() {
        AwakeDungeon(Main.Dungeon.Z_fairy2, "Abandoned Shack", 29, 36, 0, true, "4-2");
        gameObject.AddComponent<M_clear>().awake(125);
        gameObject.AddComponent<M_clearNum>().awake(126, 100);
        gameObject.AddComponent<M_spendTime>().awake(127, 6*60*60);
        gameObject.AddComponent<M_material>().awake(128, ArtiCtrl.MaterialList.EnchantedCloth, 500);
        gameObject.AddComponent<M_capture>().awake(129, ENEMY.EnemyKind.NormalFairy, 100);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 75;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You come across an old, abandoned shack in the woods. It doesn't appear to have been abandoned for too long, as everything appears to still be in good condition. An axe stuck in a tree trunk, clearly used to make firewood, shows no signs of rusting. Peering in the windows you immediately want to gag. Whoever lived here has been painted across the entire interior of the shack. Clearly these fairies are more sadistic and twisted than you originally thought. The hair raises a little on your neck, prompting you to turn and survey your surroundings again. You can see that more fairies have already begun moving in to purge you from their wood. This must be why the original fairy tales are always so grim.";
        if (!isDungeon)
        {
            rewardExplain = "- Monster Fluid * 30\n- <color=green>Enchanted Cloth * 3</color>";
        }
        else
        {
            rewardExplain = "- Monster Fluid * 30";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MonsterFluid,30);
        main.Log("Gain <color=green>Monster Fluid * 30");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.EnchantedCloth,3);
            main.Log("Gain <color=green>Enchanted Cloth * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 3, -40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -150), 2, 320);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
