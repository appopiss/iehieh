using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_explore : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.capacity;
        RequiredReputation = 10000;
        IncrementReputation = -5000;
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
        return 3000000 * Math.Pow(1.25, level) * (1 - costFactor);
    }

    public override double calculateCurrentValue()
    {
        return 100 * level;
    }
    public override double calculateCurrentValue(int level)
    {
        return 100 * level;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_explore(ref Name, ref effectExplain, ref explain);
        currentValue = "+ " + tDigit(calculateCurrentValue());
        nextValue = "+ " + tDigit(calculateNextValue());
    }

}
