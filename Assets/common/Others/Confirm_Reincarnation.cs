    using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Confirm_Reincarnation : BASE
{
    public TextMeshProUGUI[] upgradeText;
    public TextMeshProUGUI ConfirmButtonText;
    public TextMeshProUGUI NextCurseText;
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
        StartCoroutine(main.rein.Reincarnate());
    }

    string UpLevelR(R_UPGRADE upgrade)
    {
        if (upgrade.tempLevel == main.S.R_level[(int)upgrade.R_thisId])
        {
            return "- " + upgrade.Name + " Lv " + upgrade.tempLevel + "\n";
        }
        else
        {
            return "- " + upgrade.Name + " Lv " + main.S.R_level[(int)upgrade.R_thisId] + " -> <color=green>Lv " + upgrade.tempLevel + "</color>\n";
        }
    }
    string UpLevelSR(R_UPGRADE upgrade)
    {
        if (upgrade.tempLevel == main.S.SR_level[(int)upgrade.SR_thisId])
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
        ConfirmButtonText.text = "OK, Reincarnate!";
        upgradeText[0].text = "";
        for (int i = 0; i < 3; i++)
        {
            upgradeText[0].text += UpLevelR(main.R_upgrades[i]);
        }
        upgradeText[1].text = "";
        for (int i = 3; i < 5; i++)
        {
            upgradeText[1].text += UpLevelR(main.R_upgrades[i]);
        }
        upgradeText[2].text = "";
        for (int i = 0; i < 9; i++)
        {
            upgradeText[2].text += UpLevelSR(main.SR_upgrades[i]);
        }
        upgradeText[3].text = "";
        for (int i = 9; i < 18; i++)
        {
            upgradeText[3].text += UpLevelSR(main.SR_upgrades[i]);
        }


    }

    void ClosePanel()
    {
        Destroy(gameObject);
    }
}
