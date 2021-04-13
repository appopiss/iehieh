using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class AdsCtrl : BASE {

	public Button openButton;
	public Button button1, button2, button3;
    TextMeshProUGUI title1, title2, title3;
    TextMeshProUGUI explain1, explain2, explain3;
	public TextMeshProUGUI adsLeftTimeText;
	public Button watchButton;
	public TextMeshProUGUI apNumText;
	public Button dailyButton;
	bool isDailyBought { get => main.S.isDailyAP; set => main.S.isDailyAP = value; }

	InstantResource ir;
	GameSpeed gs;
	EpicCoin ec;
	// Use this for initialization
	void Awake () {
		StartBASE();
		title1 = button1.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		title2 = button2.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		title3 = button3.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		explain1 = button1.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		explain2 = button2.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		explain3 = button3.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		ir = new InstantResource();
		gs = new GameSpeed();
		ec = new EpicCoin();
		ir.SetUI(button1, title1, explain1);
		gs.SetUI(button2, title2, explain2);
		ec.SetUI(button3, title3, explain3);
	}

	public void OfflineTimeForAds()
	{
		main.S.lastAdsWatchTime -= DeltaTimeFloat(DateTime.FromBinary(Convert.ToInt64(main.S.lastTime)));
	}
	public static double leftTimeForNextAds()
	{
		return Math.Max(5 * 60 - (main.S.realAllTime - main.S.lastAdsWatchTime), 0);
	}
	// Use this for initialization
	void Start () {
		watchButton.onClick.AddListener(() =>
		{
			CrazyAds.Instance.beginAdBreakRewarded(SuccessAds, () => main.Log("Reward Ads failed ... "));
		});
		dailyButton.onClick.AddListener(() => {
			if (!isDailyBought)
				main.S.AP1++;
			isDailyBought = true;
		});
		OfflineTimeForAds();
		openButton.onClick.AddListener(ShowBonusCanvas);
	}
	bool isShowing;
	void ShowBonusCanvas()
	{
		if (!isShowing)
		{
			main.BonusCanvas.enabled = true;
			isShowing = true;
		}
		else
		{
			main.BonusCanvas.enabled = false;
			isShowing = false;
		}
	}
	void SuccessAds()
    {
		main.S.lastAdsWatchTime = main.S.realAllTime;
		main.S.AP1++;
	}
	
	// Update is called once per frame
	void Update () {
		if (leftTimeForNextAds() <= 0)
		    watchButton.interactable = true;
        else
			watchButton.interactable = false;
		if (leftTimeForNextAds() > 0)
    		adsLeftTimeText.text = DoubleTimeToDate(leftTimeForNextAds()) + " left";
        else
			adsLeftTimeText.text = "";
		ir.UpdateUI();
		gs.UpdateUI();
		ec.UpdateUI();
        if (main.S.isDailyAP)
        {
			dailyButton.interactable = false;
        }
        else
        {
			dailyButton.interactable = true;
        }
		apNumText.text = "Bonus Star <sprite=\"starslice\" index=1> " + main.epicShop.TotalBonusPoint();
	}
}
