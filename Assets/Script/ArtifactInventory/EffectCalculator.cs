using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;

//Inventoryのアイテムを受け取り、エフェクトを計算する！
//一回inventoryでやるが、後々抽象化したい
public class EffectCalculator : IText
{
    private IdleLibrary.Inventory.Inventory inventory;
    public EffectCalculator(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    private Dictionary<Enum, double> calculateDic = new Dictionary<Enum, double>();
    EffectPrototype protoEffects = new EffectPrototype();
    public void UpdateValue()
    {
        calculateDic.Clear();
        foreach (var item in inventory.GetItems())
        {
            if(item is Artifact)
            {
                var artifact = item as Artifact;
                foreach (var effects in artifact.effects)
                {
                    //IStatsBreakdownなら
                    if(effects is IStatsBreakdown)
                    {
                        Debug.Log(effects.effectType == null);
                        var stats = effects as IStatsBreakdown;
                        if (calculateDic.ContainsKey(effects.effectType))
                        {
                            calculateDic[effects.effectType] += stats.Value();
                        }
                        else
                        {
                            calculateDic.Add(effects.effectType, stats.Value());
                        }
                    }
                }
            }
        }

        //テキストの更新
        string text = "";

        foreach (var effects in protoEffects.GetEffects())
        {
            if(effects is IStatsBreakdown)
            {
                var stats = effects as IStatsBreakdown;
                if(calculateDic.ContainsKey(effects.effectType))
                    text += UsefulMethod.optStr + stats.StatsBreakdownText(calculateDic[effects.effectType]) + "\n";
            }
        }
        _text = text;
    }
    private string _text;
    public string Text() => _text;
}
