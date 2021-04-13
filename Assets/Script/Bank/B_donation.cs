using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_donation : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.Donate;
        IncrementReputation = 50;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 10000 + (1000 * [BankCapUpgrade.Level]) 
    public override double calculateCurrentCost(int level)
    {
        return (10000 + (1000 * main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.BankCap].level)) * (1 - costFactor);
    }


    public override void checkButton()
    {
        if (main.S.slimeReputation >= reputationCap())
        {
            main.S.slimeReputation = reputationCap();
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            if (main.SR.B_buyMode == UPGRADE.buyMode.modeMax)
            {
                if (calculateMaxSumCost(level).x == 0 || calculateMaxSumCost(level).z == 0 || main.S.slimeReputation < RequiredReputation || main.S.slimeReputation >= reputationCap())
                {
                    thisButton.interactable = false;
                }
                else
                {
                    thisButton.interactable = true;
                }
            }
            else
            {

                if (canBuy())
                {
                    thisButton.interactable = true;
                }
                else
                {
                    thisButton.interactable = false;
                }
            }
        }
        //
        C_slimeCoin = "Slime Coin : " + tDigit(calculateCurrentCost(level));
    }
    public override bool canBuy()
    {
        if (main.SR.buyMode == UPGRADE.buyMode.modeMax)
        {
            return !(calculateMaxSumCost(level).x == 0 || calculateMaxSumCost(level).z == 0 || main.S.slimeReputation < RequiredReputation || main.S.slimeReputation >= reputationCap());
        }
        else
        {
            return calcurateCurrentCost() <= main.S.SlimeCoin && main.S.slimeReputation >= RequiredReputation && main.S.slimeReputation < reputationCap();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_donate(ref Name, ref effectExplain, ref explain);

        currentValue = "Get " + ReputationPerUpgrade + " reputation";
        nextValue = "Get " + ReputationPerUpgrade + " reputation";
    }
}
