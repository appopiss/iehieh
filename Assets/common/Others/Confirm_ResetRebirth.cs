using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Confirm_ResetRebirth : BASE
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
        StartCoroutine(doResetRebirthUpgrade());
    }

    //ここにResetRebirthの処理を書く
    public IEnumerator doResetRebirthUpgrade()
    {
        main.S.ResetRebirthUpgradeNum -= 1;


        foreach (A_UPGRADE upgrades in main.Ascends)
        {
            main.S.A_level[upgrades.upgradeId] = 0;
            upgrades.tempLevel = 0;
        }
        foreach (ARTIFACT equipment in main.NewArtifacts)//EQ数を調整
        {
            if (main.craftCtrl.currentEquippedNum() > main.craftCtrl.maxEquippedNum() && equipment.isEquipped)
            {
                equipment.isEquipped = false;
            }
        }
        main.skillSetController.ResetGrobalSkillSlot();
        main.WarP += main.S.consumedWarP;
        main.tempWarP += main.S.consumedWarP;
        main.S.consumedWarP = 0;
        main.WizP += main.S.consumedWizP;
        main.tempWizP += main.S.consumedWizP;
        main.S.consumedWizP = 0;
        main.AngP += main.S.consumedAngP;
        main.tempAngP += main.S.consumedAngP;
        main.S.consumedAngP = 0;
        yield return new WaitForSeconds(0.1f);
        if(gameObject!=null)
        Destroy(gameObject);
    }

    string UpLevel(A_UPGRADE upgrade)
    {
        return "- " + upgrade.Name + " Lv " + main.S.A_level[upgrade.upgradeId] + " -> <color=green>Lv 0</color>\n";
    }
    private void Update()
    {
        //ConfirmButtonText.text = "Instant Rebirth Upgrade";
        upgradeText[0].text = "";
        for (int i = 0; i < 9; i++)
        {
            upgradeText[0].text += UpLevel(main.Ascends[i]);
        }
        upgradeText[1].text = "";
        for (int i = 9; i < 18; i++)
        {
            upgradeText[1].text += UpLevel(main.Ascends[i]);
        }

        if (main.S.ResetRebirthUpgradeNum > 0)
            confirmButton.interactable = true;
        else
            confirmButton.interactable = false;
        ticketString.text = "<<CAUTION>>\nYou will consume 1 Reset Rebirth Upgrade Ticket ( You have " + main.S.ResetRebirthUpgradeNum + " )";
        prestigeString.text = "- Warrior :   " + UsefulMethod.tDigit(main.WarP) + " -><color=green> " + UsefulMethod.tDigit(main.WarP + main.S.consumedWarP) + "</color>\n- Wizard  :   "  + UsefulMethod.tDigit(main.WizP) + " -><color=green> " + UsefulMethod.tDigit(main.WizP + main.S.consumedWizP) + "</color>\n- Angel    :   " + UsefulMethod.tDigit(main.AngP) + " -><color=green> " + UsefulMethod.tDigit(main.AngP + main.S.consumedAngP) + "";

    }

    void ClosePanel()
    {
        Destroy(gameObject);
    }
}
