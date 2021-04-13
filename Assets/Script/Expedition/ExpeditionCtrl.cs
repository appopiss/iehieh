using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;
using UnityEditor;

public enum SquidId
{
	slime,
	golem,
	spider,
	fairy,
	banana,
	monty
}
public enum Hour
{
	_1H,
	_4H,
	_8H,
	_24H
}

public enum EX_state
{
	waiting,
	working,
	completed
}


public class Unlock : MonoBehaviour
{
	protected virtual bool isUnlocked { get; set; }
	protected virtual bool UnlockCondition() { return false; }
	protected virtual void UnlockAction() { }
	protected virtual string UnlockText() { return "Write Some Unlock Condition"; }
	WaitUntil wait;
	void DestroyPanel(GameObject game)
    {
		Destroy(game);
    }
	//Awakeでこれを呼ぶ
	public IEnumerator Unlocking(GameObject panel)
	{
		//すでにアンロックされていたら。。。
		if (isUnlocked)
		{
			UnlockAction();
			DestroyPanel(panel);
			isUnlocked = true;
			yield break;
		}

		wait = new WaitUntil(() => !isUnlocked && UnlockCondition());
		//Unlockする
		UnlockAction();
		isUnlocked = true;
	}
}
//SingleTon
public class SlimeUnlock : Unlock
{
    protected override bool isUnlocked { get => main.S.EX_isUnlocked[(int)SquidId.slime]; set => main.S.EX_isUnlocked[(int)SquidId.slime] = value; }
    protected override void UnlockAction()
    {
		main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] -= 3;
	}

    protected override bool UnlockCondition()
    {
		return main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] >= 3;
    }
	
    protected override string UnlockText()
    {
		return "Slime Squid\n< size = 14 >< Required > -Slime Core \u00D7 3";
    }
}
public class ExpeditionCtrl : BASE {

	public Button[] hourButtons;
	public Button cancelButton;
	public Button departButton;
	TextMeshProUGUI departButtonText;
	public SQUID_UI[] UI;
	public Image selectedImage;
	SQUID[] squids;
	SQUID currentSquid;
	Hour CurrentInputHour;
	// Use this for initialization
	void Awake () {
		//ボタン
		hourButtons[0].onClick.AddListener(() => CurrentInputHour = Hour._1H);
		hourButtons[1].onClick.AddListener(() => CurrentInputHour = Hour._4H);
		hourButtons[2].onClick.AddListener(() => CurrentInputHour = Hour._8H);
		hourButtons[3].onClick.AddListener(() => CurrentInputHour = Hour._24H);
		//
		UI[(int)SquidId.slime].gameObject.AddComponent<SlimeUnlock>();
		UI[(int)SquidId.golem].gameObject.AddComponent<SlimeUnlock>();
		UI[(int)SquidId.spider].gameObject.AddComponent<SlimeUnlock>();
		UI[(int)SquidId.fairy].gameObject.AddComponent<SlimeUnlock>();
		UI[(int)SquidId.banana].gameObject.AddComponent<SlimeUnlock>();
		UI[(int)SquidId.monty].gameObject.AddComponent<SlimeUnlock>();
		squids = new SQUID[UI.Length];
        for (int i = 0; i < UI.Length; i++)
        {
			int count = i;
			//Squidインスタンス化
			squids[i] = new SQUID((SquidId)count, UI[count]);
			UI[i].Listener(() => {
				currentSquid = squids[count];
				selectedImage.sprite = UI[count].sprite1;
				});
			StartCoroutine(UI[i].GetComponent<Unlock>().Unlocking(UI[count].UnlockPanel));
        }
		hourButtons[0].onClick.Invoke();
		currentSquid = squids[0];
		departButtonText = departButton.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
		departButton.onClick.AddListener(() => Departure());
		cancelButton.onClick.AddListener(() => Cancel());
	}

	void Departure()
    {
		switch (currentSquid.GetState)
		{
			case EX_state.waiting:
				currentSquid.Start(CurrentInputHour);
				break;
			case EX_state.completed:
				currentSquid.GetReward();
				break;
		}
	}
	void Cancel()
    {
		currentSquid.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        switch (currentSquid.GetState)
        {
			case EX_state.waiting:
				departButton.interactable = true;
				cancelButton.interactable = false;
				departButtonText.text = "Depart";
				break;
			case EX_state.working:
				departButton.interactable = false;
				cancelButton.interactable = true;
				departButtonText.text = "Working";
				break;
			case EX_state.completed:
				departButton.interactable = true;
				cancelButton.interactable = false;
				departButtonText.text = "CLAIM";
				break;
		}
        for (int i = 0; i < squids.Length; i++)
        {
			squids[i].Update();
        }
	}
}
