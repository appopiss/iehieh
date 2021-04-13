using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class INFO_bank : MonoBehaviour {
    public B_Upgrade this[B_Upgrade.UpgradeId id]
    {
        get => main.bankCtrl.BankUpgrades[(int)id];
    }
    void aaa()
    {
        Input.GetKeyDown(KeyCode.LeftShift);
    }
}
