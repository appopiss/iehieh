using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_potion : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.potion;
        RequiredReputation = 200;
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
        return Math.Round(5000 * Math.Pow(1.525, level)) * (1 - costFactor);

    }

    public override double calculateCurrentValue()
    {
        return level * 0.01;
    }
    public override double calculateCurrentValue(int level)
    {
        return level * 0.01;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;

        BankLocal.B_potion(ref Name, ref effectExplain, ref explain);

        currentValue = "Purifying + " + percent(calculateCurrentValue()) + " with every expansion";
        nextValue = "Purifying + " + percent(calculateNextValue()) + " with every expansion";
    }

}
