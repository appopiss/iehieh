using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_poverty : CURSE_RAIN
{

    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        StartCoroutine(Efficienter());
        main.cc.cf.GoldBonus.Add(() =>
        {
            if (ClearNum >= 1)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        });
        main.cc.cf.MonsterGoldCap.Add(() =>
        {
            return 200 * ClearNum;
        });
    }
    public override string Name()
    {
        return "Curse of Poverty";
    }
    public override string RestrictionText()
    {
        return "Monster Gold Cap is Divided by 100. Also, all materials are sold for 1 gold.";
    }
    public override string RewardText()
    {
        return "First Clear - you can receive extra +10 gold bonus.\nEach Clear - you can get additional 200 monster gold cap per completion.";
    }
    public override CurseId id => CurseId.curse_of_poverty;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You Cleared Curse of Poverty!", main.A_ctrl.platina));
    }
    public override int MaxClearNum => 999;
    public override bool ClearCondition() => totalNum >= GoalLevel();
    public override string ConditionText()
    {
        return "Reach total sum level of the bottom row of upgrades in Upgrade tab to " + GoalLevel() + ".\nCurrent : " + totalNum;
    }
    int GoalLevel()
    {
        return ClearNum * 100 + 100;
    }
    WaitForSeconds wait = new WaitForSeconds(1.0f);
    IEnumerator Efficienter()
    {
        totalNum = TotalNum();
        while (true)
        {
            totalNum = TotalNum();
            if (main.cc.InputCurseId == CurseId.curse_of_poverty)
                main.cc.ConditionText.text = ConditionText();
            yield return wait;
        }
    }
    int totalNum;
    int TotalNum()
    {
        int temp = 0;
        for (int i = 0; i < main.StatusUpgrade.Length; i++)
        {
            temp += main.StatusUpgrade[i].level;
        }
        return temp;
    }
}
