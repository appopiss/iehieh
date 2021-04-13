using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class SQUID_UI : BASE {

	TextMeshProUGUI levelText;
	TextMeshProUGUI expText;
	TextMeshProUGUI timeText;
	TextMeshProUGUI stateText;
	Image _enemyImage;
	public Button button;
	public Sprite sprite1;
	public Sprite sprite2;
	//unlock panel
	[NonSerialized]
	public GameObject UnlockPanel;
	TextMeshProUGUI UnlockText;
	// Use this for initialization
	void Awake () {
		StartBASE();
		_enemyImage = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
		levelText = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
		expText = gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
		timeText = gameObject.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
		stateText = gameObject.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>();
		UnlockPanel = gameObject.transform.GetChild(7).gameObject;
		UnlockText = UnlockPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
		button = gameObject.GetComponent<Button>();
	}

	public Image enemyImage => _enemyImage;
	public void Listener(Action action)
    {
		button.onClick.AddListener(() => action());
    }
	public void ChangeLevelText(int level)
    {
		levelText.text = optStr + "LV <color=green>" + level;
    }
	public void ChangeExpText(double currentExp, double requiredExp)
    {
		expText.text = optStr + "[ " + tDigit(currentExp) + " / " + tDigit(requiredExp) + " ]";
    }
	public void ChangeTimeText(float currentTime, float RequiredTime)
    {
		timeText.text = optStr + "Time Left " + DoubleTimeToDate(RequiredTime - currentTime);
    }
	public void ChangeStateText(EX_state state)
    {
        switch (state)
        {
			case EX_state.waiting:
				stateText.text = optStr + "\u25A1  Waiting";
				return;
			case EX_state.working:
				stateText.text = optStr + "\u25A1<color=red>  Working";
				return;
			case EX_state.completed:
				stateText.text = optStr + "\u25A1<color=green>  Waiting";
				return;
		}
    }
}
