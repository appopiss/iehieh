using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_capture : ACHIEVEMENT
{
    public long[] ClickNum;
    public double[] GoldNum;
    public int[] requiredCaptureNum = new int[] { 10, 50, 100, 250, 500, 1000 };
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(6, Type.Permanent);
        CliantName = "The overprotective Dad";//"Sick girl's father";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Capture 1";
        QuestNames[1] = "Capture 2";
        QuestNames[2] = "Capture 3";
        QuestNames[3] = "Capture 4";
        QuestNames[4] = "Capture 5";
        QuestNames[5] = "Capture 6";
        //Condition
        Condition[0] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[0];
        Condition[1] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[1];
        Condition[2] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[2];
        Condition[3] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[3];
        Condition[4] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[4];
        Condition[5] = () => main.S.totalEnemyCaptured >= requiredCaptureNum[5];
        rewardText[0] = "- " + tDigit(GoldNum[0]) + " Gold" + "\n - <sprite=0> 50";
        rewardText[1] = "- " + tDigit(GoldNum[1]) + " Gold" + "\n - <sprite=0> 50";
        rewardText[2] = "- " + tDigit(GoldNum[2]) + " Gold" + "\n - <sprite=0> 50";
        rewardText[3] = "- " + tDigit(GoldNum[3]) + " Gold" + "\n - <sprite=0> 50";
        CurrentProgress[0] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OilOfSlime] + " /  3";
        CurrentProgress[1] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.IntactBatHead] + " /  1";
        CurrentProgress[2] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.Herb] + " /  5";
        CurrentProgress[3] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] + " /  1";
        UnlockCondition[0] = "Take 3 Oil of Slime.";
        UnlockCondition[1] = "Take 1 Intact Bat Head.";
        UnlockCondition[2] = "Take 5 Harb.";
        UnlockCondition[3] = "Take 1 Rainbow Fish.";
        //Parmanentの処理を書くよ．
        P_questName = "No worries if you are prepared";
        P_condition = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] >= 5;
        P_currentProgress = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] + " / 5";
        P_unlockCondition = "Take 5 Rainbow Fish!";
        P_rewardText = "3000 Gold";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] -= 5;
            main.SR.gold += 3000;
        }
        else
        {
            switch (clearNum)
            {
                case 0:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OilOfSlime] -= 3;
                    break;
                case 1:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.IntactBatHead] -= 1;
                    break;
                case 2:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.Herb] -= 5;
                    break;
                case 3:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] -= 1;
                    break;
            }
            main.S.ECbyQuest += 10;
            main.SR.gold += GoldNum[clearNum];
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
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
