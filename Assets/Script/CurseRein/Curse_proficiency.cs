using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_proficiency : CURSE_RAIN
{
    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        main.cc.cf.Proficiency.Add(() =>
        {
            return 1.0 + ClearNum;
        });
    }
    public override string Name()
    {
        return "Curse of Proficiency";
    }
    public override string RestrictionText()
    {
        return "Resource production is rescaled with LOG function. (It means … almost no resources in gameplay :0) ";
    }
    public override string RewardText()
    {
        return "First Clear - Multiply \"Proficiency gain\" (rebirth upgrade) proficiency amount by 10x " +
            "\nEach Clear - +100% proficiency";
    }
    public override CurseId id => CurseId.curse_of_proficiency;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Road of Curse of Proficiency", main.A_ctrl.platina));
    }
    public override int MaxClearNum => 10;
    public override bool ClearCondition()
    {
        switch (ClearNum)
        {
            case 0:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].clearedNum >= 1;
            case 1:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum >= 1;
            case 2:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].clearedNum >= 1;
            case 3:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum >= 1;
            case 4:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum >= 1;
            case 5:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum >= 1;
            case 6:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= 1;
            case 7:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum >= 1;
            default:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum >= 1;
        }
    }
    public override string ConditionText()
    {
        switch (ClearNum)
        {
            case 0:
                return "Defeat Slime King";
            case 1:
                return "Defeat Golem";
            case 2:
                return "Defeat Deathpider";
            case 3:
                return "Defeat Fairy Queen";
            case 4:
                return "Defeat Bananoon";
            case 5:
                return "Defeat Montblango";
            case 6:
                return "Defeat Octobaddie";
            case 7:
                return "Defeat Distortion Slime";
            default:
                return "Defeat Distortion Slime"; ;
        }
    }

    public static double LOG(double number)
    {
        if (main.cc.CurrentCurseId != CurseId.curse_of_proficiency)
            return number;

        if (number == 0)
            return 0;
        return Math.Log(number, main.cc.Curses[(int)CurseId.curse_of_proficiency].ClearNum + 2);
    }
}
