using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class B_Rate : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.BankRate;
        initValue = 0.1;
        initCost = 500;
        bottom = 1.45;
        plusValue = 0.0125;
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
        BankLocal.B_rate(ref Name, ref effectExplain, ref explain);

        currentValue = percent(calculateCurrentValue());
        nextValue = percent(calculateNextValue());
    }
}
