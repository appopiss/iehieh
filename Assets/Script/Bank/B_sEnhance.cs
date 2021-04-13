using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_sEnhance : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.sEnhance;
        IncrementReputation = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 200*Math.Pow(5,MAX(FLOOR([UpgradeName.Level]-1,10)/10+1,1))
    public override double calculateCurrentCost(int level)
    {
        return 200 * Math.Pow(5, Math.Max((level - 1) / 10 + 1, 1)) * (1 - costFactor);
    }

    //0.25*Math.Pow(2,MAX(FLOOR([UpgradeName.Level]-1,10)/10+1,1)) 
    public override double calculateCurrentValue()
    {
        return 0.5 * Math.Pow(2, Math.Max((level - 1) / 10 + 1, 1));
    }
    public override double calculateCurrentValue(int level)
    {
        return 0.5 * Math.Pow(2, Math.Max((level - 1) / 10 + 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_enhanceS(ref Name, ref effectExplain, ref explain);
        currentValue = percent(TotalEffect());
        nextValue = percent(calculateNextValueTotal());
    }
}
