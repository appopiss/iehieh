using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_1000gold : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
    }
    public override string Name()
    {
        return "1000 Gold Curse";
    }
    public override string RestrictionText()
    {
        return "You might easily understand what happens with this curse from the name. Only 1000 gold is available in next reincarnation!";
    }
    public override string RewardText()
    {
        return "Each Clear - Decrease the cost of Slime Bank Cap upgrade by 2.5% for each completion";
    }
    public override CurseId id => CurseId.curse_of_1000gold;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared 1000 Gold Curse!", main.A_ctrl.platina));
    }
    public override int MaxClearNum => 20;
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum >= 1;
    public override string ConditionText()
    {
        return "Defeat Montblango";
    }
    public static double CostReduction()
    {
        return 1.0d - 0.025 * main.S.CurseReinClearNum[(int)CurseId.curse_of_1000gold];
    }
}
