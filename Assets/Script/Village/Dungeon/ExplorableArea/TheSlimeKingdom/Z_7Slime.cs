using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7Slime : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.purpleSlimeNum : main.S.hidden_purpleSlimeNum;
    long target2 => !main.ZoneCtrl.isHidden ? main.S.metalSlimeNum : main.S.hidden_metalSlimeNum;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimeCastle, "Slime Castle", 39, 14, 0, true,"1-7");
        gameObject.AddComponent<M_clear>().awake(30);
        gameObject.AddComponent<M_other>().MissionId = 31;
        gameObject.GetComponent<M_other>().otherText
            = () => MissionLocal.slime7(target,500);
        gameObject.GetComponent<M_other>().ClearCondition = () => target >= 500;
        gameObject.AddComponent<M_other>().awake(32, () => MissionLocal.slime72(target2,50), () => target2 >= 50);
        gameObject.AddComponent<M_noEQ>().awake(33);
        gameObject.AddComponent<M_material>().awake(34, ArtiCtrl.MaterialList.AcidicGoop, 150);

    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 22;
    }

    void Update()
    {
        UpdateDungeon();

        explain = "Scraping slime off your clothes that dripped on you in the Slime Forest, you emerge to discover a massive structure that has been overrun with slimes. It appears like it was an old castle, but you can barely even see the stone, as large pulsating globs drip from it's walls. You are certain that the worst of the slimes will soon be upon you, attempting to dissolve you and absorb the resulting nutrients from your flesh. At this point, though, that thought doesn't even frighten you as much as how you will get the stains of dead slime out of your clothes.";
        if (!isDungeon)
        {
            rewardExplain = "- Relic Stone * 2\n- Carved Idol * 2\n- <color=green>Slime Eye Ball</color>";
        }
        else
        {
            rewardExplain = "- Relic Stone * 2\n- Carved Idol * 2";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RelicStone, 2);
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol, 2);
        main.Log("Gain <color=green>RelicStone * 2");
        main.Log("Gain <color=green>Carved Idol * 2");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SlimeEyeBall);
            main.Log("Gain <color=green>Slime Eye Ball");
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
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 2, 200);
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 2, 200);
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 2, 200);
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 2, 200);
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 100);
                    InstantiateSeven(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateNine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateNine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateNine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateNine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
                case 12:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150));
                    break;
                case 13:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150));
                    break;
                case 14:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150));
                    break;
                case 15:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 0));
                    InstantiateFiveUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -150));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 160);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 160);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 160);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 160);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 3, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 160);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 25:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 3, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 26:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 3, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 27:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 3, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 28:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 3, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 29:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 4, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 30:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 4, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 31:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 4, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 32:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 60), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 4, 60);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 33:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 5, 40);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 34:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 5, 40);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 35:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 5, 40);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 36:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 5, 40);
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -70));
                    InstantiateSevenUnder(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -120));
                    break;
                case 37:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80), 7, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -130), 7, 40);
                    break;
                case 38:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -30), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80), 7, 50);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -130), 7, 40);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 20),4,80);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.RareSlimes, new Vector3(0, 120), 2, 200);
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60));
                    break;
            }
        }
    }



}
