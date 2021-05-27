using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using Sirenix.Serialization;
using static UsefulMethod;

public interface IArtifactTransaction
{
    (ITransaction transaction, IText text) GetTransactionInfo(ILevel level);
}

public class NormalArtifactTransaction : IArtifactTransaction
{
    private readonly ArtifactMaterialTransaction normalTransaction, awakeningTransaction;
    private readonly long awakePoint;
    public NormalArtifactTransaction(ArtifactMaterialTransaction normalTransaction, ArtifactMaterialTransaction awakeningTransaction, long awakePoint)
    {
        this.normalTransaction = normalTransaction;
        this.awakeningTransaction = awakeningTransaction;
        this.awakePoint = awakePoint;
    }
    public (ITransaction transaction, IText text) GetTransactionInfo(ILevel level)
    {
        if (level.level <= awakePoint)
        {
            return (normalTransaction, normalTransaction);
        }
        else
        {
            return (awakeningTransaction, awakeningTransaction);
        }
    }
}

[Serializable]
public class ArtifactMaterialSingleTransaction : ITransaction, IText
{
    //コストの処理を委譲する。
    public readonly ICost cost;
    public readonly ArtifactMaterial material;
    Transaction transaction;

    public bool CanBuy()
    {
        if (transaction == null) transaction = new Transaction(material, cost);
        return transaction.CanBuy();
    }
    public void Pay()
    {
        if (transaction == null) transaction = new Transaction(material, cost);
        transaction.Pay();
    }
    public string Text()
    {
        return $"- {material.Text()}   {tDigit(material.Number)} / {cost.Cost}";
    }
    public ArtifactMaterialSingleTransaction(ArtifactMaterial.ID id, ICost cost)
    {
        ArtifactMaterial material = new ArtifactMaterial((int)id);
        this.material = material;
        this.cost = cost;
    }
}

//トランザクションの配列を受け取り、まとめて決済を行います。
[Serializable]
public class ArtifactMaterialTransaction : ITransaction, IText
{
    public readonly ArtifactMaterialSingleTransaction[] transactions;
    MultipleTransaction multipleTransaction;
    public bool CanBuy()
    {
        if (multipleTransaction == null) multipleTransaction = new MultipleTransaction(transactions);
        return multipleTransaction.CanBuy();
    }

    public void Pay()
    {
        if (multipleTransaction == null) multipleTransaction = new MultipleTransaction(transactions);
        multipleTransaction.Pay();
    }

    public string Text()
    {
        string text = "";
        foreach (var item in transactions)
        {
            text += optStr + item.Text() + "\n";
        }
        return text;
    }
    public ArtifactMaterialTransaction(params ArtifactMaterialSingleTransaction[] transactions)
    {
        this.transactions = transactions;
    }
}

[Serializable]
public class TimeBasedLevel : ILevel
{
    public long level { get => _levelCap; set => _levelCap = value; }
    [OdinSerialize] private long _levelCap;
    public long maxLevelCap;
    public TimeBasedLevel(long maxLevelCap)
    {
        this.level = 1;
        this.maxLevelCap = maxLevelCap;
    }
}
[Serializable]
public class TimeBasedLevelUp
{
    [OdinSerialize] private ILevel level;
    public TimeBasedLevel timeLevel;

    public Func<(ITransaction transaction, IText text)> transactionsInfo;
    public Func<float> requiredTimeSec;
    public float currentTimesec;

    public TimeBasedLevelUp
    (ILevel artifactLevel, TimeBasedLevel timeLevel, Func<(ITransaction transaction, IText text)> transactionsInfo, Func<float> requiredTimeSec)
    {
        this.level = artifactLevel;
        this.timeLevel = timeLevel;
        this.transactionsInfo = transactionsInfo == null ? () => (new NullTransaction(), new NullText()) : transactionsInfo;
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
            transactionsInfo().transaction.Pay();
            timeLevel.level += incrementLevelCap;
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
            level.level++;
            currentTimesec = 0;
        }
    }
    bool CanIncreaseLevelCap()
    {
        return transactionsInfo().transaction.CanBuy() && timeLevel.level < timeLevel.maxLevelCap;
    }
    bool CanLevelUp()
    {
        return level.level < timeLevel.level;
    }
}
