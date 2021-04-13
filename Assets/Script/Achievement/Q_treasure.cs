using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Q_treasure : ACHIEVEMENT
{
    public long[] num;
    public override bool[] isSeen { get => main.S.isS_treasureHunt; set => main.S.isS_treasureHunt = value; }
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(4, Type.Limited);
        num = new long[] { 10, 30, 50, 100 };
        CliantName = "The pathetic old man";
        discription[0] = "Oh dear, could you please help me? A bird took off with my wallet and flew into the forest! My wife is expecting me to bring her a gift for her birthday! Please help me! I cannot go in there!";
        discription[1] = "Oh gracious gods, you found my wallet! Thank you so much! But wait, my money is all gone! Oh dear me, what will I do?!" +
            " I can't go home empty-handed... I know I've already asked a lot of you already, but could you lend me some money? I promise I'll repay the favor somehow!";
        discription[2] = "Oh thank you again so very much! I've already got the gift in mind. A necklace by famed jeweller, Poppy Winston. She is going to love it!"
            + " Oh thank the merciful gods that you are still here. I had just purchased the necklace that I told you about when I was attacked by a slime!"
            + " In my shock, I threw the necklace at the slime and ran! I'm sure that it's floating in that slime still if you could go and find it for me? I'd surely die if I tried.";
        discription[3] = "Oh you found it! You're my hero! Wait, it's corroded from acidic sludge. Hmm, I may be able to fix and polish it back up though!"
            + " I used to be a trainer, before I took an arrow to the knee. If you help me gather the supplies I need, I'll teach you a technique for expanding your equipment slot.";
        //これらの処理は必ずAwakeQues()の後に書く．
        //QuestName
        QuestNames[0] = "Pathetic man 1";
        QuestNames[1] = "Pathetic man 2";
        QuestNames[2] = "Pathetic man 3";
        QuestNames[3] = "Pathetic man 4";
        rewardText[0] = "- Gold Cap + 300";
        rewardText[1] = "- Nothing :x";
        rewardText[2] = "- 1000 Gold";
        rewardText[3] = "- Extra Equipment Slot!";
        //Condition
        Condition[0] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ShabbyPurse] >= 1;
        Condition[1] = () => main.SR.gold >= 1000;
        Condition[2] = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.PoppyWinstonNeckless] >= 1;
        Condition[3] = () => main.SR.stone >= 10000000 && main.SR.cristal >= 10000000;
        CurrentProgress[0] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ShabbyPurse] + " /  1";
        CurrentProgress[1] = () => "Now you have " + tDigit(main.SR.gold) + " /  1000";
        CurrentProgress[2] = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.PoppyWinstonNeckless] + " /  1";
        CurrentProgress[3] = () => "Stone  " + tDigit(main.SR.stone) + " / 10M\n- Crystal  " + tDigit(main.SR.cristal) + " /  10M";
        UnlockCondition[0] = "Find a man's wallet!";
        UnlockCondition[1] = "Give him 1000 Gold!";
        UnlockCondition[2] = "Find Poppy Winston Necklace!";
        UnlockCondition[3] = "Give the resources to repair the necklace!";

        QuestLocal.treasure(ref CliantName, discription, QuestNames, rewardText, UnlockCondition);
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
       switch (clearNum)
       {
           case 0:
               main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ShabbyPurse] -= 1;
               break;
           case 1:
                main.SR.gold -= 1000;
               break;
           case 2:
               main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.PoppyWinstonNeckless] -= 1;
                main.SR.gold += 1000;
               break;
           case 3:
                main.SR.stone -= 10000000;
                main.SR.cristal -= 10000000;
                break;
       }
        //    main.S.QuestPoint += QuestPoints[clearNum];
    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(clearNum >= 1)
        {
            GoldCapBonus = 300;
        }
        if (clearNum >= 4)
        {
            EquipmentBonus = 1;
        }
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
