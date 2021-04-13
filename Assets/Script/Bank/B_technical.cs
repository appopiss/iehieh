using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_technical : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.S_technical;
        RequiredReputation = 100;
        IncrementReputation = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    //Cost: 2500*Math.Pow(4,MAX(FLOOR([UpgradeName.Level]-1,5)/5+1,1))
    public override double calculateCurrentCost(int level)
    {
        return 2500 * Math.Pow(4, Math.Max((level - 1) / 5 + 1, 1)) * (1 - costFactor);
    }

    public override double calculateCurrentValue()
    {
        return Mathf.Round((long)(25 * Math.Pow(1.25, Math.Max((level - 1) / 5 + 1, 1)))-1);
    }
    public override double calculateCurrentValue(int level)
    {
        return Mathf.Round((long)(25 * Math.Pow(1.25, Math.Max((level - 1) / 5 + 1, 1)))-1);
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
        BankLocal.B_tech(ref Name, ref effectExplain, ref explain);

        currentValue = "Base ATK + " + tDigit(TotalEffect());
        nextValue = "Base ATK + " + tDigit(calculateNextValueTotal());
    }
}
