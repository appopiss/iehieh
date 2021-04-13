using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_Explore : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        main.cc.cf.MasteryEffectMultiplier.Add(() =>
        {
            return 1 + ClearNum * 0.2;
        });
        main.cc.cf.MasteryNumDecay.Add(() =>
        {
            return 1 - 0.15 * ClearNum;
        });
    }
    //名前を設定してください。
    public override string Name()
    {
        return "Explorer's Nightmare";
    }
    //条件を設定してください。
    public override string RestrictionText()
    {
        return "The explorer's tab is broken. You go through each zone unable to stop yourself or traveling backwards." +
            "You failed this curse when you die during explore EVEN ONCE";
    }
    //報酬を設定してください。
    public override string RewardText()
    {
        return "+20% for area mastery effect and -15% for next bonus requirement per #clear";
    }
    public override CurseId id => CurseId.curse_of_explore;
    //報酬をえた処理を書いてください。
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Explorer's Nightmare!", main.A_ctrl.platina));
    }
    //最大クリア数を書いてください。
    public override int MaxClearNum => 5;
    public override bool ClearCondition()
    {
        switch (ClearNum)
        {
            case 0:
                return main.dungeonAry[(int)Main.Dungeon.Z_fairy8].isDungeon;
            case 1:
                return main.dungeonAry[(int)Main.Dungeon.Z_fox8].isDungeon;
            case 2:
                return main.dungeonAry[(int)Main.Dungeon.Z_MS8].isDungeon;
            case 3:
                return main.dungeonAry[(int)Main.Dungeon.Z_DF8].isDungeon;
            case 4:
                return main.dungeonAry[(int)Main.Dungeon.Z_BB8].isDungeon;
            default:
                return false;
        }
    }
    public override string ConditionText()
    {
        switch (ClearNum)
        {
            case 0:
                return "clear 4-8 WITHOUT DEATH";
            case 1:
                return "clear 5-8 WITHOUT DEATH";
            case 2:
                return "clear 6-8 WITHOUT DEATH";
            case 3:
                return "clear 7-8 WITHOUT DEATH";
            case 4:
                return "clear 8-8 WITHOUT DEATH";
            default:
                return "";
        }
    }
    WaitForSeconds wait = new WaitForSeconds(1.0f);
}
