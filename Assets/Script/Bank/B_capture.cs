using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_capture : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.capture;
        RequiredReputation = 500;
        IncrementReputation = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //ROUND(10000*Math.Pow(1.2*[EnhancedCapture.Level]),-1)
    public override double calculateCurrentCost(int level)
    {
        return Math.Round(10000 * Math.Pow(1.255 ,level)) * (1 - costFactor);
    }

    public override void AdditionalEffect()
    {
        main.S.slimeReputation += 5;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_capture(ref Name, ref effectExplain, ref explain);
        currentValue = "Chance + " + tDigit(Math.Min(level, 100)) + "%";//, Cap + " + tDigit(level);// + ", Time " + tDigit(10 * 60 * (5000/(50+level)) * 0.01) + " s";
        nextValue = "Chance + " + tDigit(Math.Min((level + 1), 100)) + "%";//, Cap + " + tDigit((level + 1));// + ", Time " + tDigit(10 * 60 * (5000/(50+(level+1))) * 0.01) + " s";
    }
}
