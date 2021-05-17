using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;

public class Q_expedition : ACHIEVEMENT
{
    public float[] time;
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(8, Type.Limited);
        CliantName = "Tamer";
        discription[0] = "Defeat 1000 Purple Slimes then you can access Expedition.";
        discription[1] = "Defeat 1000 Purple Bat.";
        discription[2] = "Capture 1 Normal Spider.";
        discription[3] = "Capture 1 Normal Fairy.";
        discription[4] = "Capture 1 Orange Fox.";
        discription[5] = "Capture 1 Normal Magic Slime.";
        discription[6] = "Capture 1 Blue Devil Fish.";
        discription[7] = "Capture 1 Blue Blob.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Expedition Quest 1";
        QuestNames[1] = "Expedition Quest 2";
        QuestNames[2] = "Expedition Quest 3";
        QuestNames[3] = "Expedition Quest 4";
        QuestNames[3] = "Expedition Quest 5";
        QuestNames[3] = "Expedition Quest 6";
        QuestNames[3] = "Expedition Quest 7";
        QuestNames[3] = "Expedition Quest 8";
        rewardText[0] = "- Unleash a new content \"Expedition\"";
        rewardText[1] = "- Unleash another slot of Expedition.";
        rewardText[2] = "- Unleash another slot of Expedition.";
        rewardText[3] = "- Unleash another slot of Expedition.";
        rewardText[4] = "- Unleash another slot of Expedition.";
        rewardText[5] = "- Unleash another slot of Expedition.";
        rewardText[6] = "- Unleash another slot of Expedition.";
        rewardText[7] = "- Unleash another slot of Expedition.";
        //Condition
        Condition[0] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.PurpleSlime] >= 1000;
        Condition[1] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.PurpleBat] >= 1000;
        Condition[2] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.NormalSpider] >= 1;
        Condition[3] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.NormalFairy] >= 1;
        Condition[4] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.OrangeFox] >= 1;
        Condition[5] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.MNormalslime] >= 1;
        Condition[6] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.BlueDevilFish] >= 1;
        Condition[7] = () => main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.BlueBlob] >= 1;

        CurrentProgress[0] = () => "You've killed : " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.PurpleSlime]) +"  /  "+tDigit(1000);
        CurrentProgress[1] = () => "You've killed : " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.PurpleBat]) + "  /  " + tDigit(1000);
        CurrentProgress[2] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.NormalSpider]) + "  /  " + tDigit(1);
        CurrentProgress[3] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.NormalFairy]) + "  /  " + tDigit(1);
        CurrentProgress[4] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.OrangeFox]) + "  /  " + tDigit(1);
        CurrentProgress[5] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.MNormalslime]) + "  /  " + tDigit(1);
        CurrentProgress[6] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.BlueDevilFish]) + "  /  " + tDigit(1);
        CurrentProgress[7] = () => "You've captured : " + tDigit(main.S.totalEnemiesCaptured[(int)ENEMY.EnemyKind.BlueBlob]) + "  /  " + tDigit(1);

        UnlockCondition[0] = "Defeat 1000 Purple Slime";
        UnlockCondition[1] = "Defeat 1000 Purple Bat";
        UnlockCondition[2] = "Capture 1 Normal Spider";
        UnlockCondition[3] = "Capture 1 Normal Fairy";
        UnlockCondition[4] = "Capture 1 Orange Fox";
        UnlockCondition[5] = "Capture 1 Normal Magic Slime";
        UnlockCondition[6] = "Capture 1 Blue Devil Fish";
        UnlockCondition[7] = "Capture 1 Blue Blob";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        main.expeditionCtrl.UnleashButtons();
    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        switch (clearNum)
        {
            case 1:
                main.expeditionCtrl.unleashedNumFromQuest = 1;
                break;
            case 2:
                main.expeditionCtrl.unleashedNumFromQuest = 2;
                break;
            case 3:
                main.expeditionCtrl.unleashedNumFromQuest = 3;
                break;
            case 4:
                main.expeditionCtrl.unleashedNumFromQuest = 4;
                break;
            case 5:
                main.expeditionCtrl.unleashedNumFromQuest = 5;
                break;
            case 6:
                main.expeditionCtrl.unleashedNumFromQuest = 6;
                break;
            case 7:
                main.expeditionCtrl.unleashedNumFromQuest = 7;
                break;
            case 8:
                main.expeditionCtrl.unleashedNumFromQuest = 8;
                break;

        }
        UpdateQuest();
    }
}
