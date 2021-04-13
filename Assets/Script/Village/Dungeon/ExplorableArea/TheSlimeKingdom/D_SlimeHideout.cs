using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_SlimeHideout : DUNGEON
{
    //public override int maxDungeonFloorNum
    //{
    //    get => main.SR.maxDungeonFloorNum[idDungeon];
    //    set => main.SR.maxDungeonFloorNum[idDungeon] = value;
    //}

    //public override DateTime dungeonPlayTime
    //{
    //    get { return DateTime.FromBinary(Convert.ToInt64(main.S.dungeonPlayTime[idDungeon])); }
    //    set { main.S.dungeonPlayTime[idDungeon] = value.ToBinary().ToString(); }
    //}

    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.slimeHideout,"The Slime Slums", 2,0,0,true,"1-1");
        gameObject.AddComponent<M_clear>().MissionId = 0;
        gameObject.AddComponent<M_onlyBase>().MissionId = 1;
        gameObject.AddComponent<M_time>().MissionId = 2;
        gameObject.GetComponent<M_time>().time = 3.0f;
        gameObject.AddComponent<M_other>().MissionId = 3;
        gameObject.GetComponent<M_other>().otherText
            = () => "- Defeat 1000 Big Slime without any skills equipped ( " + tDigit(Math.Min(main.S.bigSlimeNumByBase,1000)) + " / 1000 )";
        gameObject.GetComponent<M_other>().ClearCondition = () => main.S.bigSlimeNumByBase >= 1000;
        gameObject.AddComponent<M_clearNum>().MissionId = 4;
        gameObject.GetComponent<M_clearNum>().clearNum = 250;
    }

	// Use this for initialization
	void Start () {
        StartDungeon();
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();
        explain = "What appears to be an ancient city that has been eroded away by the acidic sludge of the slimes that spawn here. It smells a lot like brimstone and strong alcohol, but one should avoid drinking anything here.";
        if (!isDungeon)
        {
            rewardExplain = "- Monster Fluid\n- <color=green>Ooze Stained Cloth</color>\n- <color=green>New Content \"CRAFT\"</color>\n- <color=green>New Upgrades</color>\n- <color=green>500 Gold";
        }
        else
        {
            rewardExplain = "- Monster Fluid";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.MonsterFluid);
        main.Log("Gain <color=green>Monster Fluid");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.OozeStainedCloth);
            main.Log("Gain <color=green>Ooze Stained Cloth");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
 
        if (!main.TutorialController.isSlimeHideoutClear)
        {
            if (!main.TutorialController.isUpgrade)
            {
                main.buttons[0].gameObject.GetComponent<Transform>().SetParent(main.TutorialController.MenuCanvas);
                main.GameController.ActiveObject(main.GameController.HideIdleCanvas);
                main.GameController.DoRayCast();
                if (main.S.job == ALLY.Job.Warrior)
                {
                    main.TutorialController.Texts[0].gameObject.SetActive(true);
                    main.S.isUpgradeIcon1 = true;
                    main.TutorialController.ShowUpgradeIcon();
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    main.TutorialController.Texts[1].gameObject.SetActive(true);
                    main.S.isUpgradeIcon2 = true;
                    main.TutorialController.ShowUpgradeIcon();
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    main.TutorialController.Texts[2].gameObject.SetActive(true);
                    main.S.isUpgradeIcon3 = true;
                    main.TutorialController.ShowUpgradeIcon();
                }
                main.TutorialController.isUpgrade = true;
            }
            main.TutorialController.TutorialCanvasAry[5].GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            main.TutorialController.TutorialCanvasAry[6].GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);

            main.SR.gold += 500;
            main.Log("Gain <yellow> 500 Gold !");
            main.TutorialController.isSlimeHideoutClear = true;
            main.TutorialController.isUpgradeIcon1 = true;
            main.TutorialController.isUpgradeIcon2 = true;
            main.TutorialController.isUpgradeIcon3 = true;
            main.TutorialController.ResetUpgradeIcon();
            main.TutorialController.ShowUpgradeIcon();
            StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!",main.UpStoneSpriteAry[3]));
            main.TutorialController.ResetMenu();
            main.TutorialController.ShowMenu();
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"CRAFT\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));

            //main.TutorialController.ResetChallenge();
            //main.TutorialController.ShowChallenge();
            //StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"CHALLENGE\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[1]));

            //main.TutorialController.ResetDungeon();
            //main.TutorialController.ShowDungeon();
            //StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Bat Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
        }
        main.TutorialController.isUpgradeIcon1 = true;
        main.TutorialController.isUpgradeIcon2 = true;
        main.TutorialController.isUpgradeIcon3 = true;
    }

    public double[] NormalSlime = new double[] { 10, 3, 0, 0, 0, 2, 3 };
    public double[] BigSlime = new double[] { 100, 10, 0, 0, 0, 5, 10 };

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.NormalSlimes), new Vector3(0, 120), NormalSlime);
                    break;
                case 1:
                    InstantiateFiveDia(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 0), NormalSlime);
                    break;
                case 2:
                    InstantiateFiveUnder(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, -40), NormalSlime);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BigSlime), new Vector3(0, 120), BigSlime);
                    break;

                //case 0:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                //    break;
                //case 1:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 100), 3, 120);
                //    break;
                //case 2:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 40), 3, 80);
                //    break;
                //case 3:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 5, 60);
                //    break;
                //case 4:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 5, 60);
                //    break;
                //case 5:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 5, 60);
                //    break;
                //case 6:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 100), 4, 100);
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 20), 3, 100);
                //    break;
                //case 7:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 100), 4, 100);
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 20), 3, 100);
                //    break;
                //case 8:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 100), 4, 100);
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 20), 3, 100);
                //    break;
                //case 9:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 100), 4, 100);
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 20), 3, 100);
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, -60), 2, 100);
                //    break;
                //default:
                //    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                //    break;
            }
        }
    }


}
