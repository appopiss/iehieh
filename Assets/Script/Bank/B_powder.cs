using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_powder : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.powder;
        RequiredReputation = 5000;
        IncrementReputation = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 100000*Math.Pow(3,SBank.MonsterCounterLevel)
    //ROUNDUP(150000*POWER(1.1,MAX(FLOOR([UpgradeLevel]-1,10)/10+1,1)),-4)
    public override double calculateCurrentCost(int level)
    {
        return (300000d * Math.Pow(1.4, level) + 200000d * Math.Pow(level, 1.1)) * (1d - costFactor);
    }


    public override double calculateCurrentValue()
    {
        return 250 * level;
    }
    public override double calculateCurrentValue(int level)
    {
        return 250 * level;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_powder(ref Name, ref effectExplain, ref explain);

        currentValue = "Nitro Cap + " + tDigit(calculateCurrentValue());
        nextValue = "Nitro Cap + " + tDigit(calculateNextValue());

    }

}
