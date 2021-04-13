using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class B_interest : B_Upgrade
{
    float leftTime = 0f;
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.BankInterest;
        initValue = 0;
        initCost = 1000;
        bottom = 1.25;
        plusValue = 0.0005;
        IncrementReputation = 5;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
        StartCoroutine(GainInterest());
    }


    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_interest(ref Name, ref effectExplain, ref explain);

        currentValue = percent(calculateCurrentValue()) + " / 60 s";
        nextValue = percent(calculateNextValue()) + " / 60 s\n Next Interest Gain in "+ tDigit(60-leftTime) + " seconds";
    }

    public override void AdditionalEffect()
    {
        main.S.slimeReputation += 5;
    }

    public IEnumerator GainInterest()
    {
        while (true)
        {
            //先に６０秒待つ
            for (int i = 0; i < 60; i++)
            {
                yield return new WaitForSecondsRealtime(1.0f / Mathf.Max(Time.timeScale, 1f));
                leftTime += 1.0f;
            }
            leftTime = 0f;
            yield return new WaitUntil(() => level > 0);
            main.S.SlimeCoin += main.S.SlimeCoin * calculateCurrentValue();
            if (main.S.SlimeCoin > main.bankCtrl.BankCap())
                main.S.SlimeCoin = main.bankCtrl.BankCap();
            /*
            for(int i = 0; i < 60; i++)
            {
                yield return new WaitForSecondsRealtime(1.0f/Mathf.Max(Time.timeScale,1f));
                leftTime += 1.0f;
            }
            */
        }
    }
}
