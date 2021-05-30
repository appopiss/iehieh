using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System.Text;

public class DRctrl : BASE {

    public Plain_PopText windowText;
    string initialText;
	// Use this for initialization..
	void Awake () {
		StartBASE();
        WorkerBuyButton[0].onClick.AddListener(() => W_buymode = WorkerBuyMode.mode1);
        WorkerBuyButton[1].onClick.AddListener(() => W_buymode = WorkerBuyMode.modeMax);
        JemDistributeButton[0].onClick.AddListener(() => J_buyMode = JemBuyMode.mode1);
        JemDistributeButton[1].onClick.AddListener(() => J_buyMode = JemBuyMode.mode10);
        JemDistributeButton[2].onClick.AddListener(() => J_buyMode = JemBuyMode.mode100);
        JemDistributeButton[4].onClick.AddListener(() => J_buyMode = JemBuyMode.mode25p);
        JemDistributeButton[5].onClick.AddListener(() => J_buyMode = JemBuyMode.mode50p);
        JemDistributeButton[6].onClick.AddListener(() => J_buyMode = JemBuyMode.mode75p);
        JemDistributeButton[7].onClick.AddListener(() => J_buyMode = JemBuyMode.modeMax);
        UpgradeToDarkRitual.onClick.AddListener(() => {
            UpgradePanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500f);
            DarkRitualPanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500f);
            main.idleBackGround.isDarkRitual = true;
        });
        BackToUpgrade.onClick.AddListener(() => {
            UpgradePanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500f);
            DarkRitualPanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500f);
            main.idleBackGround.isDarkRitual = false;
        });
        BuyButton.onClick.AddListener(Buy);
        CapButton.onClick.AddListener(Cap);
        initialText = windowText.text;
    }

    private void Update()
    {
        if(main.GameController.currentCanvas == main.GameController.IdleCanvas)
        {
            WorkerNumText.text = tDigit(main.SR.WorkerNum) + " / " + tDigit(MaxWorkerNum());
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy (" + BuyCost().num + ")";
            CapButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy (" + CapCost().num + ")";
            BuyCostText.text = "<sprite=0>  " + tDigit(BuyCost().cost);
            CapCostText.text = "<sprite=0>  " + tDigit(CapCost().cost);
            if (main.SR.gold < BuyCost().cost)
                BuyButton.interactable = false;
            else
                BuyButton.interactable = true;

            if (main.SR.gold < CapCost().cost)
                CapButton.interactable = false;
            else
                CapButton.interactable = true;

            if (windowText.window.activeSelf)
                windowText.text = showDRfactor();
        }
    }

    public TextMeshProUGUI WorkerNumText;
    public TextMeshProUGUI BuyCostText;
    public TextMeshProUGUI CapCostText;
    public Button[] WorkerBuyButton;
    public Button[] JemDistributeButton;
    public Button BuyButton;
    public Button CapButton;
    public Button BackToUpgrade;
    public Button UpgradeToDarkRitual;
    public GameObject UpgradePanel;
    public GameObject DarkRitualPanel;
    public enum WorkerBuyMode
    {
        mode1,
        modeMax
    }   
    public enum JemBuyMode
    {
        mode1,
        mode10,
        mode100,
        mode1000,
        mode25p,
        mode50p,
        mode75p,
        modeMax
    }
    WorkerBuyMode W_buymode;
    public JemBuyMode J_buyMode;
    public long workerNum {
        get
        {
            return main.SR.WorkerNum;
        }
        set
        {
            main.SR.WorkerNum = value;
        }
    }
    private void Start()
    {
        CheckWorkerNum();
    }

    void CheckWorkerNum()
    {
        long tempValue = main.SR.WorkerNum;
        for (int i = 0; i < main.jems.Length; i++)
        {
            tempValue += main.jems[i].CurrentWorkerNum;
        }
        main.SR.BuyLevel = tempValue;
    }

    public long MaxWorkerNum()
    {
        return main.SR.BuyLevel; 
    }

    public double WorkerPower()
    {
        return (1 + main.jems[(int)JEM.ID.WorkerPowerGem].Effect())
            * (1 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.taming].calculateCurrentValue())
            * (1 + main.MissionMileStone.JemBonus())
            * WorkerPowerSkillFactor()
            * (1 + Convert.ToInt32(main.S.isDarkRitualPurchase))
            * (1 + ArtifactBonus.WORKER_POWER)
            ;
;    }

    double WorkerPowerSkillFactor()
    {
        return (1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.criticalEye].pas1 + main.skillList.WizardSkills[(int)SkillList.WizardSkill.criticalBolt].pas1 + main.skillList.AngelSkills[(int)SkillList.AngelSkill.purification].pas1);
    }
    string showDRfactor()
    {
        StringBuilder text = new StringBuilder();
        text.Append(initialText);
        text.Append("\n\n\n<size=14>Worker Power Breakdown");
        //text.Append("\n");
        text.Append("<size=12>\n");
        if (main.jems[(int)JEM.ID.WorkerPowerGem].JemLevel > 0)
            text.Append("\n- Gem    <color=green>* " + percent(1 + main.jems[(int)JEM.ID.WorkerPowerGem].Effect()) + "</color>");
        if(main.MissionMileStone.JemBonus() != 0)
            text.Append("\n- Mission Mile Stone    <color=green>* " + percent(1 + main.MissionMileStone.JemBonus()) + "</color>");
        if (main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.taming].level > 0)
            text.Append("\n- Slime Bank   <color=green>* " + percent(1 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.taming].calculateCurrentValue()) + "</color>");
        if (WorkerPowerSkillFactor() > 1)
            text.Append("\n- Skill   <color=green>* " + percent(WorkerPowerSkillFactor()) + "</color>");
        if (ArtifactBonus.WORKER_POWER > 0)
            text.Append("\n- Artifact   <color=green>* " + percent(1 + ArtifactBonus.WORKER_POWER) + "</color>");
        if (main.S.isDarkRitualPurchase)
            text.Append("\n- Epic Store   <color=green>* " + percent(2) + "</color>");
        text.Append("\n<size=14>Total   <color=green>" + percent(WorkerPower()));
        return text.ToString();
    }

    public (double cost, long num) BuyCost()
    {
        double tempCost = 0;
        long tempLevel = main.SR.BuyLevel;

        switch (W_buymode)
        {
            case WorkerBuyMode.mode1:
                return (100 * Math.Pow(1.05f, main.SR.BuyLevel), 1);
            case WorkerBuyMode.modeMax:
                if(main.SR.gold < 100 * Math.Pow(1.05f, main.SR.BuyLevel))
                    return (100 * Math.Pow(1.05f, main.SR.BuyLevel), 1);
                while (tempCost < main.SR.gold )
                {
                    tempCost += 100 * Math.Pow(1.05f, tempLevel);
                    tempLevel++;
                }
                tempCost -= 100 * Math.Pow(1.05f, tempLevel - 1);
                tempLevel--;
                return (tempCost, tempLevel - main.SR.BuyLevel);
            default:
                return (0, 0);
        }
    }
    public (double cost, long num) CapCost()
    {
        double tempCost = 0;
        long tempLevel = main.SR.CapLevel;

        switch (W_buymode)
        {
            case WorkerBuyMode.mode1:
                return (1000 * Mathf.Pow(1.05f,main.SR.CapLevel), 1);
            case WorkerBuyMode.modeMax:
                while(tempCost < main.SR.gold)
                {
                    tempCost += 1000 * Math.Pow(1.05f, tempLevel);
                    tempLevel++;
                }
                return (tempCost, tempLevel - main.SR.CapLevel);
            default:
                return (0, 0);
        }
    }
    public void Buy()
    {
        double tempGold = BuyCost().cost;
        long tempNum = BuyCost().num;
        main.SR.gold -= tempGold;
        workerNum += tempNum;
        main.SR.BuyLevel += tempNum;
    }
    public void Cap()
    {
        main.SR.gold -= CapCost().cost;
        main.SR.CapLevel += CapCost().num;
    }

}
