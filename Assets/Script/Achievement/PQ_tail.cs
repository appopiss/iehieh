using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PQ_tail : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(0, Type.Permanent);
        CliantName = "Hobart the Tailor";//"Sick girl's father";
        P_discription = "Ahh yes, the spider slayer. Have you brought me more Spider Silk? I'll buy in bundles of 100!";
        //Parmanentの処理を書くよ．
        P_questName = "Eversilken Story";
        P_condition = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] >= 100;
        P_currentProgress = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] + " / 100";
        P_unlockCondition = "Take 100 Spider Silk!";
        P_rewardText = "- Gold Cap + 5\n- 5000 Gold\n- 75000 EXP";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SpiderSilk] -= 100;
            main.SR.gold += 5000;
            main.ally.currentExp += 75000;
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
        GoldCapBonus = clearNum * 5;
    }
}
