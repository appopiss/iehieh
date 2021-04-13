using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class Curse_ROW3 : CURSE_RAIN
{
    // Use this for initialization
    void Awake()
    {
        AwakeCurse();
        cf.Stone1000.Add(() =>
        {
            if (ClearNum >= 1)
                return 1000;
            else
                return 1.0;
        });
        cf.MonsterGoldCap.Add(() =>
        {
            return ClearNum * 1000;
        });
    }
    public override string Name()
    {
        return "Road of Warrior 3";
    }
    public override string RestrictionText()
    {
        return "You can only play as a warrior and you can't REBIRTH and you have to progress HIDDEN area!";
    }
    public override string RewardText()
    {
        return "First Clear - Stone production x1000\nEach Clear - Additional monster gold cap +1000 and 2 Proof of Warrior and Warrior Soul each.";
    }
    public override CurseId id => CurseId.curse_of_warrior3;
    public override void GetReward()
    {
        StartCoroutine(main.InstantiateLogText("You cleared Road of Warrior 3!", main.A_ctrl.platina));
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.ProofOfWarrior] += 2;
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.WarriorSoul] += 2;
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
    protected override bool canUnlock => main.S.isUnleashedHidden;
}
