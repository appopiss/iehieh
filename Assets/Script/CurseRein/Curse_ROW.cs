using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_ROW : CURSE_RAIN {

	// Use this for initialization
	void Awake () {
		AwakeCurse();
        cf.AllStatusMul.Add(() =>
        {
            if (main.ally.job == ALLY.Job.Warrior)
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
        return "Road of Warrior";
    }
    public override string RestrictionText()
    {
        return "You can use only WARRIOR through whole reincarnation";
    }
    public override string RewardText()
    {
        return "Each Clear - Warrior Soul *1 and You will get 100 % additional stats for Warrior";
    }
    public override CurseId id => CurseId.road_of_warrior;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Road of Warrior!", main.A_ctrl.platina));
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WarriorSoul] += 1;
    }
    public override int MaxClearNum => 5;
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= 1;
    public override string ConditionText()
    {
        return "Defeat Octobaddie";
    }
}
