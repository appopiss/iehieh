using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_nitro : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.nitro;
        RequiredReputation = 2000;
        IncrementReputation = 20;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade(); 
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
        StartCoroutine(NitroProduce());
    }

    //Cost: 100000*Math.Pow(3,SBank.MonsterCounterLevel)
    //ROUNDUP(150000*POWER(1.1,MAX(FLOOR([UpgradeLevel]-1,10)/10+1,1)),-4)
    public override double calculateCurrentCost(int level)
    {
        return Math.Round(150000 * Math.Pow(1.25, Math.Max((level - 1) / 10, 1)), 4) * (1 - costFactor);
    }

    public override double calculateCurrentValue()
    {
        if(level<100)
            return (double)level*2;
        else if(level<200)
            return (double)100*2 + (double)(level-100);
        else if(level<300)
            return (double)100*2 + (double)(100) + (double)(level-200)/2;
        else
            return (double)100 * 2 + (double)(100) + (double)(300 - 200) / 2 + (double)(level - 300) / 4;
    }
    public override double calculateCurrentValue(int level)
    {
        if (level < 100)
            return (double)level * 2;
        else if (level < 200)
            return (double)100 * 2 + (double)(level - 100);
        else if (level < 300)
            return (double)100 * 2 + (double)(100) + (double)(level - 200) / 2;
        else
            return (double)100 * 2 + (double)(100) + (double)(300 - 200) / 2 + (double)(level - 300) / 4;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        BankLocal.B_nitro(ref Name, ref effectExplain, ref explain);

        currentValue = "Produce " + tDigit(calculateCurrentValue()) + " nitro per hour";
        nextValue = "Produce " + tDigit(calculateNextValue()) + " nitro per hour";
    }

    public IEnumerator NitroProduce()
    {
        while (true)
        {
            yield return new WaitUntil(() => level > 0);
            main.S.CurrentNitro += (float)(calculateCurrentValue() / 60f) * (float)(1 + ArtifactBonus.NITRO_GAIN);
            yield return new WaitForSecondsRealtime(60.0f);
        }
    }
}
