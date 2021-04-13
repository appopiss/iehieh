using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class Confirm_InstantSpiritUpgrade : BASE
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
    long SpiritEssenceNum;
    //ここにInstantRebirthの処理を書く
    public IEnumerator doInstantRebirthUpgrade()
    {
        StopCoroutine(main.saveCtrl.save);
        main.S.InstantReincarnationNum -= 1;

        SpiritEssenceNum = main.RPmanager.SpiritEssence();
        main.S.SRPinstantConsumed += SpiritEssenceNum - main.tempSRP;

        foreach (R_UPGRADE upgrades in main.SR_upgrades)
        {
            main.S.SR_level[(int)upgrades.SR_thisId] = upgrades.tempLevel;
            //upgrades.tempLevel = main.S.A_level[upgrades.upgradeId];
        }
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(0.3f);
        if(gameObject!=null)
            Destroy(gameObject);
        SceneManager.LoadScene("main");
    }

    string UpLevel(R_UPGRADE upgrade)
    {
        if(upgrade.tempLevel == main.S.SR_level[(int)upgrade.SR_thisId])
        {
            return "- " + upgrade.Name + " Lv " + upgrade.tempLevel + "\n";
        }
        else
        {
            return "- " + upgrade.Name + " Lv " + main.S.SR_level[(int)upgrade.SR_thisId] + " -> <color=green>Lv " + upgrade.tempLevel + "</color>\n";
        }
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
        for (int i = 9; i < 18; i++)
        {
            upgradeText[1].text += UpLevel(main.SR_upgrades[i]);
        }

        if (main.S.InstantReincarnationNum > 0)
            confirmButton.interactable = true;
        else
            confirmButton.interactable = false;
        ticketString.text = "<<CAUTION>>\nYou will consume 1 Instant Reincarnation Upgrade Ticket ( You have " + main.S.InstantReincarnationNum + " )";

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
