using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Confirm_Rebirth : BASE
{
    public TextMeshProUGUI[] upgradeText;
    public TextMeshProUGUI ConfirmButtonText;
    public Button closeButton, confirmButton;

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
        StartCoroutine(main.jobChange.doAscension());
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
        ConfirmButtonText.text = "OK, rebirth as " + Job();
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


    }
    string Job()
    {
        if (main.jobChange.selectedJob == ALLY.Job.Warrior)
        {
            return "Warrior";
        }
        else if(main.jobChange.selectedJob == ALLY.Job.Wizard)
        {
            return "Wizard";
        }
        else if(main.jobChange.selectedJob == ALLY.Job.Angel)
        {
            return "Angel";
        }
        else
        {
            return ""+main.ally.job;
        }

    }

    void ClosePanel()
    {
        Destroy(gameObject);
    }
}
