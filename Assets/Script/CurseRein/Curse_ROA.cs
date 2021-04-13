using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_ROA : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        cf.AllStatusMul.Add(() =>
        {
            if (main.ally.job == ALLY.Job.Angel)
            {
                return 1 + ClearNum;
            }
            else
            {
                return 1.0;
            }
        });
    }
    public override string Name()
    {
        return "Road of Angel";
    }
    public override string RestrictionText()
    {
        return "You can use only ANGEL through whole reincarnation";
    }
    public override string RewardText()
    {
        return "Each Clear - Angel Soul *1 and You will get 100 % additional stats for ANGEL";
    }
    public override CurseId id => CurseId.road_of_angel;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Road of Angel!", main.A_ctrl.platina));
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.AngelSoul] += 1;
    }
    public override int MaxClearNum => 5;
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= 1;
    public override string ConditionText()
    {
        return "Defeat Octobaddie";
    }
}
