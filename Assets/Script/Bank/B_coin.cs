using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_coin : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.coin;
        RequiredReputation = 1500;
        IncrementReputation = -1400;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 250000*Math.Pow(4,[SBank.LedgerLevel])
    public override double calculateCurrentCost(int level)
    {
        return 250000 * Math.Pow(4, level) * (1 - costFactor);
    }

    public override double calculateCurrentValue()
    {
        return 1.0000001;
    }
    public override double calculateCurrentValue(int level)
    {
        return 1.0000001;
    }

    public override void AdditionalEffect()
    {
        main.S.slimeReputation -= 1400;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_slimecoin(ref Name, ref effectExplain, ref explain);

        currentValue = "Additional Slime Coin + " + tDigit(TotalEffect());
        nextValue = "Additional Slime Coin + " + tDigit(calculateNextValueTotal());
    }
}
