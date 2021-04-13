using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_tutorial : ACHIEVEMENT
{
    public long[] num;
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(4, Type.Limited);
        //num = new long[] { 10, 30, 50, 100 };
        CliantName = "Stranger";
        discription[0] = "Welcome to Incremental Epic Hero! Since this is your first quest, let's start easy. Why not get out there an defeat around 300 normal slimes.";
        discription[1] = "Excellent work! Now while you were slaying those slimes you may have collected some Monster Fluid. I need five for something I am preparing for you. If you have already used what you previously collected, it shouldn't take long for you to collect more. It can be acquired from almost all common monsters. If you need further help knowing what monsters you can collect it from, consult your Bestiary!";
        discription[2] = "Terrific job! I've heard that Area 1-3 is overrun with slimes. You may have already cleared it by this point, but if not would you mind? Keeping the monster population low helps you as well! The more you slay, the more likely you will be able to acquire something from that specific type of monster! It also helps when you stay in an Area, as the more times you clear it, the more familiar the surroundings become, resulting in improved performance and more loot!";
        discription[3] = "You're doing a great job! Now I want to let you know that area 2-1 is now available for you to explore. The bats in that area have gotten out of hand, so before we conclude this training quest line, I'd ask that you clear Area 2-1 at least once. I will reward you with a very powerful second skill slot, which will make it much easier for you to progress! Good luck!";
        //discription[0] = "Hey Hero! For no specific reason, I'd like to ask you to kill 300 slimes. Well, I don't know why I'm asking you to do so...";
        //discription[1] = "Thank you for killing them! Oh I've just heard the voice of heaven. Then I have to ask you to bring 5 Monster Fluid right now.";
        //discription[2] = "Hmm... yeah, I'm thinking why I am here. Maybe... perhaps..., this is so-called tutorial? Oh... I've just noticed that my left hand hold a guidelines of this game. Let me see... Alright, then I have to ask you to clear Area 1-3!";
        //discription[3] = "Great job! Well, I was reading the guidlines while you explore the areas. Did you notice the Area 2-1 was unleashed? Yeah, in this way, the explorable area will be expanded! Then this is the final tutorial quest.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Tutorial Quest 1";
        QuestNames[1] = "Tutorial Quest 2";
        QuestNames[2] = "Tutorial Quest 3";
        QuestNames[3] = "Tutorial Quest 4";
        rewardText[0] = "- 1000 Gold";
        rewardText[1] = "- Gold Cap + 100";
        rewardText[2] = "- 50 Monster Fluids";
        rewardText[3] = "- Extra Skill Slot";
        //Condition
        Condition[0] = () => main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.NormalSlime] >= 300;
        Condition[1] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] >= 5;
        Condition[2] = () => main.dungeonAry[(int)Main.Dungeon.Z_slimePlains].isDungeon;
        Condition[3] = () => main.dungeonAry[(int)Main.Dungeon.Z_batDarkForest].isDungeon;
        CurrentProgress[0] = () => "You killed " + main.S.totalEnemiesKilled[(int)ENEMY.EnemyKind.NormalSlime] + " /  300";
        CurrentProgress[1] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] + " /  5";
        if(main.SR.isDungeon[10])
            CurrentProgress[2] = () => "Area 1-3 is cleared.";
        else
            CurrentProgress[2] = () => "Area 1-2 is cleared. ";
        if(main.SR.isDungeon[16])
            CurrentProgress[3] = () => "Area 2-1 is cleared.";
        else
            CurrentProgress[3] = () => "Area 1-3 is cleared. ";
        UnlockCondition[0] = "Defeat 300 Normal Slimes";
        UnlockCondition[1] = "Bring 5 Monster Fluid";
        UnlockCondition[2] = "Clear Area 1-3";
        UnlockCondition[3] = "Clear Area 2-1";

        QuestLocal.tutorial(ref CliantName, discription, QuestNames, rewardText, UnlockCondition);
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        switch (clearNum)
        {
            case 0:
                //main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ShabbyPurse] -= 1;
                main.SR.gold += 1000;
                break;
            case 1:
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] -= 5;
                break;
            case 2:
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 50;
                break;
            case 3:
                main.skillSetController.UnleashSkillSlot();
                break;
        }
        //    main.S.QuestPoint += QuestPoints[clearNum];
    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
        gameObject.GetComponent<UL_quest>().UnlockCondition = () => true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
        if(clearNum >= 2)
        {
            GoldCapBonus = 100;
        }
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
