using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public enum CurseId
{
    normal,
    road_of_warrior,
    road_of_wizard,
    road_of_angel,
    curse_of_monsterFluid,
    curse_of_1000gold,
    curse_of_3equipment,
    curse_of_warrior2,
    curse_of_wizard2,
    curse_of_angel2,
    curse_of_poverty,
    curse_of_proficiency,
    curse_of_blood,
    curse_of_explore,
    curse_of_metal,
    curse_of_warrior3,
    curse_of_wizard3,
    curse_of_angel3,
}

public class CURSE_RAIN : BASE {

	public virtual string Name() { return ""; }
    public virtual string RestrictionText() { return ""; }
    public virtual string RewardText() { return ""; }
    public virtual string ConditionText() { return ""; }
    public int ClearNum { get => main.S.CurseReinClearNum[(int)id]; set => main.S.CurseReinClearNum[(int)id] = value; }
    public virtual int MaxClearNum { get; }
    public virtual CurseId id { get;}
    public virtual bool ClearCondition() { return false; }
    public virtual void GetReward() { }
    protected CurseReinFactor cf;
    protected virtual bool canUnlock { get => true; }
    Button thisButton;
    string _Name()
    {
		return Name();
    }
    string _RestrictionText()
    {
		return "<color=red>Restriction\n</color=red>" + RestrictionText();
	}
    string _RewardText()
    {
        string text;
        if (MaxClearNum == 999)
            text = "∞";
        else
            text = MaxClearNum.ToString();
		return "<color=green>Reward [ " + ClearNum + " / " + text + " ]\n</color=green>" + RewardText();

	}
    string _ConditionText()
    {
        return "<color=yellow>Condition\n</color=yellow>" + ConditionText();
    }
    void SetInfo()
    {
		main.cc.NameText.text = _Name();
		main.cc.RestrictionText.text = _RestrictionText();
		main.cc.RewardText.text = _RewardText();
        main.cc.ConditionText.text = _ConditionText();
		main.cc.Input = () => main.cc.InputCurseId = id;
        if (ClearNum >= MaxClearNum)
        {
            main.cc.SelectButton.interactable = false;
        }
        else
        {
            main.cc.SelectButton.interactable = true;
        }
    }
    void Clear()
    {
        if (ClearNum < MaxClearNum)
            ClearNum++;
        main.cc.CurrentCurseId = CurseId.normal;
    }
	// Use this for initialization
	protected void AwakeCurse () {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(() => SetInfo());
        cf = main.cc.cf;
        StartCoroutine(WaitUntilClear());
	}
    IEnumerator WaitUntilClear()
    {
        //このクラスだけ発動させる
        yield return new WaitUntil(() => main.cc.CurrentCurseId == id);
        while (!ClearCondition())
        {
            yield return null;
            //もしキャンセルされたら、子ルーチンを抜ける
            if (main.cc.isCanceled)
            {
                main.cc.CurrentCurseId = CurseId.normal;
                yield break;
            }
        }
        GetReward();
        Clear();
    }
    void DisableButton()
    {
        if(ClearNum >= MaxClearNum)
        {
            thisButton.interactable = false;
            return;
        }

        if (!canUnlock)
        {
            thisButton.interactable = false;
        }
        else
        {
            thisButton.interactable = true;
        }
    }

    public static bool IsRoad2()
    {
        return main.cc.CurrentCurseId == CurseId.curse_of_wizard2
            || main.cc.CurrentCurseId == CurseId.curse_of_warrior2
            || main.cc.CurrentCurseId == CurseId.curse_of_angel2
            ;
    }
    public static bool IsRoad3()
    {
        return main.cc.CurrentCurseId == CurseId.curse_of_wizard3
            || main.cc.CurrentCurseId == CurseId.curse_of_warrior3
            || main.cc.CurrentCurseId == CurseId.curse_of_angel3
            ;
    }
}
