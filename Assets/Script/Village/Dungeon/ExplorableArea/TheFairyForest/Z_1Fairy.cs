using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1Fairy : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fairy1, "Light Woods",24, 35, 0, true,"4-1");
        gameObject.AddComponent<M_clear>().awake(120);
        gameObject.AddComponent<M_hp>().awake(121, 0.95f);
        gameObject.AddComponent<M_material>().awake(122, ArtiCtrl.MaterialList.FairyDust, 2000);
        gameObject.AddComponent<M_noEQ>().awake(123);
        gameObject.AddComponent<M_onlyBase>().awake(124);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 70;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "An ancient, decaying mansion lies before you. It may have once been a beautiful sight, with fountains and gardens decorating its grounds, but now it is a decrepit, rotting stain on the landscape. What could have caused this place to fall into such a devastated state, you wonder to yourself. However, the lock on the gate is still intact, though it is entirely rusted. Breaking the padlock was easy, and now you are free to explore the grounds and see what treasures may have been left behind by the former residents here. A strange chattering sound begins as the gates swing open. Nothing can stand between you and possible treasure, though. Not after your ex got everything in the divorce!";
        if (!isDungeon)
        {
            rewardExplain = "- Fairy Dust\n- <color=green>Enchanted Cloth</color>";
        }
        else
        {
            rewardExplain = "- Fairy Dust";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FairyDust);
        main.Log("Gain <color=green>Fairy Dust");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.EnchantedCloth);
            main.Log("Gain <color=green>Enchanted Cloth");
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
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 4, 100);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 4, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 4, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 40), 4, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFairy, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonFairy, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.CommonFairy), new Vector3(-120, 60));
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }

    }

}
