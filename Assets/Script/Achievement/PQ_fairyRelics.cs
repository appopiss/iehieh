using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PQ_fairyRelics : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(0, Type.Permanent);
        CliantName = "An obsessed hermit";//"Sick girl's father";
        P_discription = "Oh you're the one who brought me those fairy relics from before, yes? Oh please tell me you have more! I simply cannot collect enough of them! I'll share some magic with you for every delivery you make!";
        //Parmanentの処理を書くよ．
        P_questName = "Fairy Relics";
        P_condition = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] >= 200
        && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] >= 5
        && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] >= 1;
        P_currentProgress = () => "Fairy Coins " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] + " / 200" +
        "\n- Blood of Fairy " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] + " / 5" +
        "\n- Fairy Heart " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] + " / 1";
        P_unlockCondition = "Take 200 Fairy Coin, 5 Blood of Fairy and 1 Fairy Heart";
        P_rewardText = "- Gold Cap + 25\n- 20000 Gold\n- 150000 EXP";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCoin] -= 200;
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BloodOfFairy] -= 5;
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyHeart] -= 1;
            main.SR.gold += 20000;
            main.ally.currentExp += 150000;
        }
    }

    public override void ExtraUnlockCondition()
    {
        unlock.UnlockCondition = () => main.quests[(int)ACHIEVEMENT.QuestList.husband].clearNum >= 4;
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
        GoldCapBonus = clearNum * 25;
    }
}
