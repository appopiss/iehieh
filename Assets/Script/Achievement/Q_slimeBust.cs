
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ArtiCtrl.MaterialList;

public class Q_slimeBust : ACHIEVEMENT {

    public long[] ClickNum;
    public long[] EpicCoins;
	// Use this for initialization
	void Awake () {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(4, Type.Limited);
        ClickNum = new long[]{ 500,1500,3000,15};
        EpicCoins = new long[] { 1, 3, 5, 10 };
        CliantName = "Gastronomic critic";
        discription[0] = "Hello! I'm a chef looking to provide my clients with the most exquisite cuisines they've ever seen. They're bored of everything else I've done, so I'm looking for new ingredients. Something they've never tried before!"
            + " I've decided to try my hand at serving slime puddings. Would you be able to slay around 300 Blue Slimes for me? That should give me enough to work with for a while!";
        discription[1] = "Ahh thank you. One moment while I prepare a sample. (Hours pass) Ahh good you're still here. It's got excellent texture, but the flavor leaves much to be desired."
            + " Yes, so you don't seem busy at the moment. Could you slay a plethora of Yellow Slimes and bring back their oozy little corpse goop to me? (He immediately leaves before you can protest)";
        discription[2] = "Aha! Exquisite my friend, well done! I shall cook up a sample immediately. (Hours pass) So this one definitely has more flavor than those normal slimes did!"
            + " It's unnaturally cold, so I may use it to make some slimebet. What? That's my slime sorbet! Anyways, I need you to go get me some Red Slime now. Well?" +
   " Go on, shoo shoo! (You're starting to hate this guy)";
        discription[3] = "Oh yes, the red slimes are so warm! I can prepare all sorts of hot and even spicy dishes with this! Hmm, you look bored so I have one last favor to ask."
            + " If these slimes are this delicious, just imagine what Slime King would taste like! My clients will pay me a fortune to even try it! " +
   "Hurry up and get it for me. (Are you getting paid enough to put up with this guy?)";
        //これらの処理は必ずAwakeQues()の後に書く．
        rewardText[0] = "- 100 Monster Fluids" + LetterImage() + " 10";
        rewardText[1] = "- 300 Monster Fluids" + LetterImage() + " 30";
        rewardText[2] = "- 500 Monster Fluids" + LetterImage() + " 50";
        rewardText[3] = "- 3000 Monster Fluids"  + LetterImage() + " 100";
        //QuestName
        QuestNames[0] = "Slime Bust";
        QuestNames[1] = "Slime Bust Again!";
        QuestNames[2] = "They are still alive...";
        QuestNames[3] = "Let them Extinct!";
        //Condition
        UnlockCondition[0] = "Kill " + tDigit(ClickNum[0]) + " Blue Slimes!";
        UnlockCondition[1] = "Kill " + tDigit(ClickNum[1]) + " Yellow Slimes!";
        UnlockCondition[2] = "Kill " + tDigit(ClickNum[2]) + " Red Slimes!";
        UnlockCondition[3] = "Kill " + tDigit(ClickNum[3]) + " Slime Kings!";
        Condition[0] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.BlueSlime] >= ClickNum[0];
        Condition[1] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.YellowSlime] >= ClickNum[1];
        Condition[2] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.RedSlime] >= ClickNum[2];
        Condition[3] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.SlimeKing] >= ClickNum[3];
        CurrentProgress[0] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.BlueSlime]) + " / " + tDigit(ClickNum[0]);
        CurrentProgress[1] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.YellowSlime]) + " / " + tDigit(ClickNum[1]);
        CurrentProgress[2] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.RedSlime]) + " / " + tDigit(ClickNum[2]);
        CurrentProgress[3] = () => "You have killed " + tDigit(main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.SlimeKing]) + " / " + tDigit(ClickNum[3]);
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        switch (clearNum)
        {
            case 0:
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 100;
                break;
            case 1:
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 300;
                break;
            case 2:
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 500;
                break;
            case 3:
                main.ArtiCtrl.CurrentMaterial[MonsterFluid] += 3000;
                break;
        }
        GetEC(EpicCoins[clearNum]);
        //main.S.ECbyQuest += EpicCoins[clearNum];
    }

    // Use this for initialization
    void Start () {
        StartQuest();
	}
	
	// Update is called once per frame
	void Update () {
        switch (clearNum)
        {
            case 1:
                SEbonus = 1;
                break;
            case 2:
                SEbonus = 1 + 3;
                break;
            case 3:
                SEbonus = 1 + 3 + 5;
                break;
            case 4:
                SEbonus = 1 + 3 + 5 + 10;
                break;
        }
        UpdateQuest();
	}
}
