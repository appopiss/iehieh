using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_blood : CURSE_RAIN
{
    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        main.cc.cf.Blood_DamageReduction = () =>
        {
            return 1.0 - 0.05 * ClearNum;
        };
        main.cc.cf.Add_HPregen.Add(() =>
        {
            if(ClearNum >= 1)
            {
                return 1000;
            }
            else
            {
                return 0;
            }
        });
    }
    public override string Name()
    {
        return "Curse of Blood";
    }
    public override string RestrictionText()
    {
        return "Spells now use HP instead of MP and all the skills and potions intervening HP will be disabled. Also your DEF and MDEF will be set to 0";
    }
    public override string RewardText()
    {
        return "First Clear - You will get fixed amount regeneration of 1000 per second" +
            "\nEach Clear - Your total damage will be reduced by (5 * clear count)%";
    }
    public override CurseId id => CurseId.curse_of_blood;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Road of Curse of Blood", main.A_ctrl.platina));
    }
    public override int MaxClearNum => 10;
    public override bool ClearCondition()
    {
        switch (ClearNum)
        {
            case 0:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum >= 1;
            case 1:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum >= 1;
            case 2:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= 1;
            default:
                return main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].clearedNum >= 1; ;
        }
    }
    public override string ConditionText()
    {
        switch (ClearNum)
        {
            case 0:
                return "Defeat Bananoon";
            case 1:
                return "Defeat Montblango";
            case 2:
                return "Defeat Octobaddie";
            default:
                return "Defeat Distortion Slime";
        }
    }
}
