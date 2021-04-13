using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_7MS : DUNGEON
{
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS7, "Slime Mage Tower", 54, 59, 0, true,"6-7");
        gameObject.AddComponent<M_clear>().awake(230);
        gameObject.AddComponent<M_hp>().awake(231,0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(232);
        gameObject.AddComponent<M_gold>().awake(233,3000000);
        gameObject.AddComponent<M_time>().awake(234, 25);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 600;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "The most prominent structure in the city. The stone of the Tower seems oddly well preserved, but it has an unnatural black color to the stone, like it was charred by something. Perhaps the curse was the result of something that happened in this tower. Slime begins seeping out from the stone of the Tower as the slimes seem intent on keeping you from entering. That just makes you want to go in even more!";
        if (!isDungeon)
        {
            rewardExplain = "- Slime Eye Ball * 2\n- <color=green>Ruined Spellbook * 3</color>\n- <color=green>New Area</color>";
        }
        else
        {
            rewardExplain = "- Slime Eye Ball * 2";   
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SlimeEyeBall,2);
        main.Log("Gain <color=green>Slime Eye Ball * 2");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.RuinedSpellBook,3);
            main.Log("Gain <color=green>Ruined Spellbook * 3");
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
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 2, 200);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 2, 200);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 2, 200);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 2, 200);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 2, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 20), 2, 200);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 40), 2, 200);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 40), 2, 200);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 40), 2, 200);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 40), 2, 200);
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 100), 5, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -20), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 40), 2, 200);
                    break;
                case 10:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140), 2, 300);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140), 2, 300);
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140), 2, 300);
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140), 2, 300);
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20));
                    InstantiateFiveUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140), 2, 300);
                    break;
                case 15:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 16:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 17:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 18:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 19:
                    InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60), 5, 80);
                    InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 20:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 21:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 22:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 23:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 24:
                    Instantiate13(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -60));
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 320);
                    break;
                case 25:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 360);
                    break;
                case 26:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 360);
                    break;
                case 27:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 360);
                    break;
                case 28:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 360);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -120), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -160), 2, 360);
                    break;
                case 30:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 360);
                    break;
                case 31:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 360);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 360);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 360);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 5, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 10), 2, 360);
                    break;
                case 45:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 46:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 47:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 48:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 49:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 6, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 50:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 51:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 52:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 53:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                case 54:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 7, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -150), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -70), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 10), 2, 360);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 90), 2, 360);
                    break;
                default:
                    int rand = UnityEngine.Random.Range(0, 4);
                    if (rand == 1)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -70), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 10), 2, 320);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 90), 2, 320);
                    }
                    else if (rand == 2)
                    {
                        InstantiateSquare(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0), 4, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 160), 9, 40);
                        InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -150), 2, 320);
                    }
                    else if (rand == 3)
                    {
                        InstantiateNine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, -140));
                    }
                    else
                    {
                        InstantiateNine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 80));
                        InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -60), 2, 80);
                        InstantiateSevenUnder(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -140));
                    }
                    break;
            }
        }
    }


}
