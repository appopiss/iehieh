using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_errand : ACHIEVEMENT
{
    public long[] ClickNum;
    public override bool[] isSeen { get => main.S.isS_errand; set => main.S.isS_errand = value; }
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(4, Type.Limited);
        ClickNum = new long[] { 10, 30, 50, 100 };
        GoldCap = new long[] { 50, 100, 250, 500 };
        CliantName = "The overprotective Dad";//"Sick girl's father";
        discription[0] = "OMG my little girl is sick. I've heard slime oil is good for this sickness. Get me 3!";//"My daughter got sick. I heard that slime mucus is good for sickness. Can you pick me only 10?";
        discription[1] = "Oops! ! It was a complete lie that the slime mucus worked against the disease. " +
            "I asked a friend who knows about illness, and it seems that it would be good to eat the whole bat's head.";
        discription[2] = "What a hell! Rather, the disease has worsened! What should I do···";
        discription[3] = "Thank you! My daughter's condition has improved! But my daughter still doesn't wake up ... " +
            "But sometimes she says in her sleep. \"I want to eat rainbow - colored fish in a cave lake.\" . . What the hell is that?";
        P_discription = "Thanks to you, my daughter is fine! But I'm worried if my daughter gets sick again, " +
            "would you please bring more that fish as a spare?";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Strange Errand 1";
        QuestNames[1] = "Strange Errand 2";
        QuestNames[2] = "Strange Errand 3";
        QuestNames[3] = "Strange Errand 4";
        //Condition
        Condition[0] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OilOfSlime] >= 3;
        Condition[1] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.IntactBatHead] >= 1;
        Condition[2] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.Herb] >= 5;
        Condition[3] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] >= 1;
        rewardText[0] = "- Gold Cap + " + tDigit(GoldCap[0]) + LetterImage() + " 30";
        rewardText[1] = "- Gold Cap + " + tDigit(GoldCap[1]) + LetterImage() + " 50";
        rewardText[2] = "- Gold Cap + " + tDigit(GoldCap[2]) + LetterImage() + " 100";
        rewardText[3] = "- Gold Cap + " + tDigit(GoldCap[3]) + LetterImage() + " 150";
        CurrentProgress[0] = ()=> "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OilOfSlime] + " /  3";
        CurrentProgress[1] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.IntactBatHead] + " /  1";
        CurrentProgress[2] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.Herb] + " /  5";
        CurrentProgress[3] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] + " /  1";
        UnlockCondition[0] = "Find 3 Oil of Slime.";
        UnlockCondition[1] = "Find 1 Intact Bat Head.";
        UnlockCondition[2] = "Find 5 Herbs.";
        UnlockCondition[3] = "Find 1 Rainbow Fish.";
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
                    GetEC(3);
                    break;
                case 1:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.IntactBatHead] -= 1;
                    GetEC(5);
                    break;
                case 2:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.Herb] -= 5;
                    GetEC(10);
                    break;
                case 3:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] -= 1;
                    GetEC(15);  
                    break;
            }
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
                GoldCapBonus = GoldCap[0];
                SEbonus = 3;
                break;
            case 2:
                GoldCapBonus = GoldCap[1] + GoldCap[0];
                SEbonus = 3 + 5;
                break;
            case 3:
                GoldCapBonus = GoldCap[2] + GoldCap[1] + GoldCap[0];
                SEbonus = 3 + 5 + 10;
                break;
            case 4:
                GoldCapBonus = GoldCap[3] + GoldCap[2] + GoldCap[1] + GoldCap[0];
                SEbonus = 3 + 5 + 10 + 15;
                break;
        }
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
