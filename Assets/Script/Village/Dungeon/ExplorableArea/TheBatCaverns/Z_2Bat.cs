using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_2Bat : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_batCaveInTheWoods, "Cave in the Woods",19, 17, 0, true,"2-2");
        gameObject.AddComponent<M_clear>().awake(45);
        gameObject.AddComponent<M_clearNum>().awake(46,50);
        gameObject.AddComponent<M_onlyPhy>().awake(47);
        gameObject.AddComponent<M_material>().awake(48,ArtiCtrl.MaterialList.BatPelt,1500);
        gameObject.AddComponent<M_capture>().awake(49,ENEMY.EnemyKind.NormalBat,100);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 0;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Deep within the forest you come across a large cave opening. It's strange, and you can't discern whether it's just the way the shadows are striking the rocks, but it almost seems like this protruding rock formation has the shape of a bat's head. You can tell the cave hasn't always been here by the way that it has uprooted trees and shredded the nearby flora. Bones litter the ground near the cave's entrance. You hope it wasn't anyone you knew... yeah, probably not.";
        if (!isDungeon)
        {
            rewardExplain = "- Bat Wing\n- <color=green>Bat Pelt</color>\n- <color=green>Queue of Upgrade";
        }
        else
        {
            rewardExplain = "- Bat Wing";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.BatWing);
        main.Log("Gain <color=green>Bat Wing");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.BatPelt);
            main.Log("Gain <color=green>Bat Pelt");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();

            if(main.S.Queue_unleashed != 5)
            {
                main.S.Queue_unleashed = 5;
                main.queueController.queue += 5;
            }
            StartCoroutine(main.InstantiateLogText("<size=12>\"Queue of Upgrade\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[12]));
        }
        main.S.Queue_unleashed = 5;
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 3, 80);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 3, 80);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 3, 80);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 3, 80);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 120), 3, 100);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 1), 3, 80);
                    break;
                case 5:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 3, 100);
                    break;
                case 6:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 3, 100);
                    break;
                case 7:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 3, 100);
                    break;
                case 8:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 4, 80);
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 4, 80);
                    break;
                case 10:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60), 4, 80);
                    break;
                case 11:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -120));
                    break;
                case 12:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -120));
                    break;
                case 13:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -120));
                    break;
                case 14:
                    InstantiateNine(ENEMY.MonsterTable.CommonBats, new Vector3(0, 60));
                    InstantiateSevenUnder(ENEMY.MonsterTable.CommonBats, new Vector3(0, -120));
                    break;
                case 19:
                    Instantiate13(ENEMY.MonsterTable.CommonBats, new Vector3(0, 0));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonBats), new Vector3(0, 200));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
