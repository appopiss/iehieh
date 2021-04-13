using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_drug : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.drug;
        RequiredReputation = 4000;
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
        return 1000000 * (level + 1) * (1 - costFactor);
    }


    public override double calculateCurrentValue()
    {
        return 1;
    }
    public override double calculateCurrentValue(int level)
    {
        return 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        Name = "New Drug Research";
        effectExplain = "Unleash a new potion you can make in Alchemy for each upgrade";
        currentValue = tDigit(calculateCurrentValue()) + " new potions!";
        nextValue = tDigit(calculateNextValueTotal()) + " new potions!";
        explain = "Place Holder";

    }

}
