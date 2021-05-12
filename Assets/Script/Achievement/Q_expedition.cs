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
        discription[0] = "Defeat ";
        discription[1] = "Travel around the world. And get stronger.";
        discription[2] = "Travel around the world. And get stronger.";
        discription[3] = "Travel around the world. And get stronger.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Expedition Quest 1";
        QuestNames[1] = "Expedition Quest 2";
        QuestNames[2] = "Expedition Quest 3";
        QuestNames[3] = "Expedition Quest 4";
        rewardText[0] = "- HP + 10%" + LetterImage()+" 30";
        rewardText[1] = "- HP + 10%" + LetterImage() + " 50";
        rewardText[2] = "- HP + 10%" + LetterImage() + " 100";
        rewardText[3] = "- HP + 10%" + LetterImage() + " 500";
        //Condition
        Condition[0] = () => main.S.WalkDistance >= 100000;
        Condition[1] = () => main.S.WalkDistance >= 10000000;
        Condition[2] = () => main.S.WalkDistance >= 1000000000;
        Condition[3] = () => main.S.WalkDistance >= 100000000000;
        CurrentProgress[0] = () => "You've walked : " + tDigit(main.S.WalkDistance) +"  /  "+tDigit(100000);
        CurrentProgress[1] = () => "You've walked : " + tDigit(main.S.WalkDistance) + "  /  " + tDigit(10000000);
        CurrentProgress[2] = () => "You've walked : " + tDigit(main.S.WalkDistance) + "  /  " + tDigit(1000000000);
        CurrentProgress[3] = () => "You've walked : " + tDigit(main.S.WalkDistance) + "  /  " + tDigit(100000000000);
        UnlockCondition[0] = "Defeat 1000 Purple Slime";
        UnlockCondition[1] = "Defeat 1000 Purple Bat";
        UnlockCondition[2] = "Capture 1 Normal Spider";
        UnlockCondition[3] = "Capture 1 Normal Fairy";
        UnlockCondition[4] = "Capture 1 Normal Fairy";
        UnlockCondition[5] = "Capture 1 Normal Fairy";
        UnlockCondition[6] = "Capture 1 Normal Fairy";
        UnlockCondition[7] = "Capture 1 Normal Fairy";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        switch (clearNum)
        {
            case 0:
                GetEC(3);
                break;
            case 1:
                GetEC(5);
                break;
            case 2:
                GetEC(10);
                break;
            case 3:
                GetEC(50);
                break;
            case 4:
                break;
        }

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
                SEbonus = 3;
                break;
            case 2:
                SEbonus = 3 + 5;
                break;
            case 3:
                SEbonus = 3 + 10;
                break;
            case 4:
                SEbonus = 3 + 5 + 10 + 50;
                break;
        }
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
