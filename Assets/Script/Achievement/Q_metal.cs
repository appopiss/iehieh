using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_metal : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ
        AwakeQuest(4, Type.Limited);
        GoldCap = new long[] { 1000, 3000, 5000, 10000};
        CliantName = "Statistic the Alchemic";//"Sick girl's father";
        discription[0] = "A strange fellow dressed in over-sized priestly robes bumps into you while you're wandering the market. \"Oh hello! I apolo... wait, do I sense the power of Metal Slimes on you? They push their finger into a little bit of monster goo on your tunic and then sniff at it curiously. Why yes, I do believe it is! Aha! The gods must have fated our encounter! You see, I need this residue for... well, let's just say I need it. Since you've slain at least one before, can you slay around ten more and bring me as much of their remains as you can carry?\"";
        discription[1] = "Wow, you've brought me back a barrel of metallic slime! You must know, I am researching this to see how similar it is to quicksilver, and what implications it has for my alchemical experiments. However, if this is successful, I will need a lot more than this. Think you could bring me back around 5 more of these barrels? Once you have finished that I will explain more about the nature of my experiments.";
        discription[2] = "Eureka! Oh, you're back? Perfect timing. I've discovered that there is indeed quicksilver that makes up the majority of these metallic blobs, but the slime is the key. It renders it completely harmless when it comes into contact with skin, unlike quicksilver " +
            "or even regular slime, which is likely to melt your skin right off. It's astounding! Not only that, but I've got quite a few ideas for how to make a huge discovery! I'm going to need around five times as much of this as you previously brought, which should take some time." +
            " However I'm certain I will be ready for it all by the time you return!";
        discription[3] = "You return to find the man unconscious, covered in a dust like material that appears to be... gold? He awakens as you are inspecting him, Oh, hello... I managed it! I discovered the formulae to create gold! Gold! He stands and dusts himself off. " +
            "There was a bit of poof that disoriented me and knocked me out for a moment, but you arrived just in time to see the results... that are literally covering me at the moment. You have been invaluable, and I hope you feel well compensated for your efforts. There is " +
            "just one further request I have of you. It is said there is an even rarer monster... the Metal Slime Boss. If you ever encounter one, please bring it is remains back to me. I will award you with more of these potions you can use to empower yourself for each one you bring.";
       //これらの処理は必ずAwakeQues()の後に書く．
       //QuestName
        QuestNames[0] = "A Certain Metallic Statistic 1";
        QuestNames[1] = "A Certain Metallic Statistic 2";
        QuestNames[2] = "A Certain Metallic Statistic 3";
        QuestNames[3] = "A Certain Metallic Statistic 4";
        //Condition
        Condition[0] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime] >= 10;
        Condition[1] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime] >= 50;
        Condition[2] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime] >= 250;
        Condition[3] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime] >= 1000;
        rewardText[0] = "- Gold Cap + " + tDigit(GoldCap[0]);
        rewardText[1] = "- Gold Cap + " + tDigit(GoldCap[1]);
        rewardText[2] = "- Gold Cap + " + tDigit(GoldCap[2]);
        rewardText[3] = "- Gold Cap + " + tDigit(GoldCap[3]);
        CurrentProgress[0] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime]) + " / 10";
        CurrentProgress[1] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime]) + " / 50";
        CurrentProgress[2] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime]) + " / 250";
        CurrentProgress[3] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.MetalSlime]) + " / 1000";
        UnlockCondition[0] = "Kill 10 Metal Slimes!";
        UnlockCondition[1] = "Kill 50 Metal Slimes!";
        UnlockCondition[2] = "Kill 250 Metal Slimes!";
        UnlockCondition[3] = "Kill 1000 Metal Slimes!";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        switch (clearNum)
        {
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
                break;
            case 2:
                GoldCapBonus = GoldCap[1] + GoldCap[0];
                break;
            case 3:
                GoldCapBonus = GoldCap[2] + GoldCap[1] + GoldCap[0];
                break;
            case 4:
                GoldCapBonus = GoldCap[3] + GoldCap[2] + GoldCap[1] + GoldCap[0];
                break;
        }
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }


}
