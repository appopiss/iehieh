using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_5Bat : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.yellowBatNum : main.S.hidden_yellowBatNum;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batCollapsedSanctuary, "Collapsed Sanctuary",34, 20, 0, true,"2-5");
        gameObject.AddComponent<M_clear>().awake(60);
        gameObject.AddComponent<M_other>().MissionId = 61;
        gameObject.GetComponent<M_other>().otherText
            = () => MissionLocal.bat5(target);
        gameObject.GetComponent<M_other>().ClearCondition = () => target >= 2000;
        gameObject.AddComponent<M_noEQ>().awake(62);
        gameObject.AddComponent<M_time>().awake(63,60);
        gameObject.AddComponent<M_gold>().awake(64,70000);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 14;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Emerging into the sanctuary, you find what used to be a large, circular auditorium with an altar in the center of the room. The altar itself is cracked in half and covered in a charred, black substance. You wonder if some sort of dark ritual was performed here, and if that is also responsible for the eternal night plaguing the forest outside. Near the altar there appears to be some sort of passage, but you'll have to fight your way through more hungry bats to see where it leads. An old-fashioned, boring fetch quest sounds so much better than this right now.";
        if (!isDungeon)
        {
            rewardExplain = "- Carved Idol\n- <color=green>Ancient Coin</color>";
        }
        else
        {
            rewardExplain = "- Carved Idol";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol);
        main.Log("Gain <color=green>Carved Idol");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.AncientCoin);
            main.Log("Gain <color=green>Ancient Coin");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 2, 80);
                    break;
                case 5:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 3, -40);
                    break;
                case 6:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 3, -40);
                    break;
                case 7:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 3, -40);
                    break;
                case 8:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 3, -40);
                    break;
                case 9:
                    InstantiateSeven(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0), 3, -40);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60),2,80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 2, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -140));
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -40));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 4, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -150), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, -70), 2, 320);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 320);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
