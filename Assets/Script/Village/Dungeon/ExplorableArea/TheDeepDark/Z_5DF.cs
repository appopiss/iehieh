using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5DF : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_DF5, "Lightless Vastness", 64, 66, 0, true,"7-5");
        gameObject.AddComponent<M_clear>().awake(260);
        gameObject.AddComponent<M_spendTime>().awake(261, 10 * 60 * 60);
        gameObject.AddComponent<M_capture>().awake(262, ENEMY.EnemyKind.PurpleDevilFish, 2);
        gameObject.AddComponent<M_time>().awake(263, 35);
        gameObject.AddComponent<M_noDmg>().awake(264);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 950;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "At the center of the submerged city is massive hole that leads straight down. You're already pretty deep, and the light from above barely gives you much light to see as it is, but you decide to venture down into that hole as you see dozens upon dozens of Devil Fish pouring out of it. Did you by chance stumble upon the source of this infestation? There's nothing else that can be done about it, you must venture down into that darkness and rely on your other senses to navigate. Wait, you can't see anything, can't hear anything, can't smell anything... you may have to come up with new senses to survive this.";
        if (!isDungeon)
        {
            rewardExplain = "- Sharp Fin * 5\n- <color=green>Fish Teeth * 3</color>";
        }
        else
        {
            rewardExplain = "- Sharp Fin * 5";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SharpFin,5);
        main.Log("Gain <color=green>Sharp Fin * 5");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.FishTeeth,3);
            main.Log("Gain <color=green>Fish Teeth * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 110), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 105), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 1), 2, 80);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 1), 2, 80);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 1), 2, 80);
                    break;
                case 10:
                    InstantiateSeven(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -20));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40), 3, -40);
                    break;
                case 12:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 0), 3, -40);
                    break;
                case 14:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 3, -40);
                    break;
                case 16:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 60));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -10), 3, -40);
                    break;
                case 18:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 3, 40);
                    break;
                case 20:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60));
                    break;
                case 22:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -60));
                    break;
                case 24:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -60));
                    break;
                case 26:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -60));
                    break;
                case 28:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -60));
                    break;
                case 30:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140));
                    break;
                case 32:
                    InstantiateNine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -140));
                    break;
                case 34:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -140));
                    break;
                case 36:
                    InstantiateNine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -140));
                    break;
                case 38:
                    InstantiateNine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -140));
                    break;
                case 40:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 9, 40);
                    break;
                case 42:
                    Instantiate13(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    break;
                case 44:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    break;
                case 46:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    break;
                case 48:
                    Instantiate13(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 160), 9, 40);
                    break;
                case 50:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 320);
                    break;
                case 52:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, -150), 2, 320);
                    break;
                case 54:
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -150), 2, 320);
                    break;
                case 56:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -150), 2, 320);
                    break;
                case 58:
                    InstantiateSquare(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -150), 2, 320);
                    break;
                case 60:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 320);
                    break;
                case 62:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 320);
                    break;
                case 64:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonDevilFish, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonDevilFish, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.RareDevilFish, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 7);
                    if (rand == 1)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 0 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-120, 0 + 50));
                    }
                    else if (rand == 2)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 0 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -60 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -120 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(30, 90 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(30, -90 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(90, 30 + 50));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(90, -30 + 50));
                    }
                    else if (rand == 3)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                        }
                    }
                    else if (rand == 3)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, 100));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-120, 40));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-60, -20));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -80));
                    }
                    else if (rand == 4)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, 100));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(120, 40));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(60, -20));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, -80));
                    }
                    else if (rand == 5)
                    {
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(160, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(80, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(0, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-80, 160));
                        InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalDevilFish), new Vector3(-160, 160));
                    }
                    else if (rand == 6)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 160), 3, 120);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.NormalDevilFish, new Vector3(0, -80));
                    }
                    break;
            }
        }
    }
    int rand;

}
