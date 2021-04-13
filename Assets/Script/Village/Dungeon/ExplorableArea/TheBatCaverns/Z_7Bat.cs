using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7Bat : DUNGEON
{
    long target => !main.ZoneCtrl.isHidden ? main.S.metalSlimeNum2 : main.S.hidden_metalSlimeNum2;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batBreedingGrounds, "Breeding Grounds",44, 22, 0, true,"2-7");
        gameObject.AddComponent<M_clear>().awake(70);
        gameObject.AddComponent<M_clearNum>().awake(71, 100);
        gameObject.AddComponent<M_capture>().awake(72, ENEMY.EnemyKind.PurpleBat, 50);
        gameObject.AddComponent<M_other>().awake(73, () => MissionLocal.bat7(target), () => target >= 100);
        gameObject.AddComponent<M_time>().awake(74,35);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 35;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You thought your sense of astonishment was plenty numb by now, but you enter into a massive cave where the bats appear to have infested the most. Stalactites cover the ceiling, and stalagmites protrude from the ground, making movement through this place tricky. The bats have sensed your presence already and appear to have entered into a frenzy. You try to stay motivated to continue and the words \"Fear is the mind - killer\" spill from your lips. You stare ahead for a moment, trying to understand what you just said, and then you shrug it off, good enough.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Tooth * 5\n- <color=green>Ancient Coin</color>\n- <color=green>New Area</color>";
        }
        else
        {
            rewardExplain = "- Bat Tooth * 5";   
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatTooth,5);
        main.Log("Gain <color=green>Bat Tooth * 5");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 2, 200);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 2, 200);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 2, 200);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 2, 200);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 20), 2, 200);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 2, 200);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 2, 200);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 2, 200);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 2, 200);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 40), 2, 200);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -140), 2, 300);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -140), 2, 300);
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -140), 2, 300);
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -140), 2, 300);
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -140), 2, 300);
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareBats, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 320);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 360);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 360);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 360);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 360);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -160), 2, 360);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 360);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 360);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 360);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 360);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 10), 2, 360);
                    break;
                case 35:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 36:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 37:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 38:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 39:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 40:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 41:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 42:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 43:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                case 44:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareBats, new Vector3(0, 90), 2, 360);
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
