using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Confirm_InstantRebirthUpgrade : BASE
{
    public TextMeshProUGUI[] upgradeText;
    public TextMeshProUGUI ConfirmButtonText;
    public Button closeButton, confirmButton;
    public TextMeshProUGUI ticketString;

    private void Awake()
    {
        StartBASE();
        closeButton.onClick.AddListener(ClosePanel);
        confirmButton.onClick.AddListener(doAscend);
    }
    private void Start()
    {
    }

    public void doAscend()
    {
        confirmButton.interactable = false;
        StartCoroutine(doInstantRebirthUpgrade());
    }

    //ここにInstantRebirthの処理を書く
    public IEnumerator doInstantRebirthUpgrade()
    {
        main.S.InstantRebirthNum -= 1;
        //StopCoroutine(main.saveCtrl.save);
        //isAscend = false;
        //main.S.AscendNum++;
        for (int i = 0; i < main.jobChange.unleashNum(); i++)
        {
            main.skillSetController.UnleashGrobalSkillSlot();
        }
        foreach (A_UPGRADE upgrades in main.Ascends)
        {
            main.S.A_level[upgrades.upgradeId] = upgrades.tempLevel;
            //upgrades.tempLevel = main.S.A_level[upgrades.upgradeId];
        }
        main.S.consumedWarP += (main.WarP - main.tempWarP);
        main.WarP = main.tempWarP;
        main.S.consumedWizP += (main.WizP - main.tempWizP);
        main.WizP = main.tempWizP;
        main.S.consumedAngP += (main.AngP - main.tempAngP);
        main.AngP = main.tempAngP;
        main.SR.JP_level = 0;
        main.SR.JP_craft = 0;
        main.SR.JP_enemy = 0;

        yield return new WaitForSeconds(0.1f);
        if(gameObject!=null)
        Destroy(gameObject);
    }

    string UpLevel(A_UPGRADE upgrade)
    {
        if(upgrade.tempLevel == main.S.A_level[upgrade.upgradeId])
        {
            return "- " + upgrade.Name + " Lv " + upgrade.tempLevel + "\n";
        }
        else
        {
            return "- " + upgrade.Name + " Lv " + main.S.A_level[upgrade.upgradeId] + " -> <color=green>Lv " + upgrade.tempLevel + "</color>\n";
        }
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

        if (main.S.InstantRebirthNum > 0)
            confirmButton.interactable = true;
        else
            confirmButton.interactable = false;
        ticketString.text = "<<CAUTION>>\nYou will consume 1 Instant Rebirth Upgrade Ticket ( You have " + main.S.InstantRebirthNum + " )";

    }
    //string Job()
    //{
    //    if (main.jobChange.selectedJob == ALLY.Job.Warrior)
    //    {
    //        return "Warrior";
    //    }
    //    else if(main.jobChange.selectedJob == ALLY.Job.Wizard)
    //    {
    //        return "Wizard";
    //    }
    //    else if(main.jobChange.selectedJob == ALLY.Job.Angel)
    //    {
    //        return "Angel";
    //    }
    //    else
    //    {
    //        return ""+main.ally.job;
    //    }

    //}

    void ClosePanel()
    {
        Destroy(gameObject);
    }
}
