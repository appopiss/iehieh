using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PQ_leather : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(0, Type.Permanent);
        CliantName = "Hobart the Tailor";//"Sick girl's father";
        P_discription = "I remember you. You brought me those exquisite White Fox Pelt! If you bring me more, I will share some of the power that I extract from them while I work them into clothing for my elite clientele.";
        //Parmanentの処理を書くよ．
        P_questName = "Arman the Leatherworker";
        P_condition = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] >= 250;
        P_currentProgress = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] + " / 250";
        P_unlockCondition = "Take 250 White Fox Pelt!";
        P_rewardText = "- Gold Cap + 100\n- HP + 1%\n- 60000 Gold\n- 500000 EXP";
    }

    //クエストの報酬q  
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WhiteFoxPelt] -= 250;
            main.SR.gold += 60000;
            main.ally.currentExp += 500000;
        }
    }

    public override void ExtraUnlockCondition()
    {
        unlock.UnlockCondition = () => main.quests[(int)ACHIEVEMENT.QuestList.husband].clearNum >= 3;
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
        GoldCapBonus = clearNum * 100;
    }
}
