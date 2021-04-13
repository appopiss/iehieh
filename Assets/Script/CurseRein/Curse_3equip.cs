using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_3equip : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
    }
    public override string Name()
    {
        return "Curse of 3 equipments";
    }
    public override string RestrictionText()
    {
        return "You can equip only 3 equipments through reincarnation";
    }
    public override string RewardText()
    {
        return "Comming Soon!";
    }
    public override CurseId id => CurseId.curse_of_3equipment;
    public override void GetReward()
    {
        //EPIC装備を1つ手に入れる。素材で代用？
    }
    public override int MaxClearNum => 20;
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum >= 1;
    public override string ConditionText()
    {
        return "Defeat Montblango";
    }
}
