using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_explore : ACHIEVEMENT
{
    public long[] num;
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(8, Type.Limited);
        //num = new long[] { 10, 30, 50, 100 };
        CliantName = "Brave Explorer";
        discription[0] = "";
        discription[1] = "";
        discription[2] = "";
        discription[3] = "";
        discription[4] = "";
        discription[5] = "";
        discription[6] = "";
        discription[7] = "";
        //discription[0] = "Hey Hero! For no specific reason, I'd like to ask you to kill 300 slimes. Well, I don't know why I'm asking you to do so...";
        //discription[1] = "Thank you for killing them! Oh I've just heard the voice of heaven. Then I have to ask you to bring 5 Monster Fluid right now.";
        //discription[2] = "Hmm... yeah, I'm thinking why I am here. Maybe... perhaps..., this is so-called tutorial? Oh... I've just noticed that my left hand hold a guidelines of this game. Let me see... Alright, then I have to ask you to clear Area 1-3!";
        //discription[3] = "Great job! Well, I was reading the guidlines while you explore the areas. Did you notice the Area 2-1 was unleashed? Yeah, in this way, the explorable area will be expanded! Then this is the final tutorial quest.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Explore Area 5-4";
        QuestNames[1] = "Explore Area 5-8";
        QuestNames[2] = "Explore Area 6-4";
        QuestNames[3] = "Explore Area 6-8";
        QuestNames[4] = "Explore Area 7-4";
        QuestNames[5] = "Explore Area 7-8";
        QuestNames[6] = "Explore Area 8-4";
        QuestNames[7] = "Explore Area 8-8";

        rewardText[0] = "- <sprite=\"se2\" index=0> 100";
        rewardText[1] = "- <sprite=\"se2\" index=0> 200";
        rewardText[2] = "- <sprite=\"se2\" index=0> 500";
        rewardText[3] = "- <sprite=\"se2\" index=0> 1000";
        rewardText[4] = "- <sprite=\"se2\" index=0> 1500";
        rewardText[5] = "- <sprite=\"se2\" index=0> 2500";
        rewardText[6] = "- <sprite=\"se2\" index=0> 4000";
        rewardText[7] = "- <sprite=\"se2\" index=0> 6000";

        //Condition
        Condition[0] = () => main.dungeonAry[(int)Main.Dungeon.Z_fox4].isDungeon;
        Condition[1] = () => main.dungeonAry[(int)Main.Dungeon.Z_fox8].isDungeon;
        Condition[2] = () => main.dungeonAry[(int)Main.Dungeon.Z_MS4].isDungeon;
        Condition[3] = () => main.dungeonAry[(int)Main.Dungeon.Z_MS8].isDungeon;
        Condition[4] = () => main.dungeonAry[(int)Main.Dungeon.Z_DF4].isDungeon;
        Condition[5] = () => main.dungeonAry[(int)Main.Dungeon.Z_DF8].isDungeon;
        Condition[6] = () => main.dungeonAry[(int)Main.Dungeon.Z_BB4].isDungeon;
        Condition[7] = () => main.dungeonAry[(int)Main.Dungeon.Z_BB8].isDungeon;

        CurrentProgress[0] = () => "Area 5-4 is " + isCleared(47);
        CurrentProgress[1] = () => "Area 5-8 is " + isCleared(51);
        CurrentProgress[2] = () => "Area 6-4 is " + isCleared(56);
        CurrentProgress[3] = () => "Area 6-8 is " + isCleared(60);
        CurrentProgress[4] = () => "Area 7-4 is " + isCleared(65);
        CurrentProgress[5] = () => "Area 7-8 is " + isCleared(69);
        CurrentProgress[6] = () => "Area 8-4 is " + isCleared(74);
        CurrentProgress[7] = () => "Area 8-8 is " + isCleared(78);

        UnlockCondition[0] = "Clear Area 5-4";
        UnlockCondition[1] = "Clear Area 5-8";
        UnlockCondition[2] = "Clear Area 6-4";
        UnlockCondition[3] = "Clear Area 6-8";
        UnlockCondition[4] = "Clear Area 7-4";
        UnlockCondition[5] = "Clear Area 7-8";
        UnlockCondition[6] = "Clear Area 8-4";
        UnlockCondition[7] = "Clear Area 8-8";

    }
    string isCleared(int index)
    {
        if (main.SR.isDungeon[index])
            return "cleared.";
        else
            return "unfinished.";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        //    main.S.QuestPoint += QuestPoints[clearNum];
    }

    public override void ExtraUnlockCondition()
    {
        unlock.UnlockCondition = () => main.S.ReincarnationNum >= 1;
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
        switch (clearNum)
        {
            case 1:
                SEbonus = 10;
                break;
            case 2:
                SEbonus = 10 + 20;
                break;
            case 3:
                SEbonus = 10 + 20 + 50;
                break;
            case 4:
                SEbonus = 10 + 20 + 50 + 100;
                break;
            case 5:
                SEbonus = 10 + 20 + 50 + 100 + 150;
                break;
            case 6:
                SEbonus = 10 + 20 + 50 + 100 + 150 + 250;
                break;
            case 7:
                SEbonus = 10 + 20 + 50 + 100 + 150 + 250 + 500;
                break;
            case 8:
                SEbonus = 10 + 20 + 50 + 100 + 150 + 250 + 500 + 1000;
                break;

        }
    }
}
