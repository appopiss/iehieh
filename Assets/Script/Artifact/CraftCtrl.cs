using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class CraftCtrl : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

    public Button allClearEQbutton;
    TextMeshProUGUI buttonText;

	// Use this for initialization
	void Start () {

        allClearEQbutton.onClick.AddListener(()=> {
            if (!main.SR.isAllClearedEQ)
                allClear();
            else
                allEquip();
        });
        if (!main.S.AllClearEQ)
            main.craftCtrl.allClearEQbutton.gameObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(400, 0);

        buttonText = allClearEQbutton.GetComponentInChildren<TextMeshProUGUI>();
        if (!doneOnce)
            StartCoroutine(AdjustEquipment());
    }
    public int currentEquippedNum()
	{
		int num = 0;

		foreach (ARTIFACT arti in main.NewArtifacts)
		{
			if (arti.isEquipped)
			{
				num++;
			}
		}

		return num;
	}

    public void allClear()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        { 

            if (arti.isEquipped)
            {
                main.SR.isEquippedforRemember[(int)arti.artifactName] = true;
                arti.isEquipped = false;
            }
            else
                main.SR.isEquippedforRemember[(int)arti.artifactName] = false;
        }
        main.SR.isAllClearedEQ = true;
        main.ArtifactFactor.UpdateValue();
    }
    public void allEquip()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            arti.isEquipped = main.SR.isEquippedforRemember[(int)arti.artifactName];
        }
        main.SR.isAllClearedEQ = false;
        main.ArtifactFactor.UpdateValue();
    }

    public int MaxFavoriteEquipNum()//Equipment UpgradeとRebirth Upgradeを除いたEquipスロット数
    {
        return maxEquippedNum()
            - (int)main.Ascends[16].calculateCurrentValue() //Rebirth
            - (int)main.StatusUpgrade[3].calculateCurrentValue() //Upgrade
            ;
    }
    public int CurrentFavoriteEquipNum()
    {
        int tempCoint = 0;
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.isFavoriteEquipped)
                tempCoint++;
        }
        return tempCoint;
    }
    public int LeftFavoriteEquipSlotNum()//残りのFavoriteスロット数
    {
        return MaxFavoriteEquipNum() - CurrentFavoriteEquipNum();
    }
    public bool CanFavorite()
    {
        return LeftFavoriteEquipSlotNum() > 0;
    }

    public int maxEquippedNum()
    {
        int ChallengeFactor = 0;
        foreach (QUEST quest in main.QuestCtrl.Quests)
        {
            if (quest.isCleared)
            {
                ChallengeFactor += 1;
            }
        }
        int QuestFactor = 0;
        foreach (ACHIEVEMENT quest in main.quests)
        {
            if (quest == null)
                continue;
            QuestFactor += quest.EquipmentBonus;
        }
        return 1 + ChallengeFactor
            + (int)main.Ascends[16].calculateCurrentValue() //Rebirth
            + (int)main.StatusUpgrade[3].calculateCurrentValue() //Upgrade
                                                                 //+ main.S.EquipmentBuyNum
            + QuestFactor
            + main.MissionMileStone.EquipmentBonus()
            + main.S.EquipmentSlotNum//EpicStore
            + main.S.EquipmentSlotNum2//EpicStore
            + main.S.EquipmentSlotNum3//EpicStore
            + (int)main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.EQSlot].GetCurrentValue()
            + (int)main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.eq];

        ;
        //初期値は１ね！
    }
    bool doneOnce;

    
    // Update is called once per frame
    void Update() {
		if (main.GameController.currentCanvas == main.GameController.ArtifactCanvas)
		{
			main.Texts[13].text = main.TextEdit(new string[] { "Equipped  ", currentEquippedNum().ToString(), " / ", maxEquippedNum().ToString() });
            if (main.S.FavoriteEquip)
                main.Texts[13].text += main.TextEdit(new string[] { "<size=10>  ( Favorite : ", CurrentFavoriteEquipNum().ToString(), " / ", MaxFavoriteEquipNum().ToString(), " )" });
            if (main.SR.isAllClearedEQ)
                buttonText.text = "Undo";
            else
                buttonText.text = "All Clear";
        }
    }
    IEnumerator AdjustEquipment()
    {
        yield return new WaitUntil(() => TitleCtrl.isLoaded);
        yield return new WaitForSeconds(0.5f);
        if (!doneOnce)
        {
            if (main.craftCtrl.currentEquippedNum() > main.craftCtrl.maxEquippedNum())
            {
                foreach (ARTIFACT equipment in main.NewArtifacts)//EQ数を調整
                {
                    if (main.craftCtrl.currentEquippedNum() > main.craftCtrl.maxEquippedNum() && equipment.isEquipped)
                    {
                        if (!equipment.isFavoriteEquipped)
                            equipment.isEquipped = false;
                    }
                }
            }
            doneOnce = true;
        }
    }
}
