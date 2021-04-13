using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class Z_6Slime : DUNGEON
{
    public Button sandwichButton;
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_slimeForest, "The Slime Forest", 34, 13, 0, true,"1-6");
        gameObject.AddComponent<M_clear>().awake(25);
        gameObject.AddComponent<M_other>().awake(26,
            () => MissionLocal.slime6(),
            () => main.S.eatSandwich==true
            );
        gameObject.AddComponent<M_spendTime>().awake(27, 12 * 3600);
        gameObject.AddComponent<M_material>().awake(28, ArtiCtrl.MaterialList.GooeySludge, 200);
        gameObject.AddComponent<M_noDmg>().awake(29);
    }

    // Use this for initialization
    void Start()
    {
        StartDungeon();
        areaDifficultyFactor = 16;
        sandwichButton.onClick.AddListener(confirmSandwich);
    }
    GameObject confirmWindow;
    void confirmSandwich()
    {
        confirmWindow = Instantiate(main.P_texts[28], main.DeathShowCanvas);
        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Did you eat sandwich while playing IEH?";
        confirmWindow.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = "I did eat!";
        confirmWindow.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => Destroy(confirmWindow));
        confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
        {
            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Okay, we are trusting you.\nHope it tasted better than a slimewich!";
            confirmWindow.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = "Delicious!";
            main.S.eatSandwich = true;
            confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>Destroy(confirmWindow));
        });
    }


    void Update()
    {
        UpdateDungeon();
        if (main.GameController.currentDungeon == Main.Dungeon.Z_slimeForest && !main.S.eatSandwich)
            setActive(sandwichButton.gameObject);
        else
            setFalse(sandwichButton.gameObject);

        explain = "You are now witnessing one of most bizarre and twisted things you've ever seen, and you just left the Slime Pools, so you've probably seen enough for one lifetime. As you gaze upon this old forest, the trees have adapted to the acidic nature of the slimes inhabiting it, or they have become infested with something that keeps them from dissolving. The result is one of the most hideous looking plants you've ever seen. Globs grow on the branches of the trees, plopping to the ground and slithering away. It's one nightmare after the next.";
        if (!isDungeon)
        {
            rewardExplain = "- Relic Stone\n- <color=green>Acidic Goop</color>";
        }
        else
        {
            rewardExplain = "- Relic Stone";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RelicStone);
        getMaterial(ArtiCtrl.MaterialList.CarvedIdol);
        main.Log("Gain <color=green>RelicStone");
        main.Log("Gain <color=green>Carved Idol");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.AcidicGoop);
            main.Log("Gain <color=green>Acidic Goop");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
        //StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Bat Cave\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
    }

    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 1:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 2:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 3:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 4, 80);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 3, 100);
                    break;
                case 4:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 5:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 6:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 7:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 5, 80);
                    break;
                case 8:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 9:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 10:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 11:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 40), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 12:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 13:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 14:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 15:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    break;
                case 16:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    break;
                case 17:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    break;
                case 18:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    break;
                case 19:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 7, 60);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    break;
                case 20:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(40, -100));
                    break;
                case 21:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(40, -100));
                    break;
                case 22:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(40, -100));
                    break;
                case 23:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 120), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -40), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.CommonSlimes, new Vector3(0, 20), 9, 40);
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 160));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, 80));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(0, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-120, 60));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(80, -10));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(-40, -100));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.UncommonSlimes), new Vector3(40, -100));
                    break;
                case 24:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 5, 80);
                    break;
                case 25:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 5, 80);
                    break;
                case 26:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 5, 80);
                    break;
                case 27:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 4, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 5, 80);
                    break;
                case 28:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 7, 40);
                    break;
                case 29:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 7, 40);
                    break;
                case 30:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 7, 40);
                    break;
                case 31:
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 100), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -20), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 60), 9, 40);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -100), 7, 60);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 6, 70);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -60), 7, 40);
                    break;
                case 32:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(-100, 100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(100, 100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(-100, -100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(100, -100), 3,50);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 7, 50);
                    break;
                case 33:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(-100, 100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(100, 100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(-100, -100), 3,50);
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(100, -100), 3,50);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 7, 50);
                    InstantiateVerLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0), 7, 50);
                    break;
                case 34:
                    InstantiateSquare(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 20), 8,50);
                    break;
                default:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalSlimes, new Vector3(0, 120), 3, 100);
                    break;
            }
        }
    }




}
