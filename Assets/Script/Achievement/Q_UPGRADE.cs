using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using TMPro;
using static UsefulMethod;

public class Q_UPGRADE : BASE
{
    //LevelはSaveするよ
    //public int level { get => main.S.A_level[upgradeId]; set => main.S.A_level[upgradeId] = value; }
    //[NonSerialized]
    public int level { get => main.S.Q_upgradeLevel[(int)upgradeName]; set => main.S.Q_upgradeLevel[(int)upgradeName] = value; }
    QUpgradePlain_PopText thisText;
    public Func<long> CurrentCost;
    public Action UpgradeAction;
    //public TextMeshProUGUI NameText;
    public enum UpgradeName
    {
        DamageBonus = 0,
        EquipmentSlot = 1,
        GoldCap = 2,
        RebirthPoint = 3
    }
    public UpgradeName upgradeName;

    private void Awake()
    {
        StartBASE();
        switch (upgradeName)
        {
            case UpgradeName.DamageBonus:
                CurrentCost = () => (level+1) * 5;
                UpgradeAction = () => { };
                break;
            case UpgradeName.EquipmentSlot:
                CurrentCost = () =>
                {
                    if (level == 0)
                        return 1;
                    else
                        return level * 10;
                };
                UpgradeAction = () => { };
                break;
            case UpgradeName.GoldCap:
                CurrentCost = () => 3;
                UpgradeAction = () => { };
                break;
            case UpgradeName.RebirthPoint:
                CurrentCost = () => 7;
                UpgradeAction = () => { };
                break;
        }
        thisText = gameObject.GetComponent<QUpgradePlain_PopText>();
        thisText.AdjustVector3 = new Vector3(100, 30); 
    }

    public void Start()
    {
        //NameText = gameObject.GetComponent<TextMeshProUGUI>();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    public double calculateCurrentCost()
    {
        return CurrentCost();
    }
    public void calculate()
    {
        main.S.QuestPoint -= (long)calculateCurrentCost();
        level++;
    }


    //実際に値を使うときはTempじゃないほうを　使う．
    public double calculateCurrentValue()
    {
        return 0;
    }

    public double calculateNextValue()
    {
        level++;
        double ans = calculateCurrentValue();
        level--;
        return ans;
    }
    public double calculateNextSub()
    {
        return calculateNextValue() - calculateCurrentValue();
    }

    public void Update()
    {
        if (calculateCurrentCost() > main.S.QuestPoint)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        thisText.text = windowText();

    }

    public string windowText()
    {
        string text = "";
        switch (upgradeName)
        {
            case UpgradeName.DamageBonus:
                text += "<size=16>Damage Bonus\n\n<size=14>";
                text += "Effect : + " + tDigit(level) + "% Damage Bonus\n\n";
                text += "Cost : " + tDigit(CurrentCost()) + " Quest Points\n\n";
                text += "You bought this upgrade " + tDigit(level) + " times!\n\n ";
                break;
            case UpgradeName.EquipmentSlot:
                text += "<size=16>Equipment Slot\n\n<size=14>";
                text += "Effect : " + tDigit(level) + " extra Equipment Slot\n\n";
                text += "Cost : " + tDigit(CurrentCost()) + " Quest Point\n\n";
                text += "You bought this upgrade " + tDigit(level) + " times!\n\n ";
                break;
            case UpgradeName.GoldCap:
                text += "<size=16>Gold Cap\n\n<size=14>";
                text += "Effect : + " + percent(level * 0.1) + "  Gold Cap Bonus!\n\n";
                text += "Cost : " + tDigit(CurrentCost()) + " Quest Point\n\n";
                text += "You bought this upgrade " + tDigit(level) + " times!\n\n ";
                break;
            case UpgradeName.RebirthPoint:
                text += "<size=16>Rebirth Point Bonus\n\n<size=14>";
                text += "Effect : + " + percent(level * 0.05) + "  rebirth Bonus point!\n\n";
                text += "Cost : " + tDigit(CurrentCost()) + " Quest Point\n\n";
                text += "You bought this upgrade " + tDigit(level) + " times!\n\n ";
                break;
        }
        return text;
    }

    public double fibonacci(int n)
    {
        double factor = 1 / Sqrt(5);
        double phi = (1 + Sqrt(5)) / 2;
        double phi2 = (1 - Sqrt(5)) / 2;

        return factor * (Pow(phi, n) - Pow(phi2, n));
    }

    public string percent(double d)
    {
        return tDigit((d) * 100, 2) + "%";
    }
}
