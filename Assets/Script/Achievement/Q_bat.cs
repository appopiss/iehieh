using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_bat : ACHIEVEMENT
{
    public override bool[] isSeen { get => main.S.isS_errand; set => main.S.isS_errand = value; }

    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ
        AwakeQuest(5, Type.Limited);
        GoldCap = new long[] { 200, 500, 1000, 2500,2500 };
        CliantName = "Lazlo the Merchant";//"Sick girl's father";
        discription[0] = "Oh you there. You are an adventurer, yes? The worst thing has happened to me. My cart has been devoured by slimes. My poor Guinevere was also lost. Prize steed she was, and I need 5000 Gold if I ever hope to replace her. Can you help me, please... I" +
            " promise I will make it worth your while!";
        discription[1] = "Oh joyous day! I’d rub this in my wife's face, since she never believed in the goodness of strangers. Pity she was also in the wagon when the slimes devoured it. Now I can get a new horse and get back to commerce! Hmm, but I hear the road is through " +
            "the Forest of Unending Night. Can you clear the path for me? I have only a limited stock right now, but I could probably find something you'll find useful.";
        discription[2] = "Oh thank you! Those bats were terrifying. Now I was able to retrieve some hidden supply caches while you were busy fighting, so we are even now. I have another proposal. The next town has a fine tailor who always needs spider silk. If you bring me 250 Spider Silk, I think we can both benefit tremendously!";
        discription[3] = "This partnership we are building has been most profitable! If you're interested in another deal, our next destination is an old friend of mine who particularly enjoys collecting fairy relics. They'll pay well and as always, I'll make it worth your while.";
        discription[4] = "May I just say we make a great team?! You risking life and limb to slay monsters and me raking in a fortune from your efforts! I just got another great tip. There are rare white foxes that can be found in a mysterious hole in the woods. Bring me 100 White Fox Pelts and I'll introduce you to my friend, Arman the Leatherworker, in the next town over.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "An Adventure in Commerce 1";
        QuestNames[1] = "An Adventure in Commerce 2";
        QuestNames[2] = "An Adventure in Commerce 3";
        QuestNames[3] = "An Adventure in Commerce 4";
        QuestNames[4] = "An Adventure in Commerce 5";
        //Condition
        Condition[0] = () => main.SR.gold >= 5000;
        Condition[1] = () => main.dungeonAry[(int)Main.Dungeon.Z_batBlackCorridor].isDungeon;
        Condition[2] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] >= 250;
        Condition[3] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] >= 400 && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] >= 10 && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] >= 1;
        Condition[4] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] >= 100;
        rewardText[0] = "- Gold Cap + " + tDigit(GoldCap[0]);
        rewardText[1] = "- Gold Cap + " + tDigit(GoldCap[1]) + "\n- 200 Monster Fluid";
        rewardText[2] = "- Gold Cap + " + tDigit(GoldCap[2]) + "\n- New Quest!";
        rewardText[3] = "- Gold Cap + " + tDigit(GoldCap[3]) + "\n- New Quest!";
        rewardText[4] = "- Gold Cap + " + tDigit(GoldCap[4]) + "\n- Nitro Cap + 500\n- New Quest!";
        CurrentProgress[0] = () => "Now you have " + tDigit(main.SR.gold) + " / 5000";
        CurrentProgress[1] = () => "";
        CurrentProgress[2] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] + " / 250";
        CurrentProgress[3] = () => "Fairy Coins " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] + " / 400\n" +
        "- Blood of Fairy " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] + " / 10\n" +
        "- Fairy Heart " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] + " / 1";
        CurrentProgress[4] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] + " / 100";
        UnlockCondition[0] = "Take 5000 Gold";
        UnlockCondition[1] = "Clear Area 2-8";
        UnlockCondition[2] = "Take 250 Spider Silk";
        UnlockCondition[3] = "Take 400 Fairy Coin, 10 Blood of fairy and 1 Fairy Heart";
        UnlockCondition[4] = "Take 100 White Fox Pelt";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
            switch (clearNum)
            {
                case 0:
                main.SR.gold -= 5000;
                    break;
                case 1:
                    break;
                case 2:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] -= 250;
                    break;
                case 3:
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] -= 400;
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] -= 10;
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] -= 1;
                break;
                case 4:
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] -= 100;
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
            case 5:
                GoldCapBonus = GoldCap[4] + GoldCap[3] + GoldCap[2] + GoldCap[1] + GoldCap[0];
                NitroBonus = 500;
                break;
        }
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }

    public override void UpdateNitro()
    {
        if(clearNum >= 5)
            NitroBonus = 500;
    }

}
