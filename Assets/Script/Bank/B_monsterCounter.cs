using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_monsterCounter : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.counter;
        RequiredReputation = 750;
        IncrementReputation = -500;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 100000*Math.Pow(3,SBank.MonsterCounterLevel)
    public override double calculateCurrentCost(int level)
    {
        return 100000 * Math.Pow(3, level) * (1 - costFactor);
    }

    public override double calculateCurrentValue()
    {
        return 1.00000001;
    }
    public override double calculateCurrentValue(int level)
    {
        return 1.00000001;
    }

    public override void AdditionalEffect()
    {
        main.S.slimeReputation -= 500;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_counter(ref Name, ref effectExplain, ref explain);

        currentValue = "Extra monster killed count + " + tDigit(TotalEffect());
        nextValue = "Extra monster killed count + " + tDigit(calculateNextValueTotal());
    }
}
