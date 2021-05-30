using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Confirm_ResetReincarnation : BASE
{
    public TextMeshProUGUI[] upgradeText;
    public TextMeshProUGUI ConfirmButtonText;
    public Button closeButton, confirmButton;
    public TextMeshProUGUI ticketString;
    public TextMeshProUGUI prestigeString;

    private void Awake()
    {
        StartBASE();
        closeButton.onClick.AddListener(ClosePanel);
        confirmButton.onClick.AddListener(doReset);
    }
    private void Start()
    {
    }

    public void doReset()
    {
        confirmButton.interactable = false;
        StartCoroutine(doResetReincarnationUpgrade());
    }

    public IEnumerator doResetReincarnationUpgrade()
    {
        main.S.ResetReincarnationUpgradeNum -= 1;

        foreach (R_UPGRADE upgrades in main.SR_upgrades)
        {
            main.S.SR_level[(int)upgrades.SR_thisId] = 0;
            upgrades.tempLevel = 0;
        }
        foreach (ARTIFACT equipment in main.NewArtifacts)//EQ数を調整
        {
            if (main.craftCtrl.currentEquippedNum() > main.craftCtrl.maxEquippedNum() && equipment.isEquipped)
            {
                equipment.isEquipped = false;
            }
        }
        main.S.SRPconsumed = 0;
        main.S.SRPinstantConsumed = 0;
        main.rein.ResetAssignment();
        yield return new WaitForSeconds(0.1f);
        if(gameObject!=null)
        Destroy(gameObject);
    }
    public long afterReset()
    {
        return main.RPmanager.SpiritEssence() + main.S.SRPconsumed + main.S.SRPinstantConsumed;
    }
    string UpLevel(R_UPGRADE upgrade)
    {
        return "- " + upgrade.Name + " Lv " + main.S.SR_level[(int)upgrade.SR_thisId] + " -> <color=green>Lv 0</color>\n";
    }
    private void Update()
    {
        //ConfirmButtonText.text = "Instant Rebirth Upgrade";
        upgradeText[0].text = "";
        for (int i = 0; i < 9; i++)
        {
            upgradeText[0].text += UpLevel(main.SR_upgrades[i]);
        }
        upgradeText[1].text = "";
        for (int i = 9; i < 19; i++)
        {
            upgradeText[1].text += UpLevel(main.SR_upgrades[i]);
        }

        if (main.S.ResetReincarnationUpgradeNum > 0)
            confirmButton.interactable = true;
        else
            confirmButton.interactable = false;
        ticketString.text = "<<CAUTION>>\nYou will consume 1 Reset Spirit Upgrade Ticket ( You have " + main.S.ResetReincarnationUpgradeNum + " )";
        prestigeString.text = UsefulMethod.tDigit(main.RPmanager.SpiritEssence()) + " -><color=green> " + UsefulMethod.tDigit(afterReset());

    }

    void ClosePanel()
    {
        Destroy(gameObject);
    }
}
