using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_8MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS8, "Slime Tower's Crown", 59, 60, 1800, true,"6-8");
        gameObject.AddComponent<M_clear>().awake(235);
        gameObject.AddComponent<M_hp>().awake(236, 0.95f);
        gameObject.AddComponent<M_onlyPhy>().awake(237);
        gameObject.AddComponent<M_onlyBase>().awake(238);
        gameObject.AddComponent<M_noDmg>().awake(239);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 700;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Entering the tower, everything seems incredibly well preserved. Nothing has been dissolved by acid, but there are still skeletons strewn across the room. You see one clutching a quill near a table where whoever this was attempted to write something before they died. The paper reads \"Our hubris has wrought disaster.We defied the gods and they have cursed our entire nation!The tower's shields won't hold out much longer, but to anyone who finds this, know that we did this to ourselves. We thought we could capture the essence of gods and use it to become gods ourselves... I have no one left.everyone has melte...\" and that's where the writing ends. Suddenly, you hear loud crackling sounds coming from the top of the tower. Whatever is up there is likely boss material. Hopefully you'll keep your flesh attached to your bones as you have grown quite accustomed to it being this way.";
        if (!isDungeon)
        {
            rewardExplain = "- Odd Magical Hat\n- <color=green>Magic Slime Core</color>\n- <color=green>New Challenge\n- New Dungeon";
        }
        else
        {
            rewardExplain = "- Odd Magical Hat";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.OddMagicalHat);
        main.Log("Gain <color=green>Odd Magical Hat");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MagicSlimeCore);
            main.Log("Gain <color=green>Magic Slime Core");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            main.S.unleashDungeon4 = true;
            main.TutorialController.ResetDungeon();
            main.TutorialController.ShowDungeon();
            StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"The Persistent Tower of Slime\" <size=10> is Unleashed!", main.ChallengeSpriteAry[1]));

            main.TutorialController.ResetChallenge();
            main.TutorialController.ShowChallenge();
            StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Octobaddie\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

        }
        main.S.unleashDungeon4 = true;

    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    areaDifficultyFactor = 700;
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 2, 100);
                    break;
                case 3:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0));
                    break;
                case 4:
                    InstantiateFiveDia(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 0));
                    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 3, 100);
                //    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateFiveDia(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 0));
                    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonMSlimes), new Vector3(-120, 60));
                //    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 20), 3, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;

                //case 14:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 2, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 100);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                //    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
                //case 19:
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, 120), 6, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 4, 60);
                //    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 5, 80);
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                //    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                //    break;
                case 24:
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 29:
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 34:
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 39:
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 41:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 43:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 45:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 47:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 49:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 51:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 53:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 55:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 57:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;
                case 59:
                    areaDifficultyFactor += 2;
                    InstantiateSeven(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 60));
                    break;

                default:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonMSlimes, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonMSlimes, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.RareMSlimes, new Vector3(0, 20), 6, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.RareMSlimes), new Vector3(-120, 60));
                    break;
            }
        }
    }


}
