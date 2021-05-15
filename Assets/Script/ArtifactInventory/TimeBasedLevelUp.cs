using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;

public class TimeBasedLevelUp
{
    private Artifact artifact;
    private Func<ITransaction> transaction;
    private Func<float> requiredTimeSec;
    private float currentTimesec;

    public TimeBasedLevelUp(Artifact artifact, Func<ITransaction> transaction, Func<float> requiredTimeSec)
    {
        this.artifact = artifact;
        this.transaction = transaction;
        this.requiredTimeSec = requiredTimeSec;
    }
    //実時間１秒間あたり１回呼ぶ
    public void UpdatePerSec()
    {
        IncreaseCurrentTime(1);
    }
    //素材投入＆レベルキャップを増加させるときはこの関数を呼ぶ
    public void IncreaseLevelCap(long incrementLevelCap)
    {
        if (CanIncreaseLevelCap())
        {
            transaction().Pay();
            artifact.maxLevelCap += incrementLevelCap;
        }
    }
    //UI用_現在の進行度（%）
    public float ProgressPercent()
    {
        return currentTimesec / requiredTimeSec();
    }


    void IncreaseCurrentTime(float timesec)
    {
        if (!CanLevelUp()) return;
        currentTimesec += timesec;
        if (currentTimesec >= requiredTimeSec())
        {
            artifact.level++;
            currentTimesec = 0;
        }
    }
    bool CanIncreaseLevelCap()
    {
        return transaction().CanBuy() && artifact.levelCap < artifact.maxLevelCap;
    }
    bool CanLevelUp()
    {
        return artifact.level < artifact.levelCap;
    }
}
