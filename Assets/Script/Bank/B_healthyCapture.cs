using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_healthyCapture : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.healthyCapture;
        RequiredReputation = 300;
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
        return Math.Round(100000 * (level+1) * Math.Pow(1.25, level)) * (1 - costFactor);
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
        BankLocal.B_healthy(ref Name, ref effectExplain, ref explain);

        currentValue = "Chance + " + tDigit(Math.Min(level*2,100)) + "%";
        nextValue = "Chance + " + tDigit(Math.Min((level+1)*2,100)) + "%";
    }
}
