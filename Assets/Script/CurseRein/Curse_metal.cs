using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_metal : CURSE_RAIN
{
    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        main.cc.cf.ExpBonus_Add.Add(() =>
        {
            return main.ally.RequiredExp() * 0.00001d * ClearNum;
        });
    }
    //名前を設定してください。
    public override string Name()
    {
        return "Curse of Metal";
    }
    //条件を設定してください。
    public override string RestrictionText()
    {
        return "Replace all normal enemies with metal slimes";
    }
    //報酬を設定してください。
    public override string RewardText()
    {
        return "Each enemy killed gives you at least 0.001% of the required EXP for the next level, per #clear";
    }
    public override CurseId id => CurseId.curse_of_metal;
    //報酬をえた処理を書いてください。
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Curse of Metal!", main.A_ctrl.platina));
    }
    //最大クリア数を書いてください。
    public override int MaxClearNum => 10;
    //クリアする条件を書いてください。
    public override bool ClearCondition() => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum >= 1;
    //条件のテキストを書いてください。
    public override string ConditionText()
    {
        return "Defeat Octobaddie(?)";
    }
}
