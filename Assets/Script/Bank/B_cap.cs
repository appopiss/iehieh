using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class B_cap : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.BankCap;
        initValue = 10000;
        plusValue = 10000;
        IncrementReputation = 5;
        bottom = 1;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    public override double calculateCurrentCost(int level)
    {
        return main.bankCtrl.BankCap() * 0.75 * (1 - costFactor);
    }
    public override void AdditionalEffect()
    {
        main.S.slimeReputation += 5;
        //RPmanager.GetPointFromBank();
    }

    public override double calculateCurrentValue()
    {

        return (initValue + level * plusValue + (double)level * level * 500d) * (1 + main.jems[(int)JEM.ID.BankCap].Effect());
    }

    public override double calculateCurrentValue(int level)
    {

        return (initValue + level * plusValue + (double)level * level * 500d) * (1 + main.jems[(int)JEM.ID.BankCap].Effect());
    }


    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;

        BankLocal.B_cap(ref Name, ref effectExplain, ref explain);
        currentValue = tDigit(calculateCurrentValue());
        nextValue = tDigit(calculateNextValue());
    }
}
