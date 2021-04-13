using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class CurseStatsBreakdown : BASE {

	OpenClose openClose;
	public TextMeshProUGUI explainText;
	// Use this for initialization
	void Awake () {
		StartBASE();
		openClose = gameObject.GetComponent<OpenClose>();
	}

    void UpdateString()
    {
		if (!openClose.IsOpen)
			return;

		explainText.text = ExplainText();
    }

    string ExplainText()
    {
		string text = "";
		//AllStatusUp
		if (SumMulDelegate(main.cc.cf.SeMul) != 1.0)
		{
			text = optStr + text + "\u25A0 Spirit Essence Bonus <color=green>×" + SumMulDelegate(main.cc.cf.SeMul);
		}
		if (SumMulDelegate(main.cc.cf.AllStatusMul) != 1.0)
        {
			text = optStr + text + "</color=green>\n\u25A0 All Stats <color=green>×" + SumMulDelegate(main.cc.cf.AllStatusMul);
        }
		if (SumMulDelegate(main.cc.cf.RangeUp) != 1.0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Skill Range <color=green>×" + SumMulDelegate(main.cc.cf.RangeUp);
		}
		if (SumAddDelegate(main.cc.cf.GoldBonus) != 0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Gold Gain <color=green>+" + SumAddDelegate(main.cc.cf.GoldBonus);
		}
		if (SumAddDelegate(main.cc.cf.ExpBonus_Add) != 0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Exp Gain <color=green>+" + tDigit(SumAddDelegate(main.cc.cf.ExpBonus_Add));
		}
		if (SumAddDelegate(main.cc.cf.MonsterGoldCap) != 0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Monster Gold Cap <color=green>+" + SumAddDelegate(main.cc.cf.MonsterGoldCap);
		}
		if (SumAddDelegate(main.cc.cf.Add_HPregen) != 0)
		{
			text = optStr + text + "</color=green>\n\u25A0 HP regeneration <color=green>+" + SumAddDelegate(main.cc.cf.Add_HPregen);
		}
		if (main.cc.cf.Blood_DamageReduction() != 1.0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Damage Reduction <color=green>×" + main.cc.cf.Blood_DamageReduction().ToString("F2");
		}
		if (SumMulDelegate(main.cc.cf.Proficiency) != 1.0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Skill Proficiency <color=green>×" + SumMulDelegate(main.cc.cf.Proficiency);
		}
		if (SumMulDelegate(main.cc.cf.MasteryEffectMultiplier) != 1.0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Area Mastery Effect Bonus <color=green>×" + SumMulDelegate(main.cc.cf.MasteryEffectMultiplier);
		}
		if (SumMulDelegate(main.cc.cf.MasteryNumDecay) != 1.0)
		{
			text = optStr + text + "</color=green>\n\u25A0 Area Mastery Number Reduction <color=green>×" + SumMulDelegate(main.cc.cf.MasteryNumDecay);
		}

		return text;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateString();
	}
}
