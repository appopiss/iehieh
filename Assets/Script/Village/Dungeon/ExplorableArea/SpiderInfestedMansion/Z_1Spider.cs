using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1Spider : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_spider1, "Creepy Courtyard",24, 24, 0, true,"3-1");
        gameObject.AddComponent<M_clear>().awake(80);
        gameObject.AddComponent<M_hp>().awake(81,0.95f);
        gameObject.AddComponent<M_material>().awake(82, ArtiCtrl.MaterialList.SpiderSilk, 500);
        gameObject.AddComponent<M_gold>().awake(83, 300000);
        gameObject.AddComponent<M_time>().awake(84, 15);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 33;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "This peaceful looking wooded locale is a far stretch from the nightmarish places you've ventured up until now. Hard to believe that fairies exist, or that they would even be aggressive, but that is what the rumors say, if they are to be believed. Fauna such as deer, squirrels, and birds can be seen freely co-existing here, but you sense you are being watched very closely by something you cannot yet see. You're certain that with each step you take now that the only slight danger that you sense now will continue to increase. It reminds you of almost every relationship you've ever been in.";
        if (!isDungeon)
        {
            rewardExplain = "- Spider Blood\n- <color=green>Spider Silk</color>";
        }
        else
        {
            rewardExplain = "- Spider Blood";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.SpiderBlood);
        main.Log("Gain <color=green>Spider Blood");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.SpiderSilk);
            main.Log("Gain <color=green>Spider Silk");
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
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 4, 100);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 4, 100);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 4, 100);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 40), 4, 100);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 4, 100);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 2, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 5, 80);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSpider, new Vector3(0, -40), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 6, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 7, 50);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, 120), 8, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSpiders, new Vector3(0, -40), 6, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 20), 8, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(-120, 60));
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }


}
