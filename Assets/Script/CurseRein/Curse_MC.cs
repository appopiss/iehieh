using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_MC : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        //アップデートによる修正
        if(ClearNum > MaxClearNum)
        {
            ClearNum = MaxClearNum;
        }
    }
    public override string Name()
    {
        return "Curse of Monster Fluid";
    }
    public override string RestrictionText()
    {
        return "All the drops from enemies are replaced with Monster Fluids. You can still get other materials from bestiary loot.";
    }
    public override string RewardText()
    {
        return "Each Clear - You can get 25000 * #clear monster fluids every time you rebirth";
    }
    public override CurseId id => CurseId.curse_of_monsterFluid;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Curse of Monster Fluid!", main.A_ctrl.platina));
    }
    public override int MaxClearNum => 20;
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >=1;
    public override string ConditionText()
    {
        return "Defeat Octobaddie";
    }
    public static void GetMonsterFluid()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 25000 * main.S.CurseReinClearNum[(int)CurseId.curse_of_monsterFluid];
    }
}
