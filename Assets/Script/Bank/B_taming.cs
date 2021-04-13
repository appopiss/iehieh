using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using System;

public class B_taming : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        thisId = UpgradeId.taming;
        RequiredReputation = 3000;
        IncrementReputation = -1000;
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
        return Math.Pow(1.1, level) * (1+level) * 50000 + 30000 * Math.Pow(level, 3) * (1 - costFactor);
    }

    public long TotalCapturedNum()
    {
        long temp = 0;
        for (int i = 0; i < main.S.totalEnemiesCaptured.Length; i++)
        {
            temp += main.S.totalEnemiesCaptured[i];
        }
        return temp;
    }

    public override double calculateCurrentValue()
    {
        return level * (TotalCapturedNum() / 100) * 0.01;
    }
    public override double calculateCurrentValue(int level)
    {
        return level * (TotalCapturedNum() / 100) * 0.01;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;

        Name = "Yunanjian Monster Taming";
        effectExplain = "Increase the effectiveness of dark ritual by x% per total 100 Captured Enemies. (Current Total Captured Enemy : " + TotalCapturedNum() + ")";
        currentValue = percent(calculateCurrentValue()) + " bonus to dark ritual";
        nextValue = percent(calculateNextValue()) + " bonus to dark ritual";
        explain = "On the steps of the bank you see a strange looking man who looks like he's spent the last fifty years of his life on safari. As you approach," +
            " you see cages full of various monsters. \"Ahh, excellent, you look like just the kind of person for whom I stand on these wretched steps waiting. My " +
            "name is Von Peldt, and I am a world renowned hunter.Having spent my life in the wilds of Yunanji, I have learned to tame even the fiercest of monsters. I" +
            " can teach you my life's work, but my knowledge isn't free, nor does it have any appeal to the monsters who run this infernal bank. Would you do me the honor" +
            " of letting me teach you how to put your captured monstrosities to good use?\" You're both terrified and intrigued, but you know you will upset the "+
            "bank if you keep talking to him.";
    }

}
