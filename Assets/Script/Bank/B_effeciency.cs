using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class B_effeciency : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.BankEfficiency;
        initValue = 1.0f/500;
        initCost = 100;
        bottom = 1.15;
        plusValue = 0.0001;
        IncrementReputation = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
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
        BankLocal.B_efficiency(ref Name, ref effectExplain, ref explain);

        currentValue = "1 Slime Coin / " + tDigit(1.0f / calculateCurrentValue()) + " Gold";
        nextValue = "1 Slime Coin / " + tDigit(1.0f / calculateNextValue())+ " Gold";
    }
}
