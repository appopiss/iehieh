using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_ROA2 : CURSE_RAIN
{
    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        cf.RangeUp.Add(() =>
        {
            if (main.ally.job == ALLY.Job.Angel)
            {
                return 1 + ClearNum * 0.1;
            }
            else
            {
                return 1.0;
            }
        });
    }
    public override string Name()
    {
        return "Road of Angel 2";
    }
    public override string RestrictionText()
    {
        return "You may only use the Angel class and your total MP will be capped at 0.";
    }
    public override string RewardText()
    {
        return "Each Clear - Proof Of Angel * 1, and You will get 10 % additional skill range for Angel";
    }
    public override CurseId id => CurseId.curse_of_angel2;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Road of Angel 2!", main.A_ctrl.platina));
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ProofOfAngel] += 1;
    }
    public override int MaxClearNum => 5;
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
            default:
                return false;
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
            default:
                return "";
        }
    }
}
